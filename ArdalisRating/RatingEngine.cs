using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public Logger _logger=new Logger();
        public PolicyReader _policyReader = new PolicyReader();
        public PolicyDeserializer _policyDeserializer = new PolicyDeserializer();
        public void Rate()
        {

            _logger.Logg("Starting rate.");

            _logger.Logg("Loading policy.");

            // load policy - open file policy.json
            string policyJson = _policyReader.GetPolicy();

            var policy = _policyDeserializer.GetDeserializedPolicy(policyJson);
            RaterFactory raterFactory = new RaterFactory(_logger,this);
            var raterPolicy = raterFactory.GetFactory(policy);
            raterPolicy.Rate(policy);

            _logger.Logg("Rating completed.");
        }
    }
}
