using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RefactoringTests
{
    [TestClass]
    public class InsuranceQuoteTests
    {
        [TestMethod]
        public void InsuranceQuote_CalculateDriverRiskFactor_4LicensePoints_ReturnsHigh()
        {
            //Arrange
            var driver = new Driver(DateTime.Now, 4, "LICNUMBER", DateTime.Now);
            var insuranceQuote = new InsuranceQuote(driver);
            //Act
            var riskFactor = insuranceQuote.CalculateDriverRiskFactor();
            //Arrange
            Assert.AreEqual(RiskFactor.High, riskFactor, "The risk factor should be HIGH for a Driver with more than 3 points in their license");
        }

        [TestMethod]
        public void InsuranceQuote_CalculateDriverRiskFactor_YoungerThan25Years_ReturnsHigh()
        {
            //Arrange
            var driver = new Driver(DateTime.Now, 0, "LICNUMBER", DateTime.Now);
            var insuranceQuote = new InsuranceQuote(driver);
            //Act
            var riskFactor = insuranceQuote.CalculateDriverRiskFactor();
            //Arrange
            Assert.AreEqual(RiskFactor.High, riskFactor, "The risk factor should be HIGH for a Driver younger than 25 years");
        }


        [TestMethod]
        public void InsuranceQuote_CalculateDriverRiskFactor_LessThan4PointsOlderThan25Years_ReturnsModerate()
        {
            //Arrange
            var driver = new Driver(new DateTime(1900, 1, 1), 3, "LICNUMBER", DateTime.Now);
            var insuranceQuote = new InsuranceQuote(driver);
            //Act
            var riskFactor = insuranceQuote.CalculateDriverRiskFactor();
            //Arrange
            Assert.AreEqual(RiskFactor.Moderate, riskFactor, "The risk factor should be Moderate for a Driver with less or equal than 3 points and older than 25 years");
        }

        [TestMethod]
        public void InsuranceQuote_CalculateDriverRiskFactor_LessThan1PointsOlderThan25Years_ReturnsLow()
        {
            //Arrange
            var driver = new Driver(new DateTime(1900, 1, 1), 0, "LICNUMBER", DateTime.Now);
            var insuranceQuote = new InsuranceQuote(driver);
            //Act
            var riskFactor = insuranceQuote.CalculateDriverRiskFactor();
            //Arrange
            Assert.AreEqual(RiskFactor.Low, riskFactor, "The risk factor should be Moderate for a Driver with less or equal than 0 points and older than 25 years");
        }


        [TestMethod]
        public void InsuranceQuote_CalculateInsurancePremium_HighRisk1000Insurance_Returns60()
        {
            //Arrange
            var driver = new Driver(DateTime.Now, 0, "LICNUMBER", DateTime.Now);
            var insuranceQuote = new InsuranceQuote(driver);
            //Act
            var insurancePremium = insuranceQuote.CalculateInsurancePremium(1000);
            //Arrange
            Assert.AreEqual(60, insurancePremium, "The insurance premium should be 20 for 1000 with high risk");
        }


        [TestMethod]
        public void InsuranceQuote_CalculateInsurancePremium_MediumRisk1000Insurance_Returns40()
        {
            //Arrange
            var driver = new Driver(new DateTime(1900, 1, 1), 3, "LICNUMBER", DateTime.Now);
            var insuranceQuote = new InsuranceQuote(driver);
            //Act
            var insurancePremium = insuranceQuote.CalculateInsurancePremium(1000);
            //Arrange
            Assert.AreEqual(40, insurancePremium, "The insurance premium should be 40 for 1000 with medium risk");
        }

        [TestMethod]
        public void InsuranceQuote_CalculateInsurancePremium_LowRisk1000Insurance_Returns20()
        {
            //Arrange
            var driver = new Driver(new DateTime(1900, 1, 1), 0, "LICNUMBER", DateTime.Now);
            var insuranceQuote = new InsuranceQuote(driver);
            //Act
            var insurancePremium = insuranceQuote.CalculateInsurancePremium(1000);
            //Arrange
            Assert.AreEqual(20, insurancePremium, "The insurance premium should be 20 for 1000 with low risk");
        }

    }
}
