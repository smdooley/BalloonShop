using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalloonShop.BusinessTier;
using System.Data;

namespace BalloonShop.UserControls
{
    public partial class ProductsList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        private void PopulateControls()
        {
            // Retrieve DepartmentID from the query string
            string departmentId = Request.QueryString["DepartmentID"];
            // Retrieve CategoryID from the query string
            string categoryId = Request.QueryString["CategoryID"];
            // Retrieve Page from the query string
            string page = Request.QueryString["Page"];
            if (page == null) page = "1";
            // How many pages of products?
            int howManyPages = 1;
            // pager links format
            string firstPageUrl = "";
            string pagerFormat = "";

            // If browsing a category...
            if (categoryId != null)
            {
                // Retrieve list of products in a category
                list.DataSource =
                CatalogAccess.GetProductsInCategory(categoryId, page, out howManyPages);
                list.DataBind();
                // get first page url and pager format
                firstPageUrl = Link.ToCategory(departmentId, categoryId, "1");
                pagerFormat = Link.ToCategory(departmentId, categoryId, "{0}");
            }
            else if (departmentId != null)
            {
                // Retrieve list of products on department promotion
                list.DataSource = CatalogAccess.GetProductsOnDeptPromo
                (departmentId, page, out howManyPages);
                list.DataBind();
                // get first page url and pager format
                firstPageUrl = Link.ToDepartment(departmentId, "1");
                pagerFormat = Link.ToDepartment(departmentId, "{0}");
            }
            else
            {
                // Retrieve list of products on catalog promotion
                list.DataSource = CatalogAccess.GetProductsOnFrontPromo(page, out howManyPages);
                list.DataBind();
                // have the current page as integer
                int currentPage = Int32.Parse(page);

            }

            // Display pager controls
            topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, false);
            bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);
        }

        /// <summary>
        /// Executes when each item of the list is bound to the data source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void list_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            // Obtain the attributes of the product
            DataRowView dataRow = (DataRowView)e.Item.DataItem;
            string productId = dataRow["ProductID"].ToString();
            DataTable attrTable = CatalogAccess.GetProductAttributes(productId);

            // Get the attribute placeholder
            PlaceHolder attrPlaceHolder = (PlaceHolder)e.Item.FindControl("attrPlaceHolder");

            // Temp variables
            string prevAttributeName = "";
            string attributeName, attributeValue, attributeValueId;

            // Current dropdown for attribute values
            Label attributeNameLabel;
            DropDownList attributeValuesDropDown = new DropDownList();

            // Read the list of attributes
            foreach (DataRow r in attrTable.Rows)
            {
                // Get attribute data
                attributeName = r["AttributeName"].ToString();
                attributeValue = r["AttributeValue"].ToString();
                attributeValueId = r["AttributeValueID"].ToString();

                // If starting a new attribute (e.g. Color, Size)
                if (attributeName != prevAttributeName)
                {
                    prevAttributeName = attributeName;
                    attributeNameLabel = new Label();
                    attributeNameLabel.Text = attributeName + ": ";
                    attributeValuesDropDown = new DropDownList();
                    attrPlaceHolder.Controls.Add(attributeNameLabel);
                    attrPlaceHolder.Controls.Add(attributeValuesDropDown);
                }

                // Add a new attribute value to the DropDownList
                attributeValuesDropDown.Items.Add(new ListItem(attributeValue, attributeValueId));
            }
        }
    }
}