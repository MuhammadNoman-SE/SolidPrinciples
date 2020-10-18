using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class AutoPolicyRater : PolicyRater
    {

        public AutoPolicyRater(ILogger logger) : base(logger)
        {
        }
        public override decimal Rate(Policy policy)
        {
            _logger.Logg("Rating AUTO policy...");
            _logger.Logg("Validating policy.");
            if (String.IsNullOrEmpty(policy.Make))
            {
                _logger.Logg("Auto policy must specify Make");
                return 0m;
            }
            if (policy.Make == "BMW")
            {
                if (policy.Deductible < 500)
                {
                    return 1000m;
                }
                return 900m;
            }
            return 0m;
        }
    }
}
