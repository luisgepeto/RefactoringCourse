namespace Refactoring
{
    public enum InterestPeriod
    {
        Day, 
        Month,
        Semester,
        Year
    }

    public static class Extensions
    {
        public static double NumberOfPeriodsPerYear(this InterestPeriod interestPeriod)
        {
            double numberOfPeriodsPerYear = 0;
            switch (interestPeriod)
            {
                case InterestPeriod.Day:
                    numberOfPeriodsPerYear = 365;
                    break;
                case InterestPeriod.Month:
                    numberOfPeriodsPerYear = 12;
                    break;
                case InterestPeriod.Semester:
                    numberOfPeriodsPerYear = 2;
                    break;
                case InterestPeriod.Year:
                    numberOfPeriodsPerYear = 1;
                    break;
            }
            return numberOfPeriodsPerYear;
        }
    }
}
