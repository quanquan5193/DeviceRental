using Autofac;
using DeviceRental.Common;
using DeviceRental.Handler;
using DeviceRental.Handler.ModelHandles.Commands.Device;
using System;
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
            lbDevice.Text = _isUpdate ? "Device" : "New Device";
            btnSubmit.Text = _isUpdate ? "Update" : "Create";
            btnDelete.Visible = _isUpdate;
            btnName.Text = _device.DeviceName;
            btnPrice.Text = _device.Price.ToString();
            btnQuantity.Text = _device.Quantity.ToString();
        }

        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (_isUpdate)
                {
                    Log.Info($"{Common.Common.GetCurrentMethod()}: Start update Device");
                    await _handlerRegister.Send(new UpdateDeviceCommand() { Device = _device });
                    Log.Info($"{Common.Common.GetCurrentMethod()}: Complete update Device");
                }
                else
                {
                    Log.Info($"{Common.Common.GetCurrentMethod()}: Start create Device");
                    var reuslt = await _handlerRegister.Send(new CreateDeviceCommand() { Device = _device });
                    if (reuslt.IsSuccess) { _device.Id = (int)(reuslt.Result); }
                    btnDelete.Visible = true;
                    Log.Info($"{Common.Common.GetCurrentMethod()}: Complete update Device");
                }
                MessageBox.Show(Common.Common.Success);
            }
            catch (Exception ex)
            {
                Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Log.Info($"{Common.Common.GetCurrentMethod()}: Start delete Device");
                var result = await _handlerRegister.Send(new DeleteDeviceCommand() { Id = _device.Id });
                if (!result.IsSuccess)
                {
                    Log.Info($"{Common.Common.GetCurrentMethod()}: Complete delete Device");
                    MessageBox.Show(Common.Common.Failed);
                }
                else
                {
                    Close();
                    Log.Info($"{Common.Common.GetCurrentMethod()}: Failed to delete Device");
                    MessageBox.Show(Common.Common.Success);
                }
            }
            catch (Exception ex)
            {
                Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
                MessageBox.Show(ex.Message);
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
