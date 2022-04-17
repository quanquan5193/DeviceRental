using Autofac;
using DeviceRental.Infrastructure;
using DeviceRental.Repositories;
using System.Threading.Tasks;

namespace DeviceRental.Handler.ModelHandles
{
    public class UpdateDeviceRentalCommand : ICommand
    {
        public Models.DeviceRental DeviceRental { get; set; }
    }

    public class UpdateDeviceRentalCommandHandler
    {
        private readonly IDeviceRentalRepository _deviceRentalRepository;
        private IUnitOfWork _unitOfWork;

        public UpdateDeviceRentalCommandHandler()
        {
            _deviceRentalRepository = Program.Container.Resolve<IDeviceRentalRepository>();
            _unitOfWork = Program.Container.Resolve<IUnitOfWork>();
        }

        public async Task<ResultObject> Handle(ICommand command)
        {
            var updateDeviceCommand = command as UpdateDeviceRentalCommand;

            var deviceRental = await _deviceRentalRepository.
                GetSingleByCondition(x => x.DeviceId == updateDeviceCommand.DeviceRental.DeviceId
                && x.EmployeeId == updateDeviceCommand.DeviceRental.EmployeeId);

            deviceRental.EndDate = updateDeviceCommand.DeviceRental.EndDate;
            _deviceRentalRepository.Update(deviceRental);
            _unitOfWork.Commit();

            return new ResultObject() { IsSuccess = true };
        }
    }
}
