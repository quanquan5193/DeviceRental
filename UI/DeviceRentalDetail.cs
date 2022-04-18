using Autofac;
using DeviceRental.Common;
using DeviceRental.Handler;
using DeviceRental.Handler.ModelHandles;
using System;
using System.Windows.Forms;

namespace DeviceRental
{
    public partial class DeviceRentalDetail : Form
    {
        private readonly Models.DeviceRental _deviceRental;
        private readonly HandlerRegister _handlerRegister;

        public DeviceRentalDetail(Models.DeviceRental deviceRental)
        {
            InitializeComponent();
            _deviceRental = deviceRental;
            _handlerRegister = Program.Container.Resolve<HandlerRegister>();
        }

        private void DeviceRentalDetail_Load(object sender, EventArgs e)
        {
            try
            {
                txtDevice.Text = _deviceRental.Device.DeviceName;
                txtEmployee.Text = _deviceRental.Employee.Name;
                dpkStartDate.Value = _deviceRental.StartDate;
                if (!_deviceRental.EndDate.HasValue)
                {
                    dpkEndDate.Format = DateTimePickerFormat.Custom;
                    dpkEndDate.CustomFormat = " ";
                }
                else
                {
                    dpkEndDate.Value = _deviceRental.EndDate ?? DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
            }
        }

        private void dpkEndDate_ValueChanged(object sender, EventArgs e)
        {
            dpkEndDate.Format = DateTimePickerFormat.Short;
            _deviceRental.EndDate = dpkEndDate.Value = ((DateTimePicker)sender).Value;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Log.Info($"{Common.Common.GetCurrentMethod()}: Start update Device Rental");
                var data = await _handlerRegister.Send(new UpdateDeviceRentalCommand() { DeviceRental = _deviceRental });

                Close();
                MessageBox.Show(Common.Common.Success);
                if (data.IsSuccess)
                {
                    Log.Info($"{Common.Common.GetCurrentMethod()}: Complete update Device Rental");
                }
                else
                {
                    Log.Error($"{Common.Common.GetCurrentMethod()}: Failed to update Device Rental");
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
