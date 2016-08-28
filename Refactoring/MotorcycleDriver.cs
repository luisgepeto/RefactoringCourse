using System;

namespace Refactoring
{
    public class MotorcycleDriver : Driver
    {
        public MotorcycleDriver(DateTime dateOfBirth, int pointsOnLicense, string licenseNumber, DateTime licenseExpireDate, string motorcycleModel) : base(dateOfBirth, pointsOnLicense, licenseNumber, licenseExpireDate)
        {
            MotorcycleModel = motorcycleModel;
            Motorcycle = new Motorcycle(MotorcycleModel);
        }

        public Motorcycle Motorcycle { get; set; }
        private string MotorcycleModel { get; set; }
        public string GetMotorcycleModel()
        {
            return MotorcycleModel;
        }
        public string Drive()
        {
            return Motorcycle.Drive();
        }
    }
}
