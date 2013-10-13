using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalloonShop.BusinessTier;

namespace BalloonShop.UserControls
{
    public partial class DepartmentsList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // CatalogAccess.GetDepartments returns a DataTable object containing department data
            DepartmentList.DataSource = CatalogAccess.GetDepartments();
            // Bind data bound controls to data source
            DepartmentList.DataBind();
        }
    }
}