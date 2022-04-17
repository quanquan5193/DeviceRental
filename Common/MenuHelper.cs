using System;
using System.Windows.Forms;

namespace DeviceRental
{
    public partial class MenuHelper : UserControl
    {
        public MenuHelper()
        {
            InitializeComponent();
        }

        //Control pointer F{0-12}
        public Delegate userControlPointerF1;
        public Delegate userControlPointerF2;
        public Delegate userControlPointerF3;

        /// <summary>
        /// Interface event click or press F1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF1_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF1.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF2_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF2.DynamicInvoke(arr);
        }

        /// <summary>
        /// Interface event click or press F3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnF3_Click(object sender, EventArgs e)
        {
            object[] arr = { null, null };
            userControlPointerF3.DynamicInvoke(arr);
        }
    }
}
