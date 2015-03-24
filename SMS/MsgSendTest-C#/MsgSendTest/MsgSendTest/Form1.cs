using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSSMS;
namespace MsgSendTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            int ret;
            int iPort = 1;
            uint bit = 115200;
            
            ret = SMS.SMSStartService(iPort, bit, 2, 8, 0, 0, "13067361236");
            if (ret == 1)
            {

                //sslMessage.Text = "服务启动成功!";
                //btnStart.Enabled = false;
                //btnStop.Enabled = true;
                //btnSend.Enabled = true;
                MessageBox.Show("服务启动成功");
            }
            else
            {
                //sslMessage.Text = "服务没有启动成功!";
                //btnStart.Enabled = true;
                //btnStop.Enabled = true;
                //btnSend.Enabled = false;
                MessageBox.Show("服务启动失败");
            }*/
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //SMSClass.SMSStopSerice();
            int ret = SMS.SMSStopSerice();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MsgSend();
        }

        private void MsgSend()
        {
            string strContent =this.txtContent.Text;
            string strPhoneNo =this.txtSendPhoneNumber.Text;
            if (strContent.Equals(""))
            {
                MessageBox.Show(this, "内容不能为空!", "提示", MessageBoxButtons.OK);
                return;
            }
            if (strPhoneNo.Equals(""))
            {
                MessageBox.Show(this, "手机号不能为空!", "提示", MessageBoxButtons.OK);
                return;
            }

            byte[] Msg = UnicodeEncoding.Default.GetBytes(strContent);
            byte[] PhoneNo = UnicodeEncoding.Default.GetBytes(strPhoneNo);
            //SMSClass.SMSSendMessage(Msg, PhoneNo);
            uint num=SMS.SMSSendMessage(strContent, strPhoneNo);
            MessageBox.Show("发送索引:"+num.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StartService();
        }

        private void StartService()
        {
            if (this.txtPort.Text == "")
            {
                MessageBox.Show("端口不能为空");
                return;
            }
            int ret;
            int iPort =Convert.ToInt32(this.txtPort.Text);
            uint bit = 115200;
            byte[] cards = UnicodeEncoding.Default.GetBytes("card");
            string cardNo = System.Text.Encoding.Default.GetString(cards);
            ret = SMS.SMSStartService(iPort, bit, 2, 8, 0, 0, cardNo);
            if (ret == 1)
            {

                //sslMessage.Text = "服务启动成功!";
                //btnStart.Enabled = false;
                //btnStop.Enabled = true;
                //btnSend.Enabled = true;
                MessageBox.Show("服务启动成功");
            }
            else
            {
                //sslMessage.Text = "服务没有启动成功!";
                //btnStart.Enabled = true;
                //btnStop.Enabled = true;
                //btnSend.Enabled = false;
                MessageBox.Show("服务启动失败");
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            int flag = SMS.SMSStopSerice();
            if (flag == 0)
            {
                MessageBox.Show("服务停止失败!");
            }
            else
            {
                MessageBox.Show("服务已成功停止!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             SMS.SMSMessageStruct ms=new SMS.SMSMessageStruct();
             int ret = SMS.SMSGetNextMessage(ref ms);
             if (ret > 0)
             {
                 byte[] Msg = ms.Msg;
                 byte[] PhoneNo = ms.PhoneNo;
                 byte[] ReceiveTime = ms.ReceTime;

                 string strMsg = System.Text.Encoding.Default.GetString(Msg).Replace("\0", "");
                 string strPhoneNo = System.Text.Encoding.Default.GetString(PhoneNo).Replace("\0", "");
                 string strReceiveTime = System.Text.Encoding.Default.GetString(ReceiveTime).Replace("\0", "");

                 string ReceiveMsg = strPhoneNo + "," + strReceiveTime + "," + strMsg;
                 this.listReceiveMsg.Items.Add(ReceiveMsg);
             }
             else
             {
                 string ss = "";
             }
             
        }

        private void btnStartReceiveMsg_Click(object sender, EventArgs e)
        {
            string btnText = this.btnStartReceiveMsg.Text;
            if (btnText == "开始接收短信")
            {
                this.timer1.Enabled = false;
                this.btnStartReceiveMsg.Text = "停止接收短信";
            }
            else
            {
                this.timer1.Enabled = true;
                this.btnStartReceiveMsg.Text = "开始接收短信";
            }
        }
    }
}
