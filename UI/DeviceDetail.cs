using Autofac;
using DeviceRental.Handler;
using DeviceRental.Handler.ModelHandles.Commands.Device;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceRental.UI
{
    public partial class DeviceDetail : Form
    {
        private readonly Models.Device _device;
        private readonly HandlerRegister _handlerRegister;
        private readonly bool _isUpdate = false;

        public DeviceDetail(Models.Device device = null)
        {
            _isUpdate = device != null;
            _handlerRegister = Program.Container.Resolve<HandlerRegister>();
            InitializeComponent();
            
            _device = device ?? new Models.Device();
            InitDefautConfig();
        }

        private void InitDefautConfig()
        {
            this.lbDevice.Text = _isUpdate ? "Device" : "New Device";
            this.btnSubmit.Text = _isUpdate ? "Update" : "Create";
            this.btnDelete.Visible = _isUpdate;
            this.btnName.Text = _device.DeviceName;
            this.btnPrice.Text = _device.Price.ToString();
            this.btnQuantity.Text = _device.Quantity.ToString();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            if (_isUpdate)
            {
                await _handlerRegister.Send(new UpdateDeviceCommand() { Device = _device });
            }
            else
            {
                var reuslt = await _handlerRegister.Send(new CreateDeviceCommand() { Device = _device });
                if (reuslt.IsSuccess) { _device.Id = (int)(reuslt.Result); }
                this.btnDelete.Visible = true;
            }
            MessageBox.Show(Common.Common.Success);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var result = await _handlerRegister.Send(new DeleteDeviceCommand() { Id = _device.Id });
            if (!result.IsSuccess)
            {
                MessageBox.Show(Common.Common.Failed);
            }
            else
            {
                this.Close();
                MessageBox.Show(Common.Common.Success);
            }
        }

        private void btnName_TextChanged(object sender, EventArgs e)
        {
            _device.DeviceName = btnName.Text;
        }

        private void btnPrice_TextChanged(object sender, EventArgs e)
        {
            _device.Price = double.Parse(btnPrice.Text);
        }

        private void btnQuantity_TextChanged(object sender, EventArgs e)
        {
            _device.Quantity = int.Parse(btnQuantity.Text);
        }

        private void btnPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
