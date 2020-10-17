using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine
    {
        public decimal Rating { get; set; }
        public Logger _logger=new Logger();
        public PolicyReader _policyReader = new PolicyReader();
        public PolicyDeserializer _policyDeserializer = new PolicyDeserializer();
        public void Rate()
        {

            _logger.Logg("Starting rate.");

            _logger.Logg("Loading policy.");

            // load policy - open file policy.json
            string policyJson = _policyReader.GetPolicy();

            var policy = _policyDeserializer.GetDeserializedPolicy(policyJson);

            switch (policy.Type)
            {
                case PolicyType.Auto:
                    _logger.Logg("Rating AUTO policy...");
                    _logger.Logg("Validating policy.");
                    if (String.IsNullOrEmpty(policy.Make))
                    {
                        _logger.Logg("Auto policy must specify Make");
                        return;
                    }
                    if (policy.Make == "BMW")
                    {
                        if (policy.Deductible < 500)
                        {
                            Rating = 1000m;
                        }
                        Rating = 900m;
                    }
                    break;

                case PolicyType.Land:
                    _logger.Logg("Rating LAND policy...");
                    _logger.Logg("Validating policy.");
                    if (policy.BondAmount == 0 || policy.Valuation == 0)
                    {
                        _logger.Logg("Land policy must specify Bond Amount and Valuation.");
                        return;
                    }
                    if (policy.BondAmount < 0.8m * policy.Valuation)
                    {
                        _logger.Logg("Insufficient bond amount.");
                        return;
                    }
                    Rating = policy.BondAmount * 0.05m;
                    break;

                case PolicyType.Life:
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
                        Rating = baseRate * 2;
                        break;
                    }
                    Rating = baseRate;
                    break;

                default:
                    _logger.Logg("Unknown policy type");
                    break;
            }

            _logger.Logg("Rating completed.");
        }
    }
}
