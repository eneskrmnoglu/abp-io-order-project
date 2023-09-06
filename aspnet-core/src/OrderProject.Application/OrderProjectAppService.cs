using System;
using System.Collections.Generic;
using System.Text;
using OrderProject.Localization;
using Volo.Abp.Application.Services;

namespace OrderProject;

/* Inherit your application services from this class.
 */
public abstract class OrderProjectAppService : ApplicationService
{
    protected OrderProjectAppService()
    {
        LocalizationResource = typeof(OrderProjectResource);
    }
}
