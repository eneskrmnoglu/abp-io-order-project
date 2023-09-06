using Volo.Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using Volo.Abp.MultiTenancy;

public class OrderMaster : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid CustomerId { get; set; } // Foreign Key
    public virtual Customer Customer { get; set; } // Navigation property
    public DateTime OrderDate { get; set; }
    public string ShippingAddress { get; set; }
    public bool IsApproved { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    public Guid? TenantId {  get; set; }
}
