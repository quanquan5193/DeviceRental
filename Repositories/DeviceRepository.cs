using DeviceRental.Infrastructure;
using DeviceRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
