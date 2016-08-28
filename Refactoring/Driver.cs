using System;

namespace Refactoring
{
    public class Driver
    {
        private DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
        public Address GetAddress()
        {
            return Address;
        }
        private License License { get; set; }
        public License GetLicense()
        {
            return License;
        }
        public Driver(DateTime dateOfBirth, int pointsOnLicense, string licenseNumber, DateTime licenseExpireDate)
        {
            DateOfBirth = dateOfBirth;
            Address = new Address();
            License = new License();
            License.PointsOnLicense = pointsOnLicense;
            License.LicenseNumber = licenseNumber;
            License.LicenseExpireDate = licenseExpireDate;
        }

        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            return age;
        }

        public string PrintAge()
        {
            return String.Format("You are {0} years old.", GetAge());
        }

        public RiskFactor CalculateDriverRiskFactor()
        {
            if (GetLicense().GetPointsOnLicense() > 3 || GetAge() < 25)
                return RiskFactor.High;

            if (GetLicense().GetPointsOnLicense() > 0)
                return RiskFactor.Moderate;

            return RiskFactor.Low;
        }

        public double CalculateInsurancePremium(double insuranceValue)
        {
            return insuranceValue * CalculateDriverRiskFactor().RiskMultiplier();
        }
    }
}
