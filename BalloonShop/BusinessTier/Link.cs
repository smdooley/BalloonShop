using System;
using System.Web;

namespace BalloonShop.BusinessTier
{
    /// <summary>
    /// Link factory class
    /// </summary>
    public class Link
    {
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
            if (page == "1")
            {
                return BuildAbsolute(string.Format("Catalog.aspx?DepartmentID={0}", departmentId));
            }
            else
            {
                return BuildAbsolute(string.Format("Catalog,aspx?DepartmentID={0}&Page={1}", departmentId, page));
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
    }
}