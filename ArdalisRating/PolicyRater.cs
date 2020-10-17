using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public abstract class PolicyRater
    {
        public abstract void Rate(Policy policy);
    }
}
