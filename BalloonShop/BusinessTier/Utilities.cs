using System;
using System.Net.Mail;

namespace BalloonShop.BusinessTier
{
    /// <summary>
    /// Class contains miscellaneous functionality
    /// </summary>
    public static class Utilities
    {
        static Utilities()
        {
        }

        /// <summary>
        /// Generic method for sending emails
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SendMail(string from, string to, string subject, string body)
        {
            // Configure mail client
            SmtpClient mailClient = new SmtpClient(BalloonShopConfiguration.MailServer);
            // Set credentials (for SMTP servers that require authentication)
            //mailClient.Credentials = new NetworkCredential(BalloonShopConfiguration.MailUsername, BalloonShopConfiguration.MailPassword);
            mailClient.UseDefaultCredentials = true;
            // Create the mail message
            MailMessage mailMessage = new MailMessage(from, to, subject, body);
            // Send mail
            mailClient.Send(mailMessage);
        }

        /// <summary>
        /// Send error log email
        /// </summary>
        /// <param name="ex"></param>
        public static void LogError(Exception ex)
        {
            // get current date and time
            string dateTime = string.Format("{0}, at {1}"
                , DateTime.Now.ToLongDateString()
                , DateTime.Now.ToShortTimeString()
            );
            // obtain the page that generated the error
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            // stores the error message
            string errorMessage = string.Format("Exception generated on {0}\n Message: {1}\n Source: {2}\n Method: {3}\n Stack Trace: {4}"
                , dateTime
                , ex.Message
                , ex.Source
                , ex.TargetSite
                , ex.StackTrace
            );

            if (BalloonShopConfiguration.EnableErrorLogEmail)
            {
                SendMail(BalloonShopConfiguration.MailFrom, BalloonShopConfiguration.ErrorLogEmail, "BalloonShop Error Report", errorMessage);
            }
        }
    }
}