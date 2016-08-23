namespace Refactoring
{
    public class Wheel
    {
        public Wheel()
        {
            Tire = new Tire();
        }
        public Tire Tire { get; set; }
        //middle man use message chaing
        public string Move()
        {
            return Tire.Move();
        }
        //middle man use message chaing
        public string Stop()
        {
            return Tire.Stop();
        }
    }
}
