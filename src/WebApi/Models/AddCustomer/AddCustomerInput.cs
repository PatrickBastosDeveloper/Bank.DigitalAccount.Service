namespace WebApi.Models.AddCustomer
{
    public class AddCustomerInput
    {
        public int CustomerId { get; set; }
        public string ExternalId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
    }
}
