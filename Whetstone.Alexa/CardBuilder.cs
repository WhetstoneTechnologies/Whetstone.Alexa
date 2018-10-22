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
using Whetstone.Alexa.Security;

namespace Whetstone.Alexa
{
    public static class CardBuilder
    {

        public static CardAttributes GetPermissionRequestCard(PersonalDataType dataType)
        {
            return GetPermissionRequestCard(new List<PersonalDataType> { dataType });
        }


        public static CardAttributes GetPermissionRequestCard(IEnumerable<PersonalDataType> dataTypes)
        {

            if (dataTypes == null)
                throw new ArgumentNullException("No permissions specified in dataTypes");


            return InternalGetPermissionCardRequet(dataTypes);
        }


        private static CardAttributes InternalGetPermissionCardRequet(IEnumerable<PersonalDataType> dataTypes)
        {
            CardAttributes retCard = new CardAttributes();

            retCard.Type = CardType.AskForPermissionsConsent;

            retCard.Permissions = new List<string>();
            foreach (var dataType in dataTypes)
            {
                string permToken = AlexaUserDataManager.GetPermissionToken(dataType);
                retCard.Permissions.Add(permToken);
            }


            if (retCard.Permissions.Count == 0)
                throw new ArgumentException("No permissions requested");

            return retCard;


        }


        public static CardAttributes GetSimpleCardResponse(string title, string textResponse)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("No title specified.");

            if (string.IsNullOrWhiteSpace(textResponse))
                throw new ArgumentNullException("No text response specified.");


            CardAttributes retCard = new CardAttributes();

            retCard.Type = CardType.Simple;
            retCard.Content= textResponse;
            retCard.Title = title;


            return retCard;
        }

        public static CardAttributes GetStandardCardResponse(string title, string textResponse, string smallImageUrl, string largeImageUrl)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentNullException("No title specified.");

            if (string.IsNullOrWhiteSpace(textResponse))
                throw new ArgumentNullException("No textResponse specified.");

            if (string.IsNullOrWhiteSpace(smallImageUrl))
                throw new ArgumentNullException("No smallImageUrl specified.");

            if (string.IsNullOrWhiteSpace(largeImageUrl))
                throw new ArgumentNullException("No largeImageUrl specified.");

            CardAttributes retCard = new CardAttributes();

            retCard.Type = CardType.Standard;
            retCard.Text = textResponse;
            retCard.Title = title;
            retCard.ImageAttributes = new AlexaImageAttributes();
            retCard.ImageAttributes.SmallImageUrl = smallImageUrl;
            retCard.ImageAttributes.LargeImageUrl = largeImageUrl;

            return retCard;
        }
    }
}
