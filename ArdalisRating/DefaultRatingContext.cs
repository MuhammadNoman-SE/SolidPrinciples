using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class DefaultRatingContext :IRatingContext,ILogger
    {
        public RatingEngine Engine { get; set; }
        

        public Policy GetDeserializedPolicy(string policyJson)
        {
            return new PolicyDeserializer().GetDeserializedPolicy(policyJson);
        }

        public PolicyRater GetFactory(IRatingContext ratingContext,Policy policy)
        {
            return  new RaterFactory().GetFactory(policy,ratingContext);
        }

        public string GetPolicy()
        {
            return new PolicyReader().GetPolicy();
        }

        public void Logg(string message)
        {
           new Logger().Logg(message);
        }

        public void UpdateRating(decimal rating)
        {
            new RatingEngine().Rating=rating;
        }
    }
}
