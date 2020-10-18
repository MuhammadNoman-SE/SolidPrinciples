using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public PolicyRater GetFactory(Policy policy,IRatingContext ratingContext) {
            try { 
            return (PolicyRater)Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),new Object[] {ratingContext });
            }
            catch (Exception e)
            {
                return new UnknownPolicyRater(ratingContext);
            }

        }
    }
}
