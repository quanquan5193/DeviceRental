using DeviceRental.Handler.ModelHandles;
using DeviceRental.Handler.ModelHandles.Commands.Device;
using DeviceRental.Handler.ModelHandles.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceRental.Handler
{
    public class HandlerRegister
    {
        private readonly IDictionary<Type, Func<ICommand, Task<ResultObject>>> _formHandler;

        public HandlerRegister()
        {
            _formHandler = new Dictionary<Type, Func<ICommand, Task<ResultObject>>>
            {
                { typeof(GetListDeviceRentalQuery),  new GetListDeviceRentalQueryHandler().Handle},
                { typeof(GetListDeviceQuery),  new GetListDeviceQueryHandler().Handle},
                { typeof(GetListEmployeeQuery),  new GetListEmployeeQueryHandler().Handle},
                { typeof(UpdateDeviceRentalCommand),  new UpdateDeviceRentalCommandHandler().Handle},
                { typeof(UpdateDeviceCommand),  new UpdateDeviceCommandHandler().Handle},
                { typeof(CreateDeviceCommand),  new CreateDeviceCommandHandler().Handle},
                { typeof(DeleteDeviceCommand),  new DeleteDeviceCommandHandler().Handle}
            };
        }

        public async Task<ResultObject> Send(ICommand command)
        {
            Type type = command.GetType();

            try
            {
                if (_formHandler.ContainsKey(type))
                {
                    var result = await _formHandler[type].Invoke(command);
                    return result;
                }
                else
                {
                    return null;
                    // Log
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
