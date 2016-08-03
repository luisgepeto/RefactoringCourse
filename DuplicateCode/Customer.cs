using System.Collections.Generic;

namespace Refactoring
{
    public class Customer
    {
        //Data class - POCO
        public Customer()
        {
            PersonalAccounts = new List<Account>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public List<Account> PersonalAccounts { get; set; }
    }
}
