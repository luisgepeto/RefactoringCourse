namespace Refactoring
{
    public class Bycicle : Vehicle
    {
        public Bycicle(string bycicleModel)
        {
            BycicleModel = bycicleModel;
        }

        public string BycicleModel { get; set; }
        //Parallel Inheritance try adding a new driver and a new vehicle
        public override string Drive()
        {
            return "I am driving a bike";
        }

        public override int GetNumberOfWheels()
        {
            return 2;
        }
    }
}
