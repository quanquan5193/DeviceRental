using DeviceRental.UI;
using System;
using System.Windows.Forms;

namespace DeviceRental
{
    public partial class ControlMenu : Form
    {
        public ControlMenu()
        {
            InitializeComponent();
            formControlPointerF1 += new controlcall(btnF1_Click);
            formControlPointerF2 += new controlcall(btnF2_Click);
            formControlPointerF3 += new controlcall(btnF3_Click);
            menuHelper1.userControlPointerF1 = formControlPointerF1;
            menuHelper1.userControlPointerF2 = formControlPointerF2;
            menuHelper1.userControlPointerF3 = formControlPointerF3;
        }

        #region Declare pointer control
        public delegate void controlcall(object sender, EventArgs e);
        private event controlcall formControlPointerF1;
        private event controlcall formControlPointerF2;
        private event controlcall formControlPointerF3;
        #endregion

        #region Override event click from User Control
        private void btnF1_Click(object sender, EventArgs e)
        {
            F1CLickOrPress();
        }

        private void btnF2_Click(object sender, EventArgs e)
        {
            F2CLickOrPress();
        }

        private void btnF3_Click(object sender, EventArgs e)
        {
            F3CLickOrPress();
        }
        #endregion

        #region Action when click or press F{0-12}
        public void F1CLickOrPress()
        {
            var device = new DeviceView();
            device.ShowDialog();
        }

        public void F2CLickOrPress()
        {
            var employee = new EmployeeView();
            employee.ShowDialog();
        }

        public void F3CLickOrPress()
        {
            var deviceRental = new DeviceRentalView();
            deviceRental.ShowDialog();
        }
        #endregion

        private void menuHelper1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "F1": F1CLickOrPress(); break;
                case "F2": F2CLickOrPress(); break;
                case "F3": F3CLickOrPress(); break;
            }
        }

        private void ControlMenu_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(menuHelper1_KeyDown);
        }
    }
}
