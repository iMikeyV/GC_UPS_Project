using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace UPS_Project
{
    class EmailLogic
    {
        public static void SendEmail(Depot depot)
        {
            string adminEmail = "UPSDeliveredNotification@gmail.com"; //User login credential

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Settings for gmail
            client.UseDefaultCredentials = false; //required by gmail smtp
            client.EnableSsl = true; //required by gmail smtp
            client.Credentials = new System.Net.NetworkCredential(adminEmail, "5151helpDesk"); //hardcoded password

            //Basics of en email
            MailAddress fromMailAddress = new MailAddress(adminEmail); //admin username
            MailMessage mail = new MailMessage();
            //Everything here needs to get passed when calling SendEmail(from, )
            mail.To.Add("michel.villafan@goldencorral.net");
            mail.From = fromMailAddress;
            mail.Subject = "UPS Delivery Notification for Store: "+depot.Store.Substring(0,4);
            mail.Body = "Store: "+depot.Store
                        +"\nItem: "+depot.Item
                        +"\nHas been delivered"
                        ;
            mail.IsBodyHtml = false;



            client.Send(mail);



        }
    }
}

