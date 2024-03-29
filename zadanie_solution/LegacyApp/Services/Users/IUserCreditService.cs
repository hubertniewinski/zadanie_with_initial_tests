using System;

namespace LegacyApp.Services.Users
{
    internal interface IUserCreditService : IDisposable
    {
        int GetCreditLimit(string lastName);
    }
}