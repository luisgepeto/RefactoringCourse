﻿namespace Refactoring
{
    public abstract class Vehicle
    {
        protected Vehicle()
        {
            Wheel = new Wheel();
        }
        public Wheel Wheel { get; set; }
        public virtual string Drive()
        {
            return "I am driving a vehicle";
        }
        public virtual string Move()
        {
            return Wheel.Move();
        }
        public virtual string Stop()
        {
            return Wheel.Stop();
        }
        public abstract int GetNumberOfWheels();
    }

    public class Bycicle : Vehicle
    {
        public Bycicle(string bycicleModel)
        {
            BycicleModel = bycicleModel;
        }

        public string BycicleModel { get; set; }
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