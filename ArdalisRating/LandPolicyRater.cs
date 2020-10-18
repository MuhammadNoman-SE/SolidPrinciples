using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class LandPolicyRater : PolicyRater
    {

        public LandPolicyRater(IUpdateRatting updateRatting) : base(updateRatting)
        {
        }
        public override void Rate(Policy policy)
        {
            LoggerInstance.Logg("Rating LAND policy...");
            LoggerInstance.Logg("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                LoggerInstance.Logg("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                LoggerInstance.Logg("Insufficient bond amount.");
                return;
            }
            _updateRatting.UpdateRating(policy.BondAmount * 0.05m);


        }
    }
}
