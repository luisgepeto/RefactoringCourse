using System;

namespace Refactoring
{
    public class License
    {
        public int PointsOnLicense { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpireDate { get; set; }

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
    }
}
