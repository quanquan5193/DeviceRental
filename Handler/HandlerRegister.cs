using DeviceRental.Common;
using DeviceRental.Handler.ModelHandles;
using DeviceRental.Handler.ModelHandles.Commands.Device;
using DeviceRental.Handler.ModelHandles.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        /// <summary>
        /// Invoke the corresponding hanlder for command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<ResultObject> Send(ICommand command)
        {
            Type type = command.GetType();

            try
            {
                if (_formHandler.ContainsKey(type))
                {
                    ResultObject result = null;
                    try
                    {
                        result = await _formHandler[type].Invoke(command);
                        return result;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
                        return null;
                    }
                }
                else
                {
                    Log.Error($"{Common.Common.GetCurrentMethod()}: No handler was founded");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
                MessageBox.Show(ex.Message);
                return null;
            }
        }
    }
}
