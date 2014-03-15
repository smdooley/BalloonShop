using System.Configuration;

namespace BalloonShop.BusinessTier
{
    /// <summary>
    /// Repository for BalloonShop configuration settings
    /// </summary>
    public static class BalloonShopConfiguration
    {
        private static string dbConnectionString; // Caches the connection string
        private static string dbProviderName; // Caches the data provider name

        private readonly static int productsPerPage; // Store the number of products per page
        private readonly static int productDescriptionLength; // Store the product description length for product lists
        private readonly static string siteName; // Store the name of your shop

        static BalloonShopConfiguration()
        {
            dbConnectionString = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ConnectionString;
            dbProviderName = ConfigurationManager.ConnectionStrings["BalloonShopConnection"].ProviderName;

            productsPerPage = System.Int32.Parse(ConfigurationManager.AppSettings["ProductsPerPage"]);
            productDescriptionLength = System.Int32.Parse(ConfigurationManager.AppSettings["ProductDescriptionLength"]);
            siteName = ConfigurationManager.AppSettings["SiteName"];
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
        /// Returns the maximum number of products to be displayed on a page
        /// </summary>
        public static int ProductsPerPage
        {
            get { return productsPerPage; }
        }

        /// <summary>
        /// Returns the length of products descriptions in products lists
        /// </summary>
        public static int ProductDescriptionLength
        {
            get { return productDescriptionLength; }
        }

        /// <summary>
        /// Returns the store name of the shop
        /// </summary>
        public static string SiteName
        {
            get { return siteName; }
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