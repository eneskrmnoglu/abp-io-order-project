using Volo.Abp.Modularity;

namespace OrderProject;

[DependsOn(
    typeof(OrderProjectApplicationModule),
    typeof(OrderProjectDomainTestModule)
    )]
public class OrderProjectApplicationTestModule : AbpModule
{

}
