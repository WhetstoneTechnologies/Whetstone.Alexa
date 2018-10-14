using System;
using System.Collections.Generic;
using System.Text;
using Whetstone.Alexa.Security;

namespace Whetstone.Alexa
{
    public static class CardBuilder
    {

        //        {
        //  "version": "1.0",
        //  "response": {
        //    "card": {
        //      "type": "AskForPermissionsConsent",
        //      "permissions": [
        //        "alexa::profile:name:read",
        //        "alexa::profile:mobile_number:read"
        //      ]
        //    }
        //}
        //}

        public static CardAttributes GetPermissionRequestCard(string textMessage, PersonalDataType dataType)
        {
            return GetPermissionRequestCard(textMessage, new List<PersonalDataType> { dataType });
        }



        public static CardAttributes GetPermissionRequestCard(string textMessage, IEnumerable<PersonalDataType> dataTypes)
        {

            if (dataTypes == null)
                throw new ArgumentNullException("No permissions specified in dataTypes");

            CardAttributes retCard = new CardAttributes();

            retCard.Type = CardType.AskForPermissionsConsent;

            if (!string.IsNullOrWhiteSpace(textMessage))
                retCard.Text = textMessage;


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


    }
}
