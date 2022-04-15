using Autofac;
using DeviceRental.Repositories;
using System.Threading.Tasks;

namespace DeviceRental.Handler.ModelHandles.Queries
{
    public class GetListDeviceRentalQuery : ICommand
    {
    }
    public class GetListDeviceRentalQueryHandler
    {
        private readonly IDeviceRentalRepository _deviceRentalRepository;

        public GetListDeviceRentalQueryHandler()
        {
            _deviceRentalRepository = Program.Container.Resolve<IDeviceRentalRepository>();
        }

        public async Task<ResultObject> Handle(ICommand command)
        {
            var result = await _deviceRentalRepository.
                GetAll(new string[] { nameof(Models.DeviceRental.Device), nameof(Models.DeviceRental.Employee) });
            return new ResultObject() { IsSuccess = true, Result = result };
        }
    }
}
