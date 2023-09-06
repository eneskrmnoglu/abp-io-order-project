using Volo.Abp.Domain.Entities;
using System;
using Volo.Abp.MultiTenancy;

public class OrderDetail : Entity<Guid>, IMultiTenant
{
    public string StockInfo { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
    public Guid OrderMasterId { get; set; }  // Foreign Key
    public virtual OrderMaster OrderMaster { get; set; } // Navigation property
    public Guid? TenantId { get; set; }
}
