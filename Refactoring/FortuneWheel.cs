using System;

namespace Refactoring
{
    public class FortuneWheel : Vehicle
    {
        //refused bequest only reuses wheel
        public override string Drive()
        {
            throw new NotImplementedException();
        }

        public virtual string Move()
        {
            return Wheel.Move();
        }
        //middle man use message chaing
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
