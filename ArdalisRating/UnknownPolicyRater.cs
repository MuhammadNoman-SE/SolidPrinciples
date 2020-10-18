using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class UnknownPolicyRater : PolicyRater
    {
        public UnknownPolicyRater(IUpdateRatting updateRatting):base(updateRatting)
        {
        }
        public override void Rate(Policy policy)
        {
            LoggerInstance.Logg("Unknown Policy...");
            
        }
    }
}
