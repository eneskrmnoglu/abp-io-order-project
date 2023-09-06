using OrderProject.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OrderProject.Customers
{
    public class CustomerAppService :
        CrudAppService<
            Customer, // The Customer entity
            CustomerDto, // Used to show customers
            Guid, // Primary key of the customer entity
            PagedAndSortedResultRequestDto, // Used for paging/sorting
            CreateUpdateCustomerDto>, // Used to create/update a customer
        ICustomerAppService // implement the ICustomerAppService
    {
        public CustomerAppService(IRepository<Customer, Guid> repository)
            : base(repository)
        {
            GetPolicyName = OrderProjectPermissions.Customers.Default;
            GetListPolicyName = OrderProjectPermissions.Customers.Default;
            CreatePolicyName = OrderProjectPermissions.Customers.Create;
            UpdatePolicyName = OrderProjectPermissions.Customers.Edit;
            DeletePolicyName = OrderProjectPermissions.Customers.Delete;
        }
    }
}
