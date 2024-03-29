namespace LegacyApp
{
    public class Client
    {
        public int ClientId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Type { get; private set; }

        public Client(int clientId, string name, string email, string address, string type)
        {
            ClientId = clientId;
            Name = name;
            Email = email;
            Address = address;
            Type = type;
        }
    }
}