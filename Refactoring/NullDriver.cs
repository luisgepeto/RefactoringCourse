using System;

namespace Refactoring
{
    public class NullDriver : Driver
    {
        public NullDriver(DateTime dateOfBirth, int pointsOnLicense, string licenseNumber, DateTime licenseExpireDate) : base(dateOfBirth, pointsOnLicense, licenseNumber, licenseExpireDate)
        {
        }

        public override bool IsNull()
        {
            return true;
        }
    }
}
