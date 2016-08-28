using System;

namespace Refactoring
{
    public class Driver
    {
       private int PointsOnLicense { get; set; }
       private string LicenseNumber { get; set; }
       private DateTime LicenseExpireDate { get; set; }
       private DateTime DateOfBirth { get; set; }
       public Address Address { get; set; }
       public Driver(DateTime dateOfBirth, int pointsOnLicense, string licenseNumber, DateTime licenseExpireDate)
        {
            PointsOnLicense = pointsOnLicense;
            DateOfBirth = dateOfBirth;
            LicenseNumber = licenseNumber;
            LicenseExpireDate = licenseExpireDate;
            Address = new Address();
        }
        public int GetPointsOnLicense()
        {
            return PointsOnLicense;
        }

        public bool IsLicenseValid()
        {
            return PointsOnLicense < 10;
        }
        public string GenerateLicenseReport()
        {
            return String.Format("Your license number is {0} and you have {1} points in your license. Your license expires on {2}. Thanks", LicenseNumber,
                PointsOnLicense, LicenseExpireDate.ToString("d"));
        }

        public int GetAge()
        {
            var today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth > today.AddYears(-age)) age--;
            return age;
        }
        
        public string FormattedAddress()
        {
            return Address.FormattedAddress();
        }
    }
}
