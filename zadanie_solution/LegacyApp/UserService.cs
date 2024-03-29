using System;
using LegacyApp.Extensions.UserExtensions;
using LegacyApp.Repositories.Clients;
using LegacyApp.Validation.Users;

namespace LegacyApp
{
    public class UserService
    {
        private readonly IClientRepository _clientRepository;

        public UserService() => _clientRepository = new ClientRepository();

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if(UserValidator.InputValidationFailed(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }

            var user = GetUser();
            user.AssignCreditConditions();

            if (UserValidator.CreditLimitValidationFailed(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;

            User GetUser()
            {
                var client = _clientRepository.GetById(clientId);
                return new User(client, dateOfBirth, email, firstName, lastName);
            }
        }
    }
}