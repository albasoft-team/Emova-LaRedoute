using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace IELRLibraryManager.Mails
{
    public class MailSender
    {
        public static Attachment facture;
        public static Attachment cgv;

        public static string GmailUsername { get; set; }
        public static string GmailPassword { get; set; }
        public static string GmailHost { get; set; }
        public static int GmailPort { get; set; }
        public static bool GmailSSL { get; set; }


        public string ToEmail { get; set; }
        public static string Subject { get; set; }
        public string Body { get; set; }
        public AttachmentCollection Attachments { get; }
        public bool IsHtml { get; set; }

        public MailSender(string host, int port, bool ssl, string username, string password)
        {
            GmailHost = host;
            GmailPort = port ;
            GmailSSL = ssl;
            GmailUsername = username;
            GmailPassword = password;
        }

        public void Send()
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = GmailHost;
            smtp.Port = GmailPort;
            smtp.EnableSsl = GmailSSL;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

            using (var message = new MailMessage(GmailUsername, ToEmail))
            {
                message.Subject = Subject;
                message.Body = Body;
                message.IsBodyHtml = true;
                message.Attachments.Add(facture);
                message.Attachments.Add(cgv);
                smtp.Send(message);
            }
        }
    }
}
