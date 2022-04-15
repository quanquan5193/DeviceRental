using DeviceRental.Infrastructure;

namespace DeviceRental.Repositories
{
    public interface IDeviceRentalRepository : IRepository<Models.DeviceRental>
    {
        //ApplicationDbContext DbContext { get; }
    }

    public class DeviceRentalRepository : RepositoryBase<Models.DeviceRental>, IDeviceRentalRepository
    {
        //public new ApplicationDbContext DbContext { get => base.DbContext; }
        public DeviceRentalRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}