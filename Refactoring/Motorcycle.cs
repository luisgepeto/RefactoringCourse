namespace Refactoring
{
    public class Motorcycle : Vehicle
    {
        public Motorcycle(string motorcycleModel)
        {
            MotorcycleModel = motorcycleModel;
        }

        public string MotorcycleModel { get; set; }
        public string Drive()
        {
            return "I am driving a motorbike";
        }
        public override int GetNumberOfWheels()
        {
            return 2;
        }
    }
}
