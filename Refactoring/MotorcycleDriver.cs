using System;

namespace Refactoring
{
    public class MotorcycleDriver : Driver
    {
        public MotorcycleDriver(DateTime dateOfBirth, int pointsOnLicense, string licenseNumber, DateTime licenseExpireDate, string motorcycleModel) : base(dateOfBirth, pointsOnLicense, licenseNumber, licenseExpireDate)
        {
            MotorcycleModel = motorcycleModel;
        }

        public string MotorcycleModel { get; set; }
        public string Drive()
        {
            return "I am driving a motorbike";
        }
        public int GetNumberOfWheels()
        {
            return 2;
        }
    }
}
