using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Whetstone.Alexa.CanFulfill
{
    public enum CanFulfillEnum
    {
        [EnumMember(Value = "YES")]
        Yes,
        [EnumMember(Value = "NO")]
        No,
        [EnumMember(Value = "MAYBE")]
        Maybe


    }
}
