using DeviceRental.Database;
using DeviceRental.Infrastructure;
using DeviceRental.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceRental
{
    public partial class MainMenu : Form
    {
        private readonly IDeviceRentalRepository _deviceRentalRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MainMenu(IDeviceRentalRepository deviceRentalRepository, 
            IEmployeeRepository employeeRepository,
            IDeviceRepository deviceRepository,
            IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            _deviceRentalRepository = deviceRentalRepository;
            _employeeRepository = employeeRepository;
            _deviceRepository = deviceRepository;
            _unitOfWork = unitOfWork;
        }

        private async void MainMenu_Load(object sender, EventArgs e)
        {
            var deviceRentals = await _deviceRentalRepository.GetAll(new string[] { nameof(Models.DeviceRental.Device), nameof(Models.DeviceRental.Employee) });
            var employees = await _employeeRepository.GetAll();
            var devices = await _deviceRepository.GetAll();

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
                var detail = new DeviceRentalDetail(selectedItem, _deviceRentalRepository, _unitOfWork);
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
