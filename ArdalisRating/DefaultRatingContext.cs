using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class DefaultRatingContext :IRatingContext,ILogger
    {
        IPolicyDeserializer _policyDeserializer;
        IRaterFactory _raterFactory;
        ILogger _logger;
        IPolicyReader _policyReader;
        public DefaultRatingContext(IPolicyDeserializer policyDeserializer,
            IRaterFactory raterFactory,
            ILogger logger,
            IPolicyReader policyReader) {
            _policyDeserializer = policyDeserializer;
            _raterFactory = raterFactory;
            _logger = logger;
            _policyReader = policyReader;
        }
        public RatingEngine Engine { get; set; }
        

        public Policy GetDeserializedPolicy(string policyJson)
        {
            return _policyDeserializer.GetDeserializedPolicy(policyJson);
        }

        public PolicyRater GetFactory(Policy policy)
        {
            return  _raterFactory.GetFactory(policy);
        }

        public string GetPolicy()
        {
            return _policyReader.GetPolicy();
        }

        public void Logg(string message)
        {
           _logger.Logg(message);
        }

        public void UpdateRating(decimal rating)
        {
            Engine.Rating=rating;
        }
    }
    
}
