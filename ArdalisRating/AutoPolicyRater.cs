using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class AutoPolicyRater : PolicyRater
    {

        public Logger _logger;
        public RatingEngine _ratingEngine;
        public AutoPolicyRater(Logger logger, RatingEngine ratingEngine) {
            _logger = logger;
            _ratingEngine = ratingEngine;
        }
        public override void Rate(Policy policy)
        {
            _logger.Logg("Rating AUTO policy...");
            _logger.Logg("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                _logger.Logg("Auto policy must specify Make");
                return;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    _ratingEngine.Rating = 1000m;
                }
                _ratingEngine.Rating = 900m;
            }

        }
    }
}
