using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ObjExcel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.Text.RegularExpressions;

namespace ExcelFileRead
{
    class ExcelFiles
    {
        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
        ObjExcel._Workbook WorkBook;
        ObjExcel.Sheets WbSheets;
        ObjExcel.Worksheet WbSheet;
        ObjExcel.Range WbRange;        

        int rowCount;
        int columnCount;
        string str;
        string FileName;

        public void OpenExcelFiles(string fileName, ref DataGridView DataGridView, ref ComboBox comboBox)
        {
            DataGridView.Rows.Clear();
            DataGridView.RowCount=1;
            DataGridView.ColumnCount = 1;

            FileName = fileName;
            try
            {
                WorkBook = ExcelApp.Workbooks.Open(fileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false,
                false, 0, true, 1, 0);
                WbSheets = WorkBook.Sheets;
                WbSheet = (ObjExcel.Worksheet)WorkBook.Worksheets.get_Item(1);
                WbRange = WbSheet.UsedRange;
                comboBox.Items.Clear();
                comboBox.Text = WbSheet.Name;
                foreach (ObjExcel.Worksheet sht in WbSheets)
                    comboBox.Items.Add(sht.Name);

                DataGridView.RowCount = WbRange.Rows.Count;
                DataGridView.ColumnCount = WbRange.Columns.Count;                
                for (rowCount = 1; rowCount <= WbRange.Rows.Count; rowCount++)
                {
                    for (columnCount = 1; columnCount <= WbRange.Columns.Count; columnCount++)
                    {
                        str = (string)(WbRange.Cells[rowCount, columnCount] as Microsoft.Office.Interop.Excel.Range).Text;
                        DataGridView.Rows[rowCount - 1].Cells[columnCount - 1].Value = str;         
                    }

                }
                DataGridView.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Не удалось открыть таблицу.\n");
            }
        }

        public void ShowSheet(ref DataGridView DataGridView, ref ComboBox comboBox)
        {
            DataGridView.Rows.Clear();
            DataGridView.RowCount = 1;
            DataGridView.ColumnCount = 1;
            WbSheets = WorkBook.Sheets;
            WbSheet = (ObjExcel.Worksheet)WorkBook.Sheets[comboBox.Text];            
            WbRange = WbSheet.UsedRange;
            DataGridView.RowCount = WbRange.Rows.Count;
            DataGridView.ColumnCount = WbRange.Columns.Count;
            
            for (rowCount = 1; rowCount <= WbRange.Rows.Count; rowCount++)
            {
                for (columnCount = 1; columnCount <= WbRange.Columns.Count; columnCount++)
                {
                    str = (string)(WbRange.Cells[rowCount, columnCount] as Microsoft.Office.Interop.Excel.Range).Text;
                    DataGridView.Rows[rowCount - 1].Cells[columnCount - 1].Value = str;         //Ошибка                                        
                }
            }
            DataGridView.Refresh();            
        }

        public void PingThisList(ref DataGridView DataGrid)
        {
            Regex myReg = new Regex(@"^([0-9]|[0-9][0-9]|[01][0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[0-9][0-9]|[01][0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$");         //Шаблон регулярного выражения IP адресов
            Regex myReg2 = new Regex("(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)");
            for (int i=2;i<=DataGrid.Rows.Count; i++)
            {     
                for(int j=1;j<=DataGrid.ColumnCount;j++)
                {
                    if ((DataGrid.Rows[i - 1].Cells[j-1].Value != null) && (myReg2.IsMatch(Convert.ToString(DataGrid.Rows[i - 1].Cells[j-1].Value))))
                    {
                        pingThread TaskPing = new pingThread(Convert.ToString(DataGrid.Rows[i - 1].Cells[j-1].Value), DataGrid, i, j);

                    }
                }                    
            }            
        }

        public void CloseExcelWorkBook()
        {
            try
            {
                WorkBook.Close();
                ExcelApp.Quit();
                releaseObject(WorkBook);
                releaseObject(WbSheet);
                releaseObject(ExcelApp);
            }
            catch
            {

            }
            
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;

            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
