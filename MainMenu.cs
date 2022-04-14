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
        private readonly IUnitOfWork _unitOfWork;

        public MainMenu(IDeviceRentalRepository deviceRentalRepository, IUnitOfWork unitOfWork)
        {
            InitializeComponent();

            _deviceRentalRepository = deviceRentalRepository;
            _unitOfWork = unitOfWork;
        }

        private async void MainMenu_Load(object sender, EventArgs e)
        {
            var deviceRentals = await _deviceRentalRepository.GetAll(new string[] { nameof(Models.DeviceRental.Device), nameof(Models.DeviceRental.Employee) });
            dgvDeviceRental.DataSource = deviceRentals;
            dgvDeviceRental.Columns[nameof(Models.DeviceRental.Device)].Visible = false;
            dgvDeviceRental.Columns[nameof(Models.DeviceRental.Employee)].Visible = false;
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
