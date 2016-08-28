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

        public string Drive()
        {
            return "I am driving a car";
        }

        public override int GetNumberOfWheels()
        {
            return 4;
        }
        //21 inappropriate intimacy
        public string VerifyOwnership()
        {
            var result = "This car has no owner";
            if (Driver != null)
            {
                result = "This car has an owner";
                if (!String.IsNullOrWhiteSpace(Driver.GetAddress().FormattedAddress()))
                {
                    result += "\nThe owner's address is:\n"+Driver.GetAddress().FormattedAddress();
                }
            }
            return result;
        }

    }
}