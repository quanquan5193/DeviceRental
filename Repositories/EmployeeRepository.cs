using DeviceRental.Infrastructure;
using DeviceRental.Models;

namespace DeviceRental.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
