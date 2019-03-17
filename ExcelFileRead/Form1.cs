using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using ExcelFileRead;
using ExcelDataReader;
using ExcelLibrary;

namespace ExcelFileRead
{
    public partial class Form1 : Form
    {
        private Microsoft.Office.Interop.Excel.Application ObjExcel;    //Переменная книги
        private Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;    //Переменная таблица
        private Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;  //Переменная лист
        ExcelFiles ExcelFile1 = new ExcelFiles();

        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog OFD = new OpenFileDialog();                  //объявление экземпляра класса
            OFD.Filter = "Файл Excel|*.xlsx;*.xls";                     //Фильтр файлов
            OFD.ShowDialog();            
            ExcelFile1.OpenExcelFiles(OFD.FileName, ref dataGridView1, ref cboSheet);
        }        

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExcelFile1.ShowSheet(ref dataGridView1, ref cboSheet);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ExcelFile1.CloseExcelWorkBook();
            this.Close();            
        }

        private void btnPing_Click(object sender, EventArgs e)
        {
            ExcelFile1.PingThisList(ref dataGridView1);            
            dataGridView1.Refresh();
        }
    }
}
