using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArdalisRating
{
    public class PolicyReader
    {
        public string GetPolicy() {
            string policyJson = File.ReadAllText("policy.json");
            return policyJson;
        }
    }
}
