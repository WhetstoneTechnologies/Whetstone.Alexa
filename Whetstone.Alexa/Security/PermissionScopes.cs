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
using System.Text;

namespace Whetstone.Alexa.Security
{
    public static class PermissionScopes
    {

        public static readonly string SCOPE_FULLADDRESS = "read::alexa:device:all:address";
        public static readonly string SCOPE_POSTALCODE = "read::alexa:device:all:address:country_and_postal_code";
        public static readonly string SCOPE_FULLNAME_READ = "alexa::profile:name:read";
        public static readonly string SCOPE_GIVENNAME_READ = "alexa::profile:given_name:read";
        public static readonly string SCOPE_EMAIL_READ = "alexa::profile:email:read";
        public static readonly string SCOPE_MOBILENUMBER_READ = "alexa::profile:mobile_number:read";

        public static readonly string SCOPE_LIST_HOUSEHOLD_READ = "read::alexa:household:list";

        public static readonly string SCOPE_LIST_HOUSEHOLD_WRITE = "write::alexa:household:list";

        public static readonly string SCOPE_SKILLMESSAGING = "alexa:skill_messaging";



    }
}
