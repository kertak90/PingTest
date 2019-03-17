using System;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Threading;
//Пинарин Олег
//Пинг УСО Хорошевка

namespace PingTest
{
    public partial class Form1 : Form
    {     
        public Form1()
        {
            InitializeComponent();
            //Серверы
            //tx1.Text = "192.168.1.68";
            tx1.Text = "20.1.102.1";            
            tx2.Text = "20.1.102.2";
            //Армы
            tx3.Text = "20.1.102.3";
            tx4.Text = "20.1.102.5";
            //УСО1
            tx5.Text = "20.1.102.12";
            tx6.Text = "20.1.102.14";
            string Uso1_AC1 = "20.1.102.16";
            string Uso1_AC2 = "20.1.102.17";
            //УСО2
            tx7.Text = "20.1.102.18";            
            string Uso2_AC1 = "20.1.102.20";
            //УСО3
            tx9.Text = "20.1.102.21";
            tx10.Text = "20.1.102.23";
            //УСО4
            tx11.Text = "20.1.102.27";
            tx12.Text = "20.1.102.29";
            //УСО5
            tx13.Text = "20.1.102.30";
            tx14.Text = "20.1.102.32";
            //УСО6
            tx15.Text = "20.1.102.36";
            tx16.Text = "20.1.102.38";
            //УСО7
            tx17.Text = "20.1.102.42";
            tx18.Text = "20.1.102.44";            
        }

        #region 2
        private void button2_Click(object sender, EventArgs e)
        {
            pingThread btn2 = new pingThread(tx1.Text, button2);            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            pingThread btn3 = new pingThread(tx2.Text, button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            pingThread btn4 = new pingThread(tx3.Text, button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {            
            pingThread btn5 = new pingThread(tx4.Text, button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {            
            pingThread btn6 = new pingThread(tx5.Text, button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {            
            pingThread btn7 = new pingThread(tx6.Text, button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            pingThread btn8 = new pingThread(tx7.Text, button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {            
            pingThread btn9 = new pingThread(tx8.Text, button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            pingThread btn10 = new pingThread(tx9.Text, button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            pingThread btn11 = new pingThread(tx10.Text, button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pingThread btn12 = new pingThread(tx11.Text, button12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            pingThread btn13 = new pingThread(tx12.Text, button13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            pingThread btn14 = new pingThread(tx13.Text, button14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            pingThread btn15 = new pingThread(tx13.Text, button15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            pingThread btn16 = new pingThread(tx15.Text, button16);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            pingThread btn17 = new pingThread(tx16.Text, button17);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            pingThread btn18 = new pingThread(tx17.Text, button18);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            pingThread btn19 = new pingThread(tx18.Text, button19);
        }
        #endregion
        private void button20_Click(object sender, EventArgs e)
        {
            pingThread btn2     = new pingThread(tx1.Text, button2);
            pingThread btn3     = new pingThread(tx2.Text, button3);
            pingThread btn4     = new pingThread(tx3.Text, button4);
            pingThread btn5     = new pingThread(tx4.Text, button5);
            pingThread btn6     = new pingThread(tx5.Text, button6);
            pingThread btn7     = new pingThread(tx6.Text, button7);
            pingThread btn8     = new pingThread(tx7.Text, button8);
            pingThread btn9     = new pingThread(tx8.Text, button9);
            pingThread btn10    = new pingThread(tx9.Text, button10);
            pingThread btn11    = new pingThread(tx10.Text, button11);
            pingThread btn12    = new pingThread(tx11.Text, button12);
            pingThread btn13    = new pingThread(tx12.Text, button13);
            pingThread btn14    = new pingThread(tx13.Text, button14);
            pingThread btn15    = new pingThread(tx14.Text, button15);
            pingThread btn16    = new pingThread(tx15.Text, button16);
            pingThread btn17    = new pingThread(tx16.Text, button17);
            pingThread btn18    = new pingThread(tx17.Text, button18);
            pingThread btn19    = new pingThread(tx18.Text, button19);
            

        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click_1(object sender, EventArgs e)
        {

        }

        private void button21_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
