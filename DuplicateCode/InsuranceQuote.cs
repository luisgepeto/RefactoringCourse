namespace DuplicatedCode
{
    public class InsuranceQuote
    {
        private Driver Driver { get; set; }

        public InsuranceQuote(Driver driver)
        {
            Driver = driver;
        }

        //Feature Envy - Move Method
        public RiskFactor CalculateDriverRiskFactor()
        {
            if (Driver.GetPointsOnLicense() > 3 || Driver.GetAge() < 25)
                return RiskFactor.High;

            if (Driver.GetPointsOnLicense() > 0)
                return RiskFactor.Moderate;

            return RiskFactor.Low;
        }
        //Feature Envy - Move Method
        public double CalculateInsurancePremium(double insuranceValue)
        {
            var riskFactor = CalculateDriverRiskFactor();
            //Switch Statements - Try to add case -  make extension method class along with enum
            switch (riskFactor)
            {
                case RiskFactor.Low:
                    return insuranceValue * 0.02;
                case RiskFactor.Moderate:
                    return insuranceValue * 0.04;
                case RiskFactor.High:
                    return insuranceValue * 0.06;
            }
            return insuranceValue;
        }


    }
}
