using System;
using System.Web;
using System.Text.RegularExpressions;

namespace BalloonShop.BusinessTier
{
    /// <summary>
    /// Link factory class
    /// </summary>
    public class Link
    {
        // Regex that removes characters that aren't a-z, 0-9, dash, underscore or space
        private static Regex purifyUrlRegex = new Regex("[^-a-zA-Z0-9_ ]", RegexOptions.Compiled);

        // Regex that changes dashes, underscores and spaces to dashes
        private static Regex dashesRegex = new Regex("[-_ ]+", RegexOptions.Compiled);

        /// <summary>
        /// Builds an absolute URL
        /// </summary>
        /// <param name="relativeUri"></param>
        /// <returns></returns>
        private static string BuildAbsolute(string relativeUri)
        {
            // Get current uri
            Uri uri = HttpContext.Current.Request.Url;
            // Build absolute path
            string app = HttpContext.Current.Request.ApplicationPath;
            if (!app.EndsWith("/"))
            {
                app += "/";
            }
            relativeUri = relativeUri.TrimStart('/');
            // return the absoulte path
            return HttpUtility.UrlPathEncode(
                string.Format("http://{0}:{1}{2}{3}"
                    , uri.Host
                    , uri.Port
                    , app
                    , relativeUri
            ));
        }

        /// <summary>
        /// Generate a department URL
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public static string ToDepartment(string departmentId, string page)
        {
            // Prepare department URL name
            DepartmentDetails departmentDetails = CatalogAccess.GetDepartmentDetails(departmentId);
            string deptUrlName = PrepareUrlText(departmentDetails.Name);

            // Build department URL
            if (page == "1")
            {
                return BuildAbsolute(string.Format("{0}-d{1}/", deptUrlName, departmentId));
            }
            else
            {
                return BuildAbsolute(string.Format("{0}-d{1}/Page-{2}", deptUrlName, departmentId, page));
            }
        }

        /// <summary>
        /// Generate a department URL for the first page
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        public static string ToDepartment(string departmentId)
        {
            return ToDepartment(departmentId, "1");
        }

        public static string ToCategory(string departmentId, string categoryId, string page)
        {
            // Prepare department and category URL names
            DepartmentDetails departmentDetails = CatalogAccess.GetDepartmentDetails(departmentId);
            string deptUrlName = PrepareUrlText(departmentDetails.Name);

            CategoryDetails categoryDetails = CatalogAccess.GetCategoryDetails(categoryId);
            string catUrlName = PrepareUrlText(categoryDetails.Name);

            // Build category URL
            if (page == "1")
            {
                return BuildAbsolute(String.Format("{0}-d{1}/{2}-c{3}/", deptUrlName, departmentId, catUrlName, categoryId));
            }
            else
            {
                return BuildAbsolute(String.Format("{0}-d{1}/{2}-c{3}/Page-{4}", deptUrlName, departmentId, catUrlName, categoryId, page));
            }
        }

        public static string ToCategory(string departmentId, string categoryId)
        {
            return ToCategory(departmentId, categoryId, "1");
        }

        public static string ToProduct(string productId)
        {
            // Prepare product URL name
            ProductDetails productDetails = CatalogAccess.GetProductDetails(productId.ToString());
            string productUrlName = PrepareUrlText(productDetails.Name);

            // Build product URL
            return BuildAbsolute(String.Format("{0}-p{1}", productUrlName, productId));
        }

        public static string ToProductImage(string fileName)
        {
            //-- build product URL
            return BuildAbsolute("/ProductImages/" + fileName);
        }

        /// <summary>
        /// Prepares a string to be included in an URL
        /// </summary>
        /// <param name="urlText"></param>
        /// <returns></returns>
        private static string PrepareUrlText(string urlText)
        {
            // Remove all characters that aren't a-z, 0-9, dash, underscore or space
            urlText = purifyUrlRegex.Replace(urlText, "");

            // Remove all leading and trailing spaces
            urlText = urlText.Trim();

            // Change all dashes, underscores and spaces to dashes
            urlText = dashesRegex.Replace(urlText, "-");

            // Return the modified string
            return urlText;
        }
    }
}