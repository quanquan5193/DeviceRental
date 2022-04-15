using Autofac;
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

        private void dpkEndDate_ValueChanged(object sender, EventArgs e)
        {
            dpkEndDate.Format = DateTimePickerFormat.Short;
            _deviceRental.EndDate = dpkEndDate.Value = ((DateTimePicker)sender).Value;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var data = await _handlerRegister.Send(new UpdateDeviceCommand() { DeviceRental = _deviceRental });

            this.Close();
            MessageBox.Show("Data was changed");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
