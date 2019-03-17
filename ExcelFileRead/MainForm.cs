using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExcelFileRead
{
    public partial class MainForm : Form
    {
        
        
        public MainForm()
        {
            InitializeComponent();            
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }        

        private void btnComChange_Click(object sender, EventArgs e)
        {
            FormComChange form2 = new FormComChange();
            form2.Show();
        }

        private void TCPChat_Click(object sender, EventArgs e)
        {
            chatForm form3 = new chatForm();
            form3.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
