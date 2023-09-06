using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace OrderProject
{
    public class OrderProjectDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Customer, Guid> _customerRepository;

        public OrderProjectDataSeederContributor(IRepository<Customer, Guid> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _customerRepository.GetCountAsync() <= 0)
            {
                await _customerRepository.InsertAsync(
                    new Customer
                    {
                        CustomerName = "Enes Karamanoglu",
                        RiskLimit = 1000.50m,
                        BillingAddress = "123 Sample St, Sample City"
                    },
                    autoSave: true
                );

                await _customerRepository.InsertAsync(
                    new Customer
                    {
                        CustomerName = "Melek Atasoy",
                        RiskLimit = 1500.00m,
                        BillingAddress = "456 Example Rd, Example City"
                    },
                    autoSave: true
                );
            }
        }
    }
}
