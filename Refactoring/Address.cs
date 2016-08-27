using System;

namespace Refactoring
{
    public class Address
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public string FormattedAddress()
        {
            var formattedZip = Zip;
            if (Zip != null && Zip.Length > 5)
            {
                formattedZip = Zip.Substring(0, 5);
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
