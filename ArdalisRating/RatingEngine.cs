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
        public IPolicyDeserializer _policyDeserializer;
        public IRaterFactory _raterFactory;
        public ILogger _logger;
        public IPolicyReader _policyReader;
        public IRatingContext _ratingContext;
        public RatingEngine(IPolicyDeserializer policyDeserializer,
            IRaterFactory raterFactory,
            ILogger logger,
            IPolicyReader policyReader)
        {
            _policyDeserializer = policyDeserializer;
            _raterFactory = raterFactory;
            _logger = logger;
            _policyReader = policyReader;
            _ratingContext = new DefaultRatingContext(_policyDeserializer,
               _raterFactory,
               _logger,
               _policyReader);
            _ratingContext.Engine = this;
        }
        public decimal Rating { get; set; }
       
        public void Rate()
        {

            _logger.Logg("Starting rate.");

            _logger.Logg("Loading policy.");

            // load policy - open file policy.json
            string policyJson = _ratingContext.GetPolicy();

            var policy = _ratingContext.GetDeserializedPolicy(policyJson);
            var raterPolicy = _ratingContext.GetFactory(policy);
            decimal rating = raterPolicy.Rate(policy);
            _ratingContext.UpdateRating(rating);
            _logger.Logg("Rating completed.");
        }
    }
}
