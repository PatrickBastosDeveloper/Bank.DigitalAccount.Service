using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public class Customer
    {
        public Customer(int customerId, string externalId, string name, string cpf, string address, string telephone, string email)
        {
            CustomerId = customerId;
            ExternalId = externalId;
            Name = name;
            CPF = NormalizeCpf(cpf);
            Address = address;
            Telephone = telephone;
            Email = email;
        }

        public Customer(string name, string cpf, string address, string telephone, string email, string? externalId = null)
        {
            ExternalId = externalId ?? Guid.NewGuid().ToString();
            Name = name;
            CPF = NormalizeCpf(cpf);
            Address = address;
            Telephone = telephone;
            Email = email;
        }

        public int CustomerId { get; private set; }
        public string ExternalId { get; private set; }
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Address { get; private set; }
        public string Telephone { get; private set; }
        public string Email { get; private set; }

        private string NormalizeCpf(string cpf)
        {
            return Regex.Replace(cpf, @"\D", ""); // remove tudo que não for número
        }
    }
}
