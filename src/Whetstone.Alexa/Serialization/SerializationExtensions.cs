// MIT License
// 
// Copyright (c) 2018 WhetstoneTechnologies
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Reflection;


namespace Whetstone.Alexa.Serialization
{
    public static class SerializationExtensions
    {

        public static string GetDescriptionFromEnumValue(this Enum value)
        {


            // For a list of compile time constants, see:
            // https://docs.microsoft.com/en-us/dotnet/core/tutorials/libraries


#if NETSTANDARD2_0
            EnumMemberAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .SingleOrDefault() as EnumMemberAttribute;

            return attribute == null ? value.ToString() : attribute.Value;
#endif

#if NETSTANDARD1_6 || NETSTANDARD1_3 || NET45 || NET47

            EnumMemberAttribute attribute = value.GetType().GetRuntimeField(value.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .SingleOrDefault() as EnumMemberAttribute;

            return attribute == null ? value.ToString() : attribute.Value;

            //var customAttribs = typeof(EnumMemberAttribute).GetTypeInfo().GetCustomAttributes();

            //EnumMemberAttribute attrib = customAttribs.SingleOrDefault() as EnumMemberAttribute;

            //return attrib == null ? value.ToString() : attrib.Value;
            
#endif


            throw new NotImplementedException("Not supported in the version of .NET in use");
        }

        public static IEnumerable<T> GetEnumValues<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }


        public static T GetEnumValue<T>(this string enumMemberText) where T : struct, Enum
        {

            T retVal = default(T);

            if (Enum.TryParse<T>(enumMemberText, out retVal))
                return retVal;
          

            var enumVals = GetEnumValues<T>();

            Dictionary<string, T> enumMemberNameMappings = new Dictionary<string, T>();

            foreach (T enumVal in enumVals)
            {
                string enumMember = enumVal.GetDescriptionFromEnumValue();
                enumMemberNameMappings.Add(enumMember, enumVal);
            }

            if (enumMemberNameMappings.ContainsKey(enumMemberText))
            {
                retVal = enumMemberNameMappings[enumMemberText];
            }
            else
                throw new SerializationException(string.Format("Could not resolve value {0} in enum {1}", enumMemberText, typeof(T).FullName));

            return retVal;
        }

    }
}
