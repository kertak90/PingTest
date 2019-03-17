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

namespace PingTest
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

        private void Ping()
        {            
            r = p.Send(IP);
            if (r.Status == IPStatus.Success)
            {
                Btn.BackColor = Color.Green;
                statFlag = true;               
            }
            else
            {
                Btn.BackColor = Color.Red;
                statFlag = false;
            }

            Console.WriteLine($"{IP} - {statFlag}");
        }   
    }
}
