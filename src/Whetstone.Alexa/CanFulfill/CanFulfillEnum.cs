// MIT License
// 
// Copyright (c) 2019 WhetstoneTechnologies
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
using System.Runtime.Serialization;
using System.Text;

namespace Whetstone.Alexa.CanFulfill
{
    /// <summary>
    /// Used by the <see cref="Whetstone.Alexa.CanFulfill.CanFulfillResponseAttributes">CanFullfillResponseAttributes</see> to tell 
    /// Alexa whether the intent is supported by the Alexa skill.
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    public enum CanFulfillEnum
    {
        /// <summary>
        /// Use if your skill understands all slots, can fulfill all slots, and can fulfill the request in its entirety.
        /// </summary>
        [EnumMember(Value = "YES")]
        Yes,
        /// <summary>
        /// Use if your skill cannot understand the intent, and/or cannot understand any of the slots, and/or cannot fulfill any of the slots.
        /// </summary>
        [EnumMember(Value = "NO")]
        No,

        /// <summary>
        /// Use if your skill can understand the intent, can partially or fully understand the slots, and can partially or fully fulfill the slots.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The only cases where your skill should respond with MAYBE is when your skill can potentially complete the request if your skill get more data 
        /// through a multi-turn conversation with the user. For example, if the skill understands the intent, such as orderCabIntent, but needs the customer 
        /// to link their account before being able to fulfill the request. Another example is travelBookingIntent, where the skill understands a subset of all 
        /// identified slots and needs more information before it can determine whether it can fulfill the intent for each slot value.
        /// </para>
        /// </remarks>
        [EnumMember(Value = "MAYBE")]
        Maybe


    }
}
