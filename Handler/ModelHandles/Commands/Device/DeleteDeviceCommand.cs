using Autofac;
using DeviceRental.Infrastructure;
using DeviceRental.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceRental.Handler.ModelHandles.Commands.Device
{
    public class DeleteDeviceCommand : ICommand
    {
        public int Id { get; set; }
    }

    public class DeleteDeviceCommandHandler
    {
        private readonly IDeviceRepository _deviceRepository;
        private IUnitOfWork _unitOfWork;

        public DeleteDeviceCommandHandler()
        {
            _deviceRepository = Program.Container.Resolve<IDeviceRepository>();
            _unitOfWork = Program.Container.Resolve<IUnitOfWork>();
        }

        public async Task<ResultObject> Handle(ICommand command)
        {
            var reuslt = new ResultObject();
            var deleteDeviceCommand = command as DeleteDeviceCommand;
            var device = await _deviceRepository.GetSingleByCondition(x => x.Id == deleteDeviceCommand.Id, new string[] { "DeviceRentals" });
            if (device.DeviceRentals.Any())
            {
                return reuslt;
            }
            _deviceRepository.Delete(deleteDeviceCommand.Id);
            _unitOfWork.Commit();

            reuslt.IsSuccess = true;
            return reuslt;
        }
    }
}
