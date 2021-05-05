using SOLID.DemoSolution.Interfaces;

namespace SOLID.DemoSolution
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerService(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public string AddCustomer(Customer customer)
        {
            if (!customer.Validate())
                return "Validation fails";

            _customerRepository.AddCustomer(customer);

            _emailService.Send("a@a.com", customer.Email.Address, "Welcome", "Message");

            return "Customer registered";
        }
    }
}
