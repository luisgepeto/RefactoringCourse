﻿using System.Collections.Generic;

namespace Refactoring
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private string _title;
        private List<Account> _personalAccounts;

        public Customer()
        {
            PersonalAccounts = new List<Account>();
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public List<Account> PersonalAccounts
        {
            get { return _personalAccounts; }
            set { _personalAccounts = value; }
        }

        public void AddAccount(Account account)
        {
            
        }

        public Account RemoveAccount(Account account)
        {
            return null;
        }
    }
}
