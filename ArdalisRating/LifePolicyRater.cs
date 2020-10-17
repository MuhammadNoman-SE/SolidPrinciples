using System;
using System.Collections.Generic;
using System.Text;

namespace ArdalisRating
{
    public class LifePolicyRater : PolicyRater
    {

        public Logger _logger;
        public RatingEngine _ratingEngine;
        public LifePolicyRater(Logger logger, RatingEngine ratingEngine) {
            _logger = logger;
            _ratingEngine = ratingEngine;
        }
        public override void Rate(Policy policy)
        {
            _logger.Logg("Rating LIFE policy...");
            _logger.Logg("Validating policy.");
            if (policy.DateOfBirth == DateTime.MinValue)
            {
                _logger.Logg("Life policy must include Date of Birth.");
                return;
            }
            if (policy.DateOfBirth < DateTime.Today.AddYears(-100))
            {
                _logger.Logg("Centenarians are not eligible for coverage.");
                return;
            }
            if (policy.Amount == 0)
            {
                _logger.Logg("Life policy must include an Amount.");
                return;
            }
            int age = DateTime.Today.Year - policy.DateOfBirth.Year;
            if (policy.DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < policy.DateOfBirth.Day ||
                DateTime.Today.Month < policy.DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = policy.Amount * age / 200;
            if (policy.IsSmoker)
            {
                _ratingEngine.Rating = baseRate * 2;
                return;
            }
            _ratingEngine.Rating = baseRate;
        }
    }
}
