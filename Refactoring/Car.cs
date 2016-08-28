using System;

namespace Refactoring
{
    public class Car : Vehicle
    {
        public string CarBrand { get; set; }
        public int NumberOfWheels { get; set; }
        public Car(string carBrand)
        {
            CarBrand = carBrand;
            NumberOfWheels = 4;
        }

        private Driver Driver { get; set; }
        public void SetDriver(Driver driver)
        {
            Driver = driver;
        }

        public string Drive()
        {
            return "I am driving a car";
        }

        public override int GetNumberOfWheels()
        {
            return 4;
        }
        public string VerifyOwnership()
        {
            return Driver.VerifyOwnership();
        }

    }
}