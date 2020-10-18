using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public abstract class PolicyRater
    {
        public Logger _logger;
        public RatingEngine _ratingEngine;
        public PolicyRater(Logger logger, RatingEngine ratingEngine)
        {
            _logger = logger;
            _ratingEngine = ratingEngine;
        }
        public abstract void Rate(Policy policy);
    }
}
