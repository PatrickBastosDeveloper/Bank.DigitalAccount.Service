namespace Domain.Entities
{
    public class Customer
    {
        public Customer(string name, string email, string documents)
        {
            Name = name;
            Email = email;
            Documents = documents;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Documents { get; private set; }

    }
}
