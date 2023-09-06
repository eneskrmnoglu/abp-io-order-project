using Volo.Abp.Domain.Entities;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities.Auditing;

public class Customer : AuditedAggregateRoot<Guid>, IMultiTenant
{
    public string CustomerName { get; set; }
    public decimal RiskLimit { get; set; }
    public string BillingAddress { get; set; }
    public Guid? TenantId {  get; set; }
}