﻿using System;

namespace DuplicatedCode
{
    public abstract class InvestmentTransaction : Transaction
    {
        protected InvestmentTransaction(bool isDebit, decimal amount) : base(isDebit, amount)
        {
        }
        //Speculative Generality
        public string InvestmentFundName { get; set; }
        public string InvestmentPeriod { get; set; }

        public string GetSummary()
        {
            return String.Format("This is an investment transaction for ${0} in fund {1} for {2} period", Amount, InvestmentFundName, InvestmentPeriod);
        }
    }
}
