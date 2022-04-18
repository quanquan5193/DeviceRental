using Autofac;
using DeviceRental.Common;
using DeviceRental.Handler;
using DeviceRental.Handler.ModelHandles.Queries;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DeviceRental
{
    public partial class DeviceRentalView : Form
    {
        private readonly HandlerRegister _handlerRegister;

        public DeviceRentalView()
        {
            InitializeComponent();

            _handlerRegister = Program.Container.Resolve<HandlerRegister>();
        }

        private async void DeviceRentalView_Load(object sender, EventArgs e)
        {
            try
            {
                var deviceRentals = (await _handlerRegister.Send(new GetListDeviceRentalQuery())).Result as IEnumerable<Models.DeviceRental>;

                // Device Rental view
                dgvDeviceRental.DataSource = deviceRentals;
                dgvDeviceRental.Columns[nameof(Models.DeviceRental.Device)].Visible = false;
                dgvDeviceRental.Columns[nameof(Models.DeviceRental.Employee)].Visible = false;
            }
            catch (Exception ex)
            {
                Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
            }
        }

        private void dgvDeviceRental_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedItem = dgvDeviceRental.SelectedRows[0].DataBoundItem as Models.DeviceRental;
                var detail = new DeviceRentalDetail(selectedItem);
                detail.FormClosed += DeviceRentalView_Load;
                detail.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
