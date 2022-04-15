using Autofac;
using DeviceRental.Repositories;
using System.Threading.Tasks;

namespace DeviceRental.Handler.ModelHandles.Queries
{
    public class GetListDeviceQuery : ICommand
    {
    }

    public class GetListDeviceQueryHandler
    {
        private readonly IDeviceRepository _deviceRepository;

        public GetListDeviceQueryHandler()
        {
            _deviceRepository = Program.Container.Resolve<IDeviceRepository>();
        }
        public async Task<ResultObject> Handle(ICommand command)
        {
            var result = await _deviceRepository.GetAll();
            return new ResultObject() { IsSuccess = true, Result = result };
        }
    }
}
