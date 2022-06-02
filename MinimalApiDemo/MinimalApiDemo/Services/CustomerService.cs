using MinimalApiDemo.Models;

namespace MinimalApiDemo.Services
{
    public class CustomerService
    {
        public async Task<List<Customer>> GetCustomersAsync()
        {
            await Task.Delay(1000);
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe" },
                new Customer { Id = 2, Name = "Jane Doe" },
            };
        }

        public async Task<Customer?> GetCustomerAsync(int id)
        {
            //This is obviously not how you would solve this in a real world scenario =)
            var customers = await GetCustomersAsync();
            return customers.FirstOrDefault(c => c.Id == id);
        }
    }
}
