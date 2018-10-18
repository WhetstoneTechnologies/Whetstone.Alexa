// Copyright (c) 2018 Whetstone Technologies
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
#if NETSTANDARD1_6 || NETSTANDARD2_0
using System.Reflection;
#endif


namespace Whetstone.Alexa.Serialization
{
    public static class SerializationExtensions
    {

        public static string GetDescriptionFromEnumValue(this Enum value)
        {


            // For a list of compile time constants, see:
            // https://docs.microsoft.com/en-us/dotnet/core/tutorials/libraries

            //#if NETSTANDARD1_4 || NETSTANDARD1_5 || NETSTANDARD1_6 || NETSTANDARD2_0
            //#if NETSTANDARD1_6 || NETSTANDARD2_0
            //            var customAttribs = typeof(EnumMemberAttribute).GetTypeInfo().GetCustomAttributes();

            //            EnumMemberAttribute attrib = customAttribs.SingleOrDefault() as EnumMemberAttribute;

            //            return attrib == null ? value.ToString() : attrib.Value;

            //#endif

            //#if NETCOREAPP2_0 || NETCOREAPP1_1 || NETCOREAPP1_0 || NETCOREAPP2_1
            //            EnumMemberAttribute attribute = value.GetType()
            //                .GetField(value.ToString())
            //                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
            //                .SingleOrDefault() as EnumMemberAttribute;
            //            return attribute == null ? value.ToString() : attribute.Value;

            //#endif


            EnumMemberAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .SingleOrDefault() as EnumMemberAttribute;
            return attribute == null ? value.ToString() : attribute.Value;


            throw new NotImplementedException("Not supported in the version of .NET in use");
        }

    }
}
