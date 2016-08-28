using System;

namespace Refactoring
{
    public class Driver
    {
       private DateTime DateOfBirth { get; set; }
       public Address Address { get; set; }
       public License License { get; set; }
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
            return License.PointsOnLicense;
        }

        public bool IsLicenseValid()
        {                                                                                                         
            return License.PointsOnLicense < 10;
        }
        public string GenerateLicenseReport()
        {
            return String.Format("Your license number is {0} and you have {1} points in your license. Your license expires on {2}. Thanks", License.LicenseNumber,
                License.PointsOnLicense, License.LicenseExpireDate.ToString("d"));
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
