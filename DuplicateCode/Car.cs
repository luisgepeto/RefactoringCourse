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
        public void SetDriver(CarDriver driver)
        {
            Driver = driver;
        }

        //Parallel Inheritance try adding a new driver and a new vehicle
        public override string Drive()
        {
            return "I am driving a car";
        }

        //inappropirate intimacy
        public string VerifyOwnership()
        {
            var result = "This car has no owner";
            if (Driver != null)
            {
                result = "This car has an owner";
                if (!String.IsNullOrWhiteSpace(Driver.FormattedAddress()))
                {
                    result += "\nThe owner's address is:\n"+Driver.FormattedAddress();
                }
            }
            return result;
        }

    }
}
