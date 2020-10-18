using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class LandPolicyRater : PolicyRater
    {

        public Logger _logger;
        public RatingEngine _ratingEngine;
        public LandPolicyRater(Logger logger, RatingEngine ratingEngine) : base(logger, ratingEngine)
        {
            _logger = logger;
            _ratingEngine = ratingEngine;
        }
        public override void Rate(Policy policy)
        {
            _logger.Logg("Rating LAND policy...");
            _logger.Logg("Validating policy.");
            if (policy.BondAmount == 0 || policy.Valuation == 0)
            {
                _logger.Logg("Land policy must specify Bond Amount and Valuation.");
                return;
            }
            if (policy.BondAmount < 0.8m * policy.Valuation)
            {
                _logger.Logg("Insufficient bond amount.");
                return;
            }
            _ratingEngine.Rating = policy.BondAmount * 0.05m;


        }
    }
}
