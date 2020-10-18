using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface IUpdateRatting{
        void UpdateRating(decimal rating);
    
    }
    public interface IRatingContext:ILogger,IUpdateRatting
    {
        string GetPolicy();
        Policy GetDeserializedPolicy(string policyJson);
        PolicyRater GetFactory(IRatingContext ratingContext, Policy policy);
        RatingEngine Engine { get; set; }

    }
}
