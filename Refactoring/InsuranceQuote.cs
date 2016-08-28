namespace Refactoring
{
    public class InsuranceQuote
    {
        private Driver Driver { get; set; }

        public InsuranceQuote(Driver driver)
        {
            Driver = driver;
        }

        public RiskFactor CalculateDriverRiskFactor()
        {
            if (Driver.GetLicense().GetPointsOnLicense() > 3 || Driver.GetAge() < 25)
                return RiskFactor.High;

            if (Driver.GetLicense().GetPointsOnLicense() > 0)
                return RiskFactor.Moderate;

            return RiskFactor.Low;
        }

        public double CalculateInsurancePremium(double insuranceValue)
        {
            return insuranceValue*CalculateDriverRiskFactor().RiskMultiplier();
        }
    }

    public enum RiskFactor
    {
        Low,
        Moderate,
        High
    }

    public static partial class Extensions
    {
        public static double RiskMultiplier(this RiskFactor riskFactor)
        {
            double riskMultiplier = 0;
            switch (riskFactor)
            {
                case RiskFactor.Low:
                    riskMultiplier = 0.02;
                    break;
                case RiskFactor.Moderate:
                    riskMultiplier = 0.04;
                    break;
                case RiskFactor.High:
                    riskMultiplier = 0.06;
                    break;
            }
            return riskMultiplier;
        }

    }
}
