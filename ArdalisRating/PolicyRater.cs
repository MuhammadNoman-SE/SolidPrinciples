using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public abstract class PolicyRater
    {
        public ILogger LoggerInstance=new Logger();
        public IUpdateRatting _updateRatting;
        public PolicyRater(IUpdateRatting updateRatting)
        {
            _updateRatting=updateRatting;
        }
        public abstract void Rate(Policy policy);
    }
}
