using System;
using LegacyApp.Models.Clients;
using LegacyApp.Services.Users;

namespace LegacyApp.Extensions.UserExtensions
{
    public static class UserExtensions
	{
        public static void AssignCreditConditions(this User user)
        {
            var clientType = (user.Client as Client).Type;

            if (clientType == ClientType.ImportantClient)
            {
                user.AssignCreditLimit(creditLimit => creditLimit * 2);
            }
            else if(clientType != ClientType.VeryImportantClient)
            {
                user.SetHasCreditLimit(true);
                user.AssignCreditLimit();
            }
        }

        private static void AssignCreditLimit(this User user, Func<int, int>? creditLimitTransformation = default)
        {
            using var userCreditService = new UserCreditService() as IUserCreditService;
            int creditLimit = userCreditService.GetCreditLimit(user.LastName);
            if (creditLimitTransformation is not null)
            {
                creditLimit = creditLimitTransformation(creditLimit);
            }
            user.SetCreditLimit(creditLimit);
        }
    }
}