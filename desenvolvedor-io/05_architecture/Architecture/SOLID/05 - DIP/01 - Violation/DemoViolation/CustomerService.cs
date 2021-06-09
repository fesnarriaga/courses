namespace SOLID.DemoViolation
{
    public class CustomerService
    {
        public string AddCustomer(Customer customer)
        {
            if (!customer.Validate())
                return "Validation fails";

            var repo = new CustomerRepository();
            repo.AddCustomer(customer);

            EmailService.Send("a@a.com", customer.Email.Address, "Welcome", "Body");

            return "Customer registered";
        }
    }
}
