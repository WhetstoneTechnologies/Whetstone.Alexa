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
using System.Threading.Tasks;

namespace Whetstone.Alexa.Security
{
    public interface IAlexaUserDataManager
    {
        Task<string> GetAlexaUserEmailAsync(string apiEndpoint, string apiToken);

        Task<AlexaUserFullAddress> GetAlexaUserFullAddressAsync(string apiEndpoint, string apiToken, string deviceId);

        Task<string> GetAlexaUserFullNameAsync(string apiEndpoint, string apiToken);

        Task<string> GetAlexaUserGivenNameAsync(string apiEndpoint, string apiToken);

        Task<AlexaUserPhoneNumber> GetAlexaUserPhoneNumberAsync(string apiEndpoint, string apiToken);

        Task<AlexaUserPostalCode> GetAlexaUserPostalCodeAsync(string apiEndpoint, string apiToken, string deviceId);
    }
}