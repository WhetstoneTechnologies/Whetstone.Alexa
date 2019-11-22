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
using Newtonsoft.Json;

namespace Whetstone.Alexa
{

    /// <summary>
    /// Represents a personalized Alexa based on voice recognition.
    /// </summary>
    /// <remarks>
    /// <para>
    /// An object that describes the person who is making the request to Alexa.
    /// The person object is different than the user object, because person refers to a user whom Alexa
    /// recognizes by voice, whereas user refers to the Amazon account for which the skill is enabled.
    /// </para>
    /// </remarks>
    [JsonObject("person")]
    public class PersonAttributes
    {


        /// <summary>
        /// A string that represents a unique identifier for the person who is making the request.
        /// The length of this identifier can vary, but is never more than 255 characters.
        /// Alexa generates this string when a recognized speaker makes a request to your skill.
        /// Normally, disabling and re-enabling a skill generates a new identifier.
        /// </summary>
        [JsonProperty(PropertyName = "personId")]
        public string PersonId { get; set; }

        /// <summary>
        /// A token identifying the person in another system.
        /// This field only appears in the request if the person has successfully linked their account with their Alexa profile.
        /// </summary>
        [JsonProperty(PropertyName = "accessToken")]
        public string AccessToken { get; set; }

    }
}
