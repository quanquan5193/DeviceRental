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
    public class CreateDeviceCommand : ICommand
    {
        public Models.Device Device { get; set; }
    }

    public class CreateDeviceCommandHandler
    {
        private readonly IDeviceRepository _deviceRepository;
        private IUnitOfWork _unitOfWork;

        public CreateDeviceCommandHandler()
        {
            _deviceRepository = Program.Container.Resolve<IDeviceRepository>();
            _unitOfWork = Program.Container.Resolve<IUnitOfWork>();
        }

        public async Task<ResultObject> Handle(ICommand command)
        {
            var createDeviceCommand = command as CreateDeviceCommand;
            _deviceRepository.Add(createDeviceCommand.Device);

            _unitOfWork.Commit();

            return new ResultObject() { IsSuccess = true, Result = createDeviceCommand.Device.Id };
        }
    }
}
