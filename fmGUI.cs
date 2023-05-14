using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputSourceDDC
{
    public partial class fmGUI : Form
    {
        public fmGUI()
        {
            InitializeComponent();
        }

        private void fmGUI_Shown(object sender, EventArgs e)
        {
            btn_Refresh.PerformClick();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            DDC.Refresh();
            cb_Displays.Items.Clear();
            cb_Displays.Items.AddRange(DDC.Monitors.ToArray());
            cb_Displays.SelectedIndex = 0;
        }

        private void InputSwitch_Click(object sender, EventArgs e)
        {
            var message = (sender as Button).Tag.ToString();
            var monitor = cb_Displays.SelectedItem as DDC.Monitor;
            DDC.ProcessMessage(monitor, message);
        }
    }
}
