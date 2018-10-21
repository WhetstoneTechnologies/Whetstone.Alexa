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
