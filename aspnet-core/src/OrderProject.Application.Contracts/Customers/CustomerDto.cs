using System;
using Volo.Abp.Application.Dtos;

public class CustomerDto : EntityDto<Guid>
{
    public string CustomerName { get; set; }
    public decimal RiskLimit { get; set; }
    public string BillingAddress { get; set; }
    public Guid? TenantId { get; set; }
}
