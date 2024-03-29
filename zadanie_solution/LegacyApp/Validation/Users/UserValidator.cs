using System;

namespace LegacyApp.Validation.Users
{
    public static class UserValidator
    {
        public static bool InputValidationFailed(string firstName, string lastName, string email, DateTime dateOfBirth) =>
            FullNameValidationFailed(firstName, lastName) ||
            EmailValidationFailed(email) ||
            DateOfBirthValidationFailed(dateOfBirth);

        public static bool CreditLimitValidationFailed(User user)
            => user.HasCreditLimit && user.CreditLimit < 500;

        private static bool FullNameValidationFailed(string firstName, string lastName)
            => string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName);

        private static bool EmailValidationFailed(string email)
            => !(email.Contains("@") && email.Contains("."));

        private static bool DateOfBirthValidationFailed(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            var age = now.Year - dateOfBirth.Year;

            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            {
                age--;
            }

            return age < 21;
        }
    }
}

