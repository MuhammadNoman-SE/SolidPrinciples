using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArdalisRating
{
    public interface IPolicyReader {
        string GetPolicy();
    }
    public class PolicyReader:IPolicyReader
    {
        public string GetPolicy() {
            string policyJson = File.ReadAllText("policy.json");
            return policyJson;
        }
    }
}
