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
using System.Text;
using System.Linq;

namespace Whetstone.Alexa.Security
{
    public static class SecurityExtensions
    {

        /// <summary>
        /// <para>Determines whether the SkillPermissionChanged or SkillPermissionAccepted includes the permissionScope.</para>
        /// </summary>
        /// <param name="request">The <see cref="Whetstone.Alexa.AlexaRequest">AlexaRequest</see> to inspect.</param>
        /// <param name="permissionScope">The permission scope which should be restricted to the scopes defined in <see cref="Whetstone.Alexa.Security.PermissionScopes">PermissionScopes</see></param>
        /// <returns>
        ///   <c>true</c> if the permissionScope is in included in the <see cref="Whetstone.Alexa.Security.AcceptedPermission">acceptedPermissions</see> of the request 
        ///   <see cref="Whetstone.Alexa.AlexaRequestBodyAttributes">body</see>; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">request cannot be null</exception>
        /// <exception cref="ArgumentException">
        /// permissionScope cannot be null or empty
        /// or
        /// Request property on request cannot be null
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static bool HasAcceptedPermission(this AlexaRequest request, string permissionScope)
        {
            bool hasPermission = false;

            if (request == null)
                throw new ArgumentNullException("request cannot be null");


            if (string.IsNullOrWhiteSpace(permissionScope))
                throw new ArgumentException("permissionScope cannot be null or empty");

            if (request.Request == null)
                throw new ArgumentException("Request property on request cannot be null");

            if (request.Request.Type == RequestType.SkillPermissionAccepted ||
                request.Request.Type == RequestType.SkillPermissionChanged)
            {
                List<AcceptedPermission> scopes = request.Request?.Body?.AcceptedPermissions;

                if (scopes != null)
                {
                   var foundScope = scopes.FirstOrDefault(x => x.Scope.Equals(permissionScope));
                    hasPermission = foundScope != null;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(string.Format("Request type must be {0} or {1}. Unsupported request type {2}",
                    RequestType.SkillPermissionAccepted,
                    RequestType.SkillPermissionChanged,
                    request.Request.Type));

            }

            return hasPermission;
        }


    }
}
