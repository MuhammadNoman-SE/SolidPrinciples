using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class PolicyDeserializer
    {
        public Policy GetDeserializedPolicy(string policyJson) {
            var policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                    new StringEnumConverter());
            return policy;
        }
    }
}
