using OrderProject.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace OrderProject;

[DependsOn(
    typeof(OrderProjectEntityFrameworkCoreTestModule)
    )]
public class OrderProjectDomainTestModule : AbpModule
{

}
