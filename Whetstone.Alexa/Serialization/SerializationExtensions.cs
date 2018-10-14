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
#if NETSTANDARD1_6 || NETSTANDARD2_0
            var customAttribs = typeof(EnumMemberAttribute).GetTypeInfo().GetCustomAttributes();

            EnumMemberAttribute attrib = customAttribs.SingleOrDefault() as EnumMemberAttribute;

            return attrib == null ? value.ToString() : attrib.Value;

#endif

#if NETCOREAPP2_0 || NETCOREAPP1_1 || NETCOREAPP1_0
            EnumMemberAttribute attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .SingleOrDefault() as EnumMemberAttribute;
            return attribute == null ? value.ToString() : attribute.Value;

#endif



            throw new NotImplementedException("Not supported in the version of .NET in use");
        }

    }
}
