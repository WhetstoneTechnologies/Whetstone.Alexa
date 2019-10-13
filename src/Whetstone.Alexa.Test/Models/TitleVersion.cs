using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Whetstone.Alexa.Test.Models
{
    public class TitleVersion
    {

        public TitleVersion()
        {

        }

        [JsonProperty(PropertyName = "shortName")]
        public string ShortName { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "titleId")]
        public Guid? TitleId { get; set; }


        [JsonProperty(PropertyName = "versionId")]
        public Guid? VersionId { get; set; }


        [JsonProperty(PropertyName = "deploymentId")]
        public Guid? DeploymentId { get; set; }
    }
}
