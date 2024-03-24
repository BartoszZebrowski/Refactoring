using System;

namespace LegacyApp
{
    public class User
    {
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public bool HasCreditLimit { get; internal set; }
        public int CreditLimit { get; internal set; }

        public User(string firstName, string lastName, string emailAdress, DateTime dateOfBirth, object client) 
        {
            if (!Validate(firstName, lastName, emailAdress, dateOfBirth, client))
                throw new Exception("Wrong user data");

            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAdress;
            DateOfBirth = dateOfBirth;
            Client = client;
        }

        public bool CheckBudgetLimit() // zmienic nazwe 
            => HasCreditLimit && CreditLimit < 500;

        private bool Validate(string firstName, string lastName, string emailAdress, DateTime dateOfBirth, object client)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return false;

            if (!emailAdress.Contains("@") && !emailAdress.Contains("."))
                return false;

            DateTime.Now.Subtract(dateOfBirth);

            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) 
                age--;

            if (age < 21)
                return false;

            return true;
        }
    }
}