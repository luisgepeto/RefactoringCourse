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
            return PointsOnLicense < 5;
        }
        public string GenerateLicenseReport()
        {
            return String.Format("Your license number is {0} and you have {1} points in your license. Your license expires on {2}", LicenseNumber,
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
            var formattedZip = Address.Zip;
            if (Address.Zip != null && Address.Zip.Length > 5)
            {
                formattedZip= Address.Zip.Substring(0, 5);
            }
            var fullAddress = String.Format("{0} {1} {2} {3} {4}", Address.AddressLine1, Address.AddressLine2, Address.City, Address.State, formattedZip).Trim();
            var outAddress = String.Empty;
            if (String.IsNullOrWhiteSpace(fullAddress)) return outAddress;
            outAddress = Address.AddressLine1;
            if (!String.IsNullOrWhiteSpace(Address.AddressLine2)) outAddress += "\n" + Address.AddressLine2;
            if (!String.IsNullOrWhiteSpace(Address.City) || !String.IsNullOrWhiteSpace(Address.State))
            {
                outAddress += "\n";
                if (!String.IsNullOrWhiteSpace(Address.City)) outAddress += Address.City;
                if (!String.IsNullOrWhiteSpace(Address.City) && !String.IsNullOrWhiteSpace(Address.State)) outAddress += ", ";
                if (!String.IsNullOrWhiteSpace(Address.State)) outAddress += Address.State;
            }
            if (!String.IsNullOrWhiteSpace(formattedZip)) outAddress += "\n" + formattedZip;
            return outAddress;
        }
    }
}
