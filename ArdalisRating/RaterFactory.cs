using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public interface IRaterFactory {
        PolicyRater GetFactory(Policy policy);
    }
    public class RaterFactory:IRaterFactory
    {
        ILogger _logger;
        public RaterFactory(ILogger logger) {
            _logger = logger;
        }
        public PolicyRater GetFactory(Policy policy) {
            try { 
            return (PolicyRater)Activator.CreateInstance(Type.GetType($"ArdalisRating.{policy.Type}PolicyRater"),new Object[] {_logger });
            }
            catch (Exception e)
            {
                return new UnknownPolicyRater(_logger);
            }

        }
    }
}
