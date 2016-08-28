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
        public string Drive()
        {
            return Car.Drive();
        }
        public string BuySpareWheel()
        {
            while (Car.NumberOfWheels <= 4) Car.NumberOfWheels ++;
            return String.Format("My car now has {0} number of wheels", Car.NumberOfWheels);
        }
    }
    public class BycicleDriver : Driver
    {
        public BycicleDriver(DateTime dateOfBirth, int pointsOnLicense, string licenseNumber, DateTime licenseExpireDate, string bycicleModel) : base(dateOfBirth, pointsOnLicense, licenseNumber, licenseExpireDate)
        {
            BycicleModel = bycicleModel;
        }
        
        private string BycicleModel { get; set; }
        public string GetBycicleModel()
        {
            return BycicleModel;
        }
        public string Drive()
        {
            return "I am driving a bike";
        }
        public int GetNumberOfWheels()
        {
            return 2;
        }
    }
}