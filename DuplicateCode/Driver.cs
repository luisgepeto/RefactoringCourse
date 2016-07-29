using System;

namespace DuplicatedCode
{
    public class Driver
    {
        //Divergent change - Extract class - Can implement null object
        private int PointsOnLicense { get; set; }
        private string LicenseNumber { get; set; }
        private DateTime LicenseExpireDate { get; set; }
        private DateTime DateOfBirth { get; set; }
        //Primitive Obsession 
        //Divergent Change - Extract Class
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
            //Divergent change (Make Change) - Extract class
            return PointsOnLicense < 5;
        }

        public string GenerateLicenseReport()
        {
            //Divergent change (Make Change) - Extract class
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
            //Long Method - Replace parameter with Query
            //Primitive Obsession
            var formattedZip = Zip;
            if (Zip != null && Zip.Length > 5)
            {
                formattedZip= Zip.Substring(0, 5);
            }
            var fullAddress = String.Format("{0} {1} {2} {3} {4}", AddressLine1, AddressLine2, City, State, formattedZip).Trim();
            var outAddress = String.Empty;
            if (String.IsNullOrWhiteSpace(fullAddress)) return outAddress;
            outAddress = AddressLine1;
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
    }
}
