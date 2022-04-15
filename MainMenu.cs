using DeviceRental.Handler;
using DeviceRental.Handler.ModelHandles.Queries;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DeviceRental
{
    public partial class MainMenu : Form
    {
        private readonly HandlerRegister _handlerRegister;

        public MainMenu(
            HandlerRegister handlerRegister)
        {
            InitializeComponent();

            _handlerRegister = handlerRegister;
        }

        private async void MainMenu_Load(object sender, EventArgs e)
        {
            var deviceRentals = (await _handlerRegister.Send(new GetListDeviceRentalQuery())).Result as IEnumerable<Models.DeviceRental>;
            var employees = (await _handlerRegister.Send(new GetListEmployeeQuery())).Result as IEnumerable<Models.Employee>;
            var devices = (await _handlerRegister.Send(new GetListDeviceQuery())).Result as IEnumerable<Models.Device>;

            // Device Rental view
            dgvDeviceRental.DataSource = deviceRentals;
            dgvDeviceRental.Columns[nameof(Models.DeviceRental.Device)].Visible = false;
            dgvDeviceRental.Columns[nameof(Models.DeviceRental.Employee)].Visible = false;

            // Employee view
            dgvEmployee.DataSource = employees;
            dgvEmployee.Columns[nameof(Models.Employee.Id)].Visible = false;
            dgvEmployee.Columns[nameof(Models.Employee.DeviceRentals)].Visible = false;

            // Device view
            dgvDevice.DataSource = devices;
            dgvEmployee.Columns[nameof(Models.Device.Id)].Visible = false;
            dgvEmployee.Columns[nameof(Models.Device.DeviceRentals)].Visible = false;
        }

        private void dgvDeviceRental_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var selectedItem = dgvDeviceRental.SelectedRows[0].DataBoundItem as Models.DeviceRental;
                var detail = new DeviceRentalDetail(selectedItem);
                detail.FormClosed += MainMenu_Load;
                detail.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
