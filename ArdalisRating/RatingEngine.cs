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
        IRatingContext _ratingContext = new DefaultRatingContext();
        public void Rate()
        {

            _ratingContext.Logg("Starting rate.");

            _ratingContext.Logg("Loading policy.");

            // load policy - open file policy.json
            string policyJson = _ratingContext.GetPolicy();

            var policy = _ratingContext.GetDeserializedPolicy(policyJson);
            var raterPolicy = _ratingContext.GetFactory(_ratingContext,policy);
            raterPolicy.Rate(policy);

            _ratingContext.Logg("Rating completed.");
        }
    }
}
