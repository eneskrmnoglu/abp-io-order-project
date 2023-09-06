using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace OrderProject.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class OrderProjectDbContext :
    AbpDbContext<OrderProjectDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Customer> Customers { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<OrderMaster> OrderMasters { get; set; }
    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public OrderProjectDbContext(DbContextOptions<OrderProjectDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        //builder.Entity<YourEntity>(b =>
        //{
        //    b.ToTable(OrderProjectConsts.DbTablePrefix + "YourEntities", OrderProjectConsts.DbSchema);
        //    b.ConfigureByConvention(); //auto configure for the base class props
        //    //...
        //});

        // Customer entity mapping
        builder.Entity<Customer>(b =>
        {
            b.ToTable(OrderProjectConsts.DbTablePrefix + "Customers",
                      OrderProjectConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.CustomerName).IsRequired().HasMaxLength(200);
            b.Property(x => x.RiskLimit).HasPrecision(18, 2);
            b.Property(x => x.BillingAddress).HasMaxLength(500);
        });

        // OrderDetail entity mapping
        builder.Entity<OrderDetail>(b =>
        {
            b.ToTable(OrderProjectConsts.DbTablePrefix + "OrderDetails",
                      OrderProjectConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.StockInfo).IsRequired().HasMaxLength(200);
            b.Property(x => x.Quantity).IsRequired();
            b.Property(x => x.TotalAmount).HasPrecision(18, 2);
            b.HasOne(x => x.OrderMaster)
                .WithMany(y => y.OrderDetails)
                .HasForeignKey(z => z.OrderMasterId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // OrderMaster entity mapping
        builder.Entity<OrderMaster>(b =>
        {
            b.ToTable(OrderProjectConsts.DbTablePrefix + "OrderMasters",
                      OrderProjectConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.OrderDate);
            b.Property(x => x.ShippingAddress).HasMaxLength(500);
            b.Property(x => x.IsApproved).IsRequired();
            b.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(y => y.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
