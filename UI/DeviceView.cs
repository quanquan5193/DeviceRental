using Autofac;
using DeviceRental.Common;
using DeviceRental.Handler;
using DeviceRental.Handler.ModelHandles.Queries;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DeviceRental.UI
{
    public partial class DeviceView : Form
    {
        private readonly HandlerRegister _handlerRegister;

        public DeviceView()
        {
            InitializeComponent();

            _handlerRegister = Program.Container.Resolve<HandlerRegister>();
        }

        private async void DeviceView_Load(object sender, EventArgs e)
        {
            try
            {
                var devices = (await _handlerRegister.Send(new GetListDeviceQuery())).Result as IEnumerable<Models.Device>;

                // Device view
                dgvDevice.DataSource = devices;
                dgvDevice.Columns[nameof(Models.Device.Id)].Visible = false;
                dgvDevice.Columns[nameof(Models.Device.DeviceRentals)].Visible = false;
            }
            catch (Exception ex)
            {
                Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
            }
        }

        private void dgvDevice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedItem = dgvDevice.SelectedRows[0].DataBoundItem as Models.Device;
                var detail = new DeviceDetail(selectedItem);
                detail.FormClosed += DeviceView_Load;
                detail.Show();
            }
            catch (Exception ex)
            {
                Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var detail = new DeviceDetail();
                detail.FormClosed += DeviceView_Load;
                detail.Show();
            }
            catch (Exception ex)
            {
                Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
