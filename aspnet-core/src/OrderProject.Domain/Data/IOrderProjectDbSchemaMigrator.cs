using System.Threading.Tasks;

namespace OrderProject.Data;

public interface IOrderProjectDbSchemaMigrator
{
    Task MigrateAsync();
}
