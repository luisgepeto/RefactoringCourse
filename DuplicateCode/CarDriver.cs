using System;

namespace DuplicatedCode
{
    public class CarDriver : Driver
    {
        //Lazy Class
        public CarDriver(DateTime dateOfBirth, int pointsOnLicense, string licenseNumber, DateTime licenseExpireDate, string carBrand) : base(dateOfBirth, pointsOnLicense, licenseNumber, licenseExpireDate)
        {
            CarBrand = carBrand;
        }
        private string CarBrand { get; set; }
        public string GetCarBrand()
        {
            return CarBrand;
        }

        
    }
}
