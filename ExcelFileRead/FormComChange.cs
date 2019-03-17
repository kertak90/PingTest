using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ExcelFileRead
{
    public partial class FormComChange : Form
    {
        ComPorts PortsList;
        public FormComChange()
        {
            InitializeComponent();
            PortsList = new ComPorts(comboBoxPorts);
            labelSetting1.Text = "Baud Rate 9600,     Parity.None, 8, StopBits.One";
            labelSetting2.Text = "Baud Rate 115200,   Parity.None, 8, StopBits.One";
        }

        private void comboBoxPorts_SelectedIndexChanged(object sender, EventArgs e)
        {            
            PortsList.ChoisePort(comboBoxPorts);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnComSetting1_Click(object sender, EventArgs e)
        {
            PortsList.SettingChoisenPort(9600, Parity.None, 8, StopBits.One);
        }

        private void btnComSetting2_Click(object sender, EventArgs e)
        {
            PortsList.SettingChoisenPort(115200, Parity.None, 8, StopBits.One);
        }
    }
}
