using DeviceRental.Infrastructure;
using DeviceRental.Models;

namespace DeviceRental.Repositories
{
    public interface IDeviceRepository : IRepository<Device>
    {
    }

    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
