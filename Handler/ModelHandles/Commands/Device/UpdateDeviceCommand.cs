using Autofac;
using DeviceRental.Infrastructure;
using DeviceRental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRental.Handler.ModelHandles.Commands.Device
{
    public class UpdateDeviceCommand : ICommand
    {
        public Models.Device Device { get; set; }
    }

    public class UpdateDeviceCommandHandler
    {
        private readonly IDeviceRepository _deviceRepository;
        private IUnitOfWork _unitOfWork;

        public UpdateDeviceCommandHandler()
        {
            _deviceRepository = Program.Container.Resolve<IDeviceRepository>();
            _unitOfWork = Program.Container.Resolve<IUnitOfWork>();
        }

        public async Task<ResultObject> Handle(ICommand command)
        {
            var updateDeviceCommand = command as UpdateDeviceCommand;
            var device = _deviceRepository.GetSingleById(updateDeviceCommand.Device.Id);

            device.DeviceName = updateDeviceCommand.Device.DeviceName;
            device.Price = updateDeviceCommand.Device.Price;
            device.Quantity = updateDeviceCommand.Device.Quantity;
            _deviceRepository.Update(device);

            _unitOfWork.Commit();

            return new ResultObject() { IsSuccess = true };
        }
    }
}
