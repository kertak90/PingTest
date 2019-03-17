using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace ExcelFileRead
{
    class pingThread
    {
        Thread thread;
        Ping p = new Ping();
        PingReply r;
        string IP;
        DataGridView DataGrid;
        int indexRow, indexColumn;
        
        public bool statFlag = false;
        public pingThread(string ip, DataGridView dataGrid, int i, int j)
        {
            indexRow = i;
            indexColumn = j;
            DataGrid = dataGrid;
            thread = new Thread(this.Ping);
            thread.Name = ip;
            IP = ip;            
            thread.Start();
        }

        private void Ping()
        {
            try
            {
                r = p.Send(IP);
                if (r.Status == IPStatus.Success)
                {
                    statFlag = true;
                    DataGrid.Rows[indexRow - 1].Cells[indexColumn - 1].Style.BackColor = System.Drawing.Color.Green;

                }
                else
                {
                    statFlag = false;
                    DataGrid.Rows[indexRow - 1].Cells[indexColumn - 1].Style.BackColor = System.Drawing.Color.Red;

                }
                Console.WriteLine($"{IP} - {statFlag}");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Скорее всего не IP: " + ex);
            }
            
        }
        //private void Ping()
        //{            
        //    r = p.Send(IP);
        //    if (r.Status == IPStatus.Success)
        //    {
        //        Btn.BackColor = Color.Green;
        //        statFlag = true;               
        //    }
        //    else
        //    {
        //        Btn.BackColor = Color.Red;
        //        statFlag = false;
        //    }

        //    Console.WriteLine($"{IP} - {statFlag}");
        //}   
    }
}
