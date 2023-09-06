using System;
using System.Linq;
using System.Threading.Tasks;
using OrderProject;
using OrderProject.Customers;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace Acme.OrderProject.Customers
{
    public class CustomerAppService_Tests : OrderProjectApplicationTestBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerAppService_Tests()
        {
            _customerAppService = GetRequiredService<ICustomerAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Customers()
        {
            // Act
            var result = await _customerAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            // Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(c => c.CustomerName == "Enes Karamanoglu");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Customer()
        {
            // Act
            var result = await _customerAppService.CreateAsync(
                new CreateUpdateCustomerDto
                {
                    CustomerName = "New Customer 42",
                    RiskLimit = 1000,
                    BillingAddress = "Test Address",
                }
            );

            // Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.CustomerName.ShouldBe("New Customer 42");
        }

        [Fact]
        public async Task Should_Not_Create_A_Customer_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _customerAppService.CreateAsync(
                    new CreateUpdateCustomerDto
                    {
                        CustomerName = "",
                        RiskLimit = 1000,
                        BillingAddress = "Test Address",
                        // TenantId'i gerektiğinde ekleyebilirsiniz.
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "CustomerName"));
        }


    }
}

