using System;
namespace Refactoring
{
    public class Wheel
    {
        public Wheel()
        {
            Tire = new Tire();
        }
        public Tire Tire { get; set; }
        public string Move()
        {
            return Tire.Move();
        }
        public string Stop()
        {
            return Tire.Stop();
        }
    }
    public class Tire
    {
        public string Move()
        {
            return "I am a moving tire";
        }
        public string Stop()
        {
            return "I am a stopping tire";
        }
    }
    public class FortuneWheel : Vehicle
    {
        public virtual string Move()
        {
            return Wheel.Move();
        }
        public virtual string Stop()
        {
            return Wheel.Stop();
        }

        public override int GetNumberOfWheels()
        {
            return 1;
        }
    }
}