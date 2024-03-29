using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using LegacyApp.Models.Clients;

namespace LegacyApp.Repositories.Clients
{
    internal class ClientRepository : IClientRepository
    {
        /// <summary>
        /// This collection is used to simulate remote database
        /// </summary>
        private static readonly IEnumerable<Client> _database = new List<Client>()
        {
            new Client(1, "Kowalski", "kowalski@wp.pl", "Warszawa, Złota 12", ClientType.NormalClient),
            new Client(2, "Malewski", "malewski@gmail.pl", "Warszawa, Koszykowa 86", ClientType.VeryImportantClient),
            new Client(3, "Smith", "smith@gmail.pl", "Warszawa, Kolorowa 22", ClientType.ImportantClient),
            new Client(4, "Doe", "doe@gmail.pl", "Warszawa, Koszykowa 32", ClientType.ImportantClient),
            new Client(5, "Kwiatkowski", "kwiatkowski@wp.pl", "Warszawa, Złota 52", ClientType.NormalClient ),
            new Client(6, "Andrzejewicz", "andrzejewicz@wp.pl", "Warszawa, Koszykowa 52", ClientType.NormalClient)
        };

        /// <summary>
        /// Simulating fetching a client from remote database
        /// </summary>
        /// <returns>Returning client object</returns>
        public Client GetById(int id)
        {
            int randomWaitTime = new Random().Next(2000);
            Thread.Sleep(randomWaitTime);

            var client = _database.FirstOrDefault(x => x.ClientId == id);

            if (client is null)
            {
                throw new ArgumentException($"User with id {id} does not exist in database");
            }

            return client;
        }
    }
}