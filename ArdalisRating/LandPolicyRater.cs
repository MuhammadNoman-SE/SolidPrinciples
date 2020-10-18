using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class LandPolicyRater : PolicyRater
    {

        public LandPolicyRater(ILogger logger) : base(logger)
        {

        }
        public override decimal Rate(Policy policy)
        {
            _logger.Logg("Rating LAND policy...");
            _logger.Logg("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.Logg("Land policy must specify Bond Amount and Valuation.");
                return 0m;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logger.Logg("Insufficient bond amount.");
                return 0m;
            }
            return policy.BondAmount * 0.05m;


        }
    }
}
