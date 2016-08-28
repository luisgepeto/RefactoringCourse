using System;

namespace Refactoring
{
    public class Driver
    {
        private DateTime DateOfBirth { get; set; }
        public Address Address { get; set; }
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
        public int GetPointsOnLicense()
        {
            return License.GetPointsOnLicense();
        }

        public bool IsLicenseValid()
        {
            return License.IsLicenseValid()
        }
        public string GenerateLicenseReport()
        {
            return License.GenerateLicenseReport();
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

        public string FormattedAddress()
        {
            return Address.FormattedAddress();
        }
    }
}
