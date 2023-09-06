using AutoMapper;
using OrderProject.Customers;

namespace OrderProject;

public class OrderProjectApplicationAutoMapperProfile : Profile
{
    public OrderProjectApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Customer, CustomerDto>();
        CreateMap<CreateUpdateCustomerDto, Customer>();
    }
}
