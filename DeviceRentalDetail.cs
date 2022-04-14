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
    public partial class DeviceRentalDetail : Form
    {
        private readonly Models.DeviceRental _deviceRental;
        private readonly IDeviceRentalRepository _deviceRentalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeviceRentalDetail(Models.DeviceRental deviceRental, IDeviceRentalRepository deviceRentalRepository, IUnitOfWork unitOfWork)
        {
            InitializeComponent();
            _deviceRental = deviceRental;
            _deviceRentalRepository = deviceRentalRepository;
            _unitOfWork = unitOfWork;
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
            var data = await _deviceRentalRepository.GetSingleByCondition(x => x.DeviceId == _deviceRental.DeviceId && x.EmployeeId == _deviceRental.EmployeeId);
            data.EndDate = _deviceRental.EndDate;
            _deviceRentalRepository.Update(data);
            _deviceRentalRepository.DbContext.SaveChanges();
            //_unitOfWork.Commit();
            this.Close();
            MessageBox.Show("Data was changed");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
