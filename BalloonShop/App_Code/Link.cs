using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BalloonShop.App_Code
{
    public class Link
    {
        // Builds an absolute URl
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

            // return the absolute path
            return HttpUtility.UrlPathEncode(
                string.Format("http://{0}:{1}{2}{3}", uri.Host, uri.Port, app, relativeUri)
            );
        }

        // Generate a department URL
        public static string ToDepartment(string departmentId, string page)
        {
            if (page == "1")
            {
                return BuildAbsolute(string.Format("Catalog.aspx?DepartmentID={0}", departmentId));
            }
            else
            {
                return BuildAbsolute(string.Format("Catalog.aspx?DepartmentID={0}&Page={1}", departmentId, page));
            }
        }

        // Generate a department URL for the first page
        public static string ToDepartment(string departmentId)
        {
            return ToDepartment(departmentId, "1");
        }
    }
}