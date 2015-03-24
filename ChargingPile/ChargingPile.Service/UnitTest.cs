using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ChargingPile.BLL;
using NUnit.Framework;

namespace ChargingPile.Service
{
    /// <summary>
    /// 测试类
    /// </summary>
    [TestFixture]
    public class UnitTest
    {
        public UnitTest()
        {
            var threadStart = new ThreadStart(Send);
            var thread = new Thread(threadStart);
            thread.Start();
        }

        [Test]
        public void Send()
        {
            while (true)
            {

                try
                {
                    var warndetailbll = new WarnDetailBll();
                    var dtemail = warndetailbll.FindByEmail();
                    if (dtemail != null && dtemail.Rows.Count > 0)
                    {
                        var count = dtemail.Rows.Count;
                        var modellist = new List<EmailAndSmsModel>();
                        for (var i = 0; i < count; i++)
                        {
                            var model = new EmailAndSmsModel()
                                {
                                    Id = dtemail.Rows[i]["id"].ToString(),
                                    Address = dtemail.Rows[i]["address"].ToString(),
                                    Title = dtemail.Rows[i]["title"].ToString(),
                                    Body = dtemail.Rows[i]["body"].ToString()
                                };
                            modellist.Add(model);
                        }
                        var email = new Emails();
                        email.SendMailtoDes(modellist);//发送邮件
                    }



                    var dtsms = warndetailbll.FindBySms();
                    if (dtsms != null && dtsms.Rows.Count > 0)
                    {
                        var count = dtsms.Rows.Count;
                        var modellist = new List<EmailAndSmsModel>();
                        for (var i = 0; i < count; i++)
                        {
                            var model = new EmailAndSmsModel()
                            {
                                Address = dtsms.Rows[i]["address"].ToString(),
                                Title = dtsms.Rows[i]["title"].ToString(),
                                Body = dtsms.Rows[i]["body"].ToString()
                            };
                            modellist.Add(model);
                        }
                        var sms = new Sms();
                        //sms.SendSms(modellist);//发送短信
                    }

                }
                catch (Exception e)
                {
                }
                Thread.Sleep(60 * 1000);//线程睡眠60秒
            }
        }
    }
}
