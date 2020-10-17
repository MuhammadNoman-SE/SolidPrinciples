using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class RaterFactory
    {
        public Logger _logger;
        public RatingEngine _ratingEngine;
        public RaterFactory(Logger logger,RatingEngine ratingEngine) {
            _logger = logger;
            _ratingEngine = ratingEngine;
        }
        public PolicyRater GetFactory(Policy policy) {
            try { 
            return (PolicyRater)Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),new Object[] {_ratingEngine._logger,_ratingEngine });
            }
            catch (Exception e)
            {
                _logger.Logg(e.Message.ToString());
                return null;
            }

        }
    }
}
