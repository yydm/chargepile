using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ChargingPile.BLL;
using ChargingPile.Service;

namespace ChargingPile.Sms
{
    public partial class SendSmsForm : Form
    {
        //声明委托
        public delegate void AsyncEventHandler();
        readonly Service.Sms _sms = new Service.Sms();
        readonly string _port = System.Configuration.ConfigurationManager.AppSettings["port"];
        readonly string _interval = System.Configuration.ConfigurationManager.AppSettings["time"];

        public SendSmsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SendSms_Click(object sender, EventArgs e)
        {
            tbInfo.Text += Environment.NewLine + "开始发送，请等待...";
            _sms.SendSms();
            tbInfo.Text += Environment.NewLine + "短信已全部发送。";
        }

        /// <summary>
        /// 清除信息内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            tbInfo.Clear();
            tbInfo.Text = "信息：";
        }

        /// <summary>
        /// 停止服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopService_Click(object sender, EventArgs e)
        {
            var data = _sms.StopSms();
            if (data)
            {
                tbInfo.Text += Environment.NewLine + "停止服务:成功";
            }
            else
            {
                tbInfo.Text += Environment.NewLine + "停止服务:失败";
            }
            btn_SendSms.Enabled = false;
            btn_EndSend.Enabled = false;
        }

        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartService_Click(object sender, EventArgs e)
        {
            var port = int.Parse(nudPort.Text);
            _sms.Port = port;
            var data = _sms.StartSms();
            if (data)
            {
                tbInfo.Text += Environment.NewLine + "启动服务:成功";
                btn_SendSms.Enabled = true;
                btn_EndSend.Enabled = true;
            }
            else
            {
                tbInfo.Text += Environment.NewLine + "启动服务:失败";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_EndSend_Click(object sender, EventArgs e)
        {
            btnStartService.Enabled = true;
            btnStopService.Enabled = true;
        }

        private void TimeSms()
        {
            var data = _sms.SendSms();
            if (tbInfo.Text.Length >= 300)
            {
                btn_Clear_Click(null, null);
            }
            tbInfo.Text += Environment.NewLine + data;
        }
        private void SendSmsForm_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_port))
            {
                _sms.Port = int.Parse(_port);
            }
            if (!string.IsNullOrEmpty(_interval))
            {
                var interval = int.Parse(_interval);
                TimeSendSms.Interval = interval;
            }
            TimeSendSms.Enabled = true;
            var data1 = _sms.StartSms();
            if (data1)
            {
                tbInfo.Text += Environment.NewLine + "启动服务:成功";
            }
            else
            {
                tbInfo.Text += Environment.NewLine + "启动服务:失败";
                //TimeSendSms.Enabled = false;
            }
        }

        private void TimeSendSms_Tick(object sender, EventArgs e)
        {
            TimeSendSms.Enabled = false;
            TimeSms();

            var warndetailbll = new WarnDetailBll();
            var dtemail = warndetailbll.FindByEmail();
            if (dtemail != null && dtemail.Rows.Count > 0)
            {
                var count = dtemail.Rows.Count;
                var modellist = new List<EmailAndSmsModel>();
                for (var i = 0; i < count; i++)
                {
                    Service.Sms smsService = new Service.Sms();
                    var model = new EmailAndSmsModel()
                    {
                        Id = dtemail.Rows[i]["id"].ToString(),
                        Address = dtemail.Rows[i]["address"].ToString(),
                        Title = "充电桩告警邮件", //dtemail.Rows[i]["title"].ToString(),
                        Body = smsService.ResplaceTemplateStr(dtemail.Rows[i]["body"].ToString(), dtemail.Rows[i]["warnrecid"].ToString())
                    };
                    modellist.Add(model);
                }
                var email = new Emails();
                email.SendMailtoDes(modellist);//发送邮件
            }
            TimeSendSms.Enabled = true;
        }
    }
}
