using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.OleDb;


namespace TestXLSC
{
    class Program
    {
        public DataSet ReadXlsx(string adress)
        {
            try
            {
                FileStream stream = File.Open(adress, FileMode.Open, FileAccess.Read);

                IExcelDataReader 
            }
            catch
            {
                return null;
            }
        }
        static void Main(string[] args)
        {
            
        }
    }
}
