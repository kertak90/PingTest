using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingFromTable
{
    public partial class Form2 : Form
    {
        System.IO.StreamReader SR;
        DoubleArr DR;
        public Form2()
        {
            InitializeComponent();            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog Fd = new OpenFileDialog();
            Fd.Filter = "ExcelFiles (.xls)|*.xlsx";
            Fd.FilterIndex = 2;
            Fd.Title = "Выберите файл с IP адресами";
            if(Fd.ShowDialog()==DialogResult.OK)
            {
                SR = new System.IO.StreamReader(Fd.FileName);               //Получили название и путь до файла и занесли его в Fd.FileName
                string[] IP_list = File.ReadAllLines(Fd.FileName);          //передали все содержимое файла в массив IP_list               
                
                DR = new DoubleArr(Fd.FileName);
                listBox1.Items.Clear();                                     //Очистка listBox1
                listBox1.Items.Add(DR.arr);                           //Занесли весь файл в listBox1
            }
        }

        private void CloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearList_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        
    }
}
