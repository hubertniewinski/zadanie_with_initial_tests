using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string EmailAddress { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool HasCreditLimit { get; private set; }
        public int CreditLimit { get; private set; }

        private User() { }

        public User(object client, DateTime dateOfBirth, string emailAddress, string firstName, string lastName)
        {
            Client = client;
            DateOfBirth = dateOfBirth;
            EmailAddress = emailAddress;
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual void SetHasCreditLimit(bool hasCreditLimit) => HasCreditLimit = hasCreditLimit;

        public virtual void SetCreditLimit(int creditLimit) => CreditLimit = creditLimit;
    }
}