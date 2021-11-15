using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace umeAPI.Service
{
    public class Authentication
    {
        

        
        public static async Task sendCodeByEmail(string toEmail, string title, string contain)
        {
            string email = "minhnhat020400@gmail.com";
            string password = "dgeltzrbzgdryvit";
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(email, password);

                    MailMessage op = new MailMessage();
                    op.To.Add(toEmail);
                    op.From = new MailAddress(email);
                    op.Subject = title;
                    op.Body = contain;
                    
                    client.Send(op);
                }
            }
            catch { 
                
            }
        }
        public static async Task sendPassByEmail(string toEmail, string title, string contain)
        {
            string email = "minhnhat020400@gmail.com";
            string password = "dgeltzrbzgdryvit";
            try
            {

                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(email, password);

                    MailMessage op = new MailMessage();
                    op.To.Add(toEmail);
                    op.From = new MailAddress(email);
                    op.Subject = title;
                    op.Body = contain;

                    client.Send(op);
                }
            }
            catch
            {

            }
        }
    }
}