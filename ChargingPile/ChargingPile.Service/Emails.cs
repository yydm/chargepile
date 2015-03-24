using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using ChargingPile.BLL;
using ChargingPile.Model;

namespace ChargingPile.Service
{
    public class Emails
    {
        private readonly SmtpClient _smtp;
        private MailMessage _objMailMessage;
        private static readonly string UserMail = ConfigurationSettings.AppSettings["UserMail"];
        private static readonly string Password = ConfigurationSettings.AppSettings["PassWord"];
        public Emails()
        {
            _smtp = new SmtpClient
                {
                    EnableSsl = true,
                    Host = ConfigurationSettings.AppSettings["mailsmtp"],
                    Port = int.Parse(ConfigurationSettings.AppSettings["port"]),
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(UserMail, Password)
                };
        }

        /// <summary>
        /// 
        /// </summary>
        public void SendMailtoDes(List<EmailAndSmsModel> list)
        {
            if (list == null) throw new ArgumentNullException("list");
            _smtp.UseDefaultCredentials = false;
            _smtp.Credentials = new NetworkCredential(UserMail, Password);

            foreach (var t in list)
            {
                _objMailMessage = new MailMessage
                    {
                        Priority = MailPriority.Normal,
                        From = new MailAddress(UserMail)
                    };
                _objMailMessage.To.Add(new MailAddress(t.Address));
                _objMailMessage.IsBodyHtml = true;
                _objMailMessage.Subject = t.Title;
                _objMailMessage.Body = t.Body;
                try
                {
                    _smtp.Send(_objMailMessage);
                    var warndetailbll = new WarnDetailBll();
                    var warndetail = new WarnDetail
                        {
                            Id = t.Id,
                            ProcessFlag = 1,
                            IsSuccess = 1,
                            SendDT = DateTime.Now,
                            UpdateDT = DateTime.Now
                        };
                    warndetailbll.Modify(warndetail);
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}
