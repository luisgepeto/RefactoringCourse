using System;

namespace Refactoring
{
    public class BycicleDriver : Driver
    {
        public BycicleDriver(DateTime dateOfBirth, int pointsOnLicense, string licenseNumber, DateTime licenseExpireDate, string bycicleModel) : base(dateOfBirth, pointsOnLicense, licenseNumber, licenseExpireDate)
        {
            BycicleModel = bycicleModel;
            Bycicle = new Bycicle(BycicleModel);
        }

        public Bycicle Bycicle { get; set; }
        private string BycicleModel { get; set; }
        public string GetBycicleModel()
        {
            return BycicleModel;
        }
        //Parallel Inheritance Hierarchies - try passing vehicle as argument
        public string Drive()
        {
            return Bycicle.Drive();
        }
    }
}
