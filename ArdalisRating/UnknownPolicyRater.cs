using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class UnknownPolicyRater : PolicyRater
    {

        public Logger _logger;
        public RatingEngine _ratingEngine;
        public UnknownPolicyRater(Logger logger, RatingEngine ratingEngine):base(logger, ratingEngine)
        {
            _logger = logger;
            _ratingEngine = ratingEngine;
        }
        public override void Rate(Policy policy)
        {
            _logger.Logg("Unknown Policy...");
            
        }
    }
}
