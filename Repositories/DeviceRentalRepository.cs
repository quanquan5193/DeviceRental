using DeviceRental.Infrastructure;

namespace DeviceRental.Repositories
{
    public interface IDeviceRentalRepository : IRepository<Models.DeviceRental>
    {
    }

    public class DeviceRentalRepository : RepositoryBase<Models.DeviceRental>, IDeviceRentalRepository
    {
        public DeviceRentalRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}