namespace Refactoring
{
    public class Car : Vehicle
    {
        public string CarBrand { get; set; }
        public Car(string carBrand)
        {
            CarBrand = carBrand;
        }

        //Parallel Inheritance try adding a new driver and a new vehicle
        public override string Drive()
        {
            return "I am driving a car";
        }

    }
}
