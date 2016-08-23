namespace Refactoring
{
    public abstract class Vehicle
    {
        protected Vehicle()
        {
            Wheel = new Wheel();
        }
        public Wheel Wheel { get; set; }
        //Parallel Inheritance try adding a new driver and a new vehicle
        public virtual string Drive()
        {
            return "I am driving a vehicle";
        }

        //middle man use message chaing
        public virtual string Move()
        {
            return Wheel.Move();
        }
        //middle man use message chaing
        public virtual string Stop()
        {
            return Wheel.Stop();
        }

        public abstract int GetNumberOfWheels();
    }
}
