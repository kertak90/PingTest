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
        Button Btn;
        bool statFlag = false;
        public pingThread(string ip, Button btn)
        {
            thread = new Thread(this.Ping);
            thread.Name = ip;
            IP = ip;
            Btn = btn;
            thread.Start();
        }

        private bool Ping()
        {            
            r = p.Send(IP);
            if (r.Status == IPStatus.Success)
            {
                return true;               
            }
            else
            {
                return false;
            }
        }   
    }
}
