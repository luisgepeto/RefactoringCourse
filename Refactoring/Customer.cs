using System.Collections.Generic;

namespace Refactoring
{
    public class Customer
    {
        //12 data class
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
