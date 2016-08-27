using System;

namespace Refactoring
{
    public class Driver
    {
       private int PointsOnLicense { get; set; }
       private string LicenseNumber { get; set; }
       private DateTime LicenseExpireDate { get; set; }
       private DateTime DateOfBirth { get; set; }
       public string AddressLine1 { get; set; }
       public string AddressLine2 { get; set; }
       public string City { get; set; }
       public string State { get; set; }
       public string Zip { get; set; }
       public Driver(DateTime dateOfBirth, int pointsOnLicense, string licenseNumber, DateTime licenseExpireDate)
        {
            PointsOnLicense = pointsOnLicense;
            DateOfBirth = dateOfBirth;
            LicenseNumber = licenseNumber;
            LicenseExpireDate = licenseExpireDate;
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
            if (IsFullAddressEmpty(GetFormattedZip())) return String.Empty;
            return FormatAddress(GetFormattedZip());
        }

        private string FormatAddress(string formattedZip)
        {
            var outAddress = AddressLine1;
            if (!String.IsNullOrWhiteSpace(AddressLine2)) outAddress += "\n" + AddressLine2;
            if (!String.IsNullOrWhiteSpace(City) || !String.IsNullOrWhiteSpace(State))
            {
                outAddress += "\n";
                if (!String.IsNullOrWhiteSpace(City)) outAddress += City;
                if (!String.IsNullOrWhiteSpace(City) && !String.IsNullOrWhiteSpace(State)) outAddress += ", ";
                if (!String.IsNullOrWhiteSpace(State)) outAddress += State;
            }
            if (!String.IsNullOrWhiteSpace(formattedZip)) outAddress += "\n" + formattedZip;
            return outAddress;
        }

        private bool IsFullAddressEmpty(string formattedZip)
        {
            var fullAddress = String.Format("{0} {1} {2} {3} {4}", AddressLine1, AddressLine2, City, State, formattedZip).Trim();
            return String.IsNullOrWhiteSpace(fullAddress);
        }

        private string GetFormattedZip()
        {
            var formattedZip = Zip;
            if (Zip != null && Zip.Length > 5)
            {
                formattedZip = Zip.Substring(0, 5);
            }
            return formattedZip;
        }
    }
}
