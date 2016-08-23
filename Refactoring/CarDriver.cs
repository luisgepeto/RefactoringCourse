using System;

namespace Refactoring
{
    public class CarDriver : Driver
    {
        public CarDriver(DateTime dateOfBirth, int pointsOnLicense, string licenseNumber, DateTime licenseExpireDate, string carBrand) : base(dateOfBirth, pointsOnLicense, licenseNumber, licenseExpireDate)
        {
            CarBrand = carBrand;
            Car = new Car(CarBrand);
        }
        public Car Car { get; set; }
        private string CarBrand { get; set; }
        public string GetCarBrand()
        {
            return CarBrand;
        }
        //Parallel Inheritance Hierarchies - try passing vehicle as argument
        public string Drive()
        {
            return Car.Drive();
        }

        //inappropirate intimacy
        public string BuySpareWheel()
        {
            while (Car.NumberOfWheels <= 4)
            {
                Car.NumberOfWheels ++;
            }
            return String.Format("My car now has {0} number of wheels", Car.NumberOfWheels);
        }
    }
}
