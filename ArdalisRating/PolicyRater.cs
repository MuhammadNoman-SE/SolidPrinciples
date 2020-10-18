using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public abstract class PolicyRater
    {
        public ILogger _logger;
        public PolicyRater(ILogger logger)
        {
            _logger=logger;
        }
        public abstract decimal Rate(Policy policy);
    }
}
