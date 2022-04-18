using Autofac;
using DeviceRental.Common;
using DeviceRental.Handler;
using DeviceRental.Handler.ModelHandles.Queries;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DeviceRental.UI
{
    public partial class EmployeeView : Form
    {
        private readonly HandlerRegister _handlerRegister;

        public EmployeeView()
        {
            InitializeComponent();
            _handlerRegister = Program.Container.Resolve<HandlerRegister>();
        }

        private async void EmployeeView_Load(object sender, EventArgs e)
        {
            try
            {
                var employees = (await _handlerRegister.Send(new GetListEmployeeQuery())).Result as IEnumerable<Models.Employee>;

                // Employee view
                dgvEmployee.DataSource = employees;
                dgvEmployee.Columns[nameof(Models.Employee.Id)].Visible = false;
                dgvEmployee.Columns[nameof(Models.Employee.DeviceRentals)].Visible = false;
            }
            catch (Exception ex)
            {
                Log.Error($"{Common.Common.GetCurrentMethod()}: {ex.Message})");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
