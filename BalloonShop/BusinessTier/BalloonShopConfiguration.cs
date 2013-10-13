using System.Configuration;

namespace BalloonShop.BusinessTier
{
    /// <summary>
    /// Repository for BalloonShop configuration settings
    /// </summary>
    public static class BalloonShopConfiguration
    {
        // Caches the connection string
        private static string dbConnectionString;
        // Caches the data provider name
        private static string dbProviderName;

        static BalloonShopConfiguration()
        {
            dbConnectionString = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ConnectionString;
            dbProviderName = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ProviderName;
        }

        /// <summary>
        /// Returns the connection string for the BalloonShop database
        /// </summary>
        public static string DbConnectionString
        {
            get { return dbConnectionString; }
        }

        /// <summary>
        /// Returns the data provider name
        /// </summary>
        public static string DbProviderName
        {
            get { return dbProviderName; }
        }

        /// <summary>
        /// Returns the address of the mail server
        /// </summary>
        public static string MailServer
        {
            get { return ConfigurationManager.AppSettings["MailServer"]; }
        }

        /// <summary>
        /// Returns the email username
        /// </summary>
        public static string MailUsername
        {
            get { return ConfigurationManager.AppSettings["MailUsername"]; }
        }

        /// <summary>
        /// Returns the email password
        /// </summary>
        public static string MailPassword
        {
            get { return ConfigurationManager.AppSettings["MailPassword"]; }
        }

        /// <summary>
        /// Returns the email from address
        /// </summary>
        public static string MailFrom
        {
            get { return ConfigurationManager.AppSettings["MailFrom"]; }
        }

        /// <summary>
        /// Send error log emails?
        /// </summary>
        public static bool EnableErrorLogEmail
        {
            get { return bool.Parse(ConfigurationManager.AppSettings["EnableErrorLogEmail"]); }
        }

        /// <summary>
        /// Returns the email address where to send error reports
        /// </summary>
        public static string ErrorLogEmail
        {
            get { return ConfigurationManager.AppSettings["ErrorLogEmail"]; }
        }
    }
}