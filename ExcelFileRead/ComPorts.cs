using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace ExcelFileRead
{
    class ComPorts
    {
        string[] portnames = SerialPort.GetPortNames();
        string ChoisePortName = null;
        SerialPort choisePort = null;

        public ComPorts(ComboBox comboBox)
        {
            
            comboBox.Items.Clear();
            foreach (string PortName in portnames)
            {
                comboBox.Items.Add(PortName);
            }
            comboBox.Refresh();
        }
        public void ChoisePort(ComboBox comboBox)
        {
            string ChoisePortName=null;
            ChoisePortName = Convert.ToString(comboBox.SelectedItem);
            choisePort = new SerialPort(ChoisePortName);

        }
        public void SettingChoisenPort( int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            try
            {
                choisePort.Open();
                choisePort.BaudRate = baudRate;
                choisePort.Parity = parity;
                choisePort.DataBits = dataBits;
                choisePort.StopBits = stopBits;

                //choisePort.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
