using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class UnknownPolicyRater : PolicyRater
    {
        public UnknownPolicyRater(ILogger logger) : base(logger)
        {
        }
        public override decimal Rate(Policy policy)
        {
            _logger.Logg("Unknown Policy...");
            return 0m;
        }
    }
}
