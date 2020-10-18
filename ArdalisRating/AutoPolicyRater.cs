using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class AutoPolicyRater : PolicyRater
    {

        public AutoPolicyRater(IUpdateRatting updateRatting) : base(updateRatting)
        {
        }
        public override void Rate(Policy policy)
        {
            LoggerInstance.Logg("Rating AUTO policy...");
            LoggerInstance.Logg("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                LoggerInstance.Logg("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _updateRatting.UpdateRating(1000m);
                }
                _updateRatting.UpdateRating(900m);
            }

        }
    }
}
