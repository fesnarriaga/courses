namespace SOLID
{
    public class CustomerService
    {
        public string Add(Customer customer)
        {
            if (!customer.Validate())
                return "Invalid data";

            var repository = new CustomerRepository();
            repository.Add(customer);

            EmailService.Send("company@company.com", customer.Email.Address, "Welcome", "You are member");

            return "Customer registered";
        }
    }
}
