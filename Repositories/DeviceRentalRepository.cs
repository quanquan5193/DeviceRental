using DeviceRental.Database;
using DeviceRental.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRental.Repositories
{
    public interface IDeviceRentalRepository : IRepository<Models.DeviceRental>
    {
        ApplicationDbContext DbContext { get; }
    }

    public class DeviceRentalRepository : RepositoryBase<Models.DeviceRental>, IDeviceRentalRepository
    {
        public ApplicationDbContext DbContext { get => base.DbContext; }
        public DeviceRentalRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}