using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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

        private async void SendMessage(object sender, EventArgs e)
        {
            var button = (sender as Button);
            var message = button.Tag.ToString();

            button.Enabled = groupBox1.Enabled = false;

            var monitor = cb_Displays.SelectedItem as DDC.Monitor;
            DDC.ProcessMessage(monitor, message);

            await Task.Delay(3000);
            btn_Refresh.PerformClick();

            button.Enabled = groupBox1.Enabled = true;
        }
    }
}
