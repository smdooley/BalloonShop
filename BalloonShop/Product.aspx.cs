using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalloonShop.BusinessTier;
using System.Data;

namespace BalloonShop
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve ProductID from the query string
            string productId = Request.QueryString["ProductID"];

            // Retrieve product details
            ProductDetails productDetails = CatalogAccess.GetProductDetails(productId);

            // Does the product exist?
            if (productDetails.Name != null)
            {
                PopulateControls(productDetails);
            }
            else
            {
                Server.Transfer("~/NotFound.aspx");
            }

            // 301 redirect to the proper URL if necessary
            Link.CheckProductUrl(Request.QueryString["ProductID"]);
        }

        private void PopulateControls(ProductDetails productDetails)
        {
            // Display the product details
            titleLabel.Text = productDetails.Name;
            descriptionLabel.Text = productDetails.Description;
            priceLabel.Text = String.Format("{0:c}", productDetails.Price);
            productImage.ImageUrl = "ProductImages/" + productDetails.Image;

            // Set the page title
            this.Title = BalloonShopConfiguration.SiteName + productDetails.Name;

            // Obtain the attributes of the product
            DataTable attrTable = CatalogAccess.GetProductAttributes(productDetails.ProductID.ToString());

            // Temp variables
            string prevAttributeName = "";
            string attributeName, attributeValue, attributeValueId;

            // Current DropDown for attribute values
            Label attributeNameLabel;
            DropDownList attributeValuesDropDown = new DropDownList();

            // Read the list of attributes
            foreach (DataRow r in attrTable.Rows)
            {
                // Get the attribute data
                attributeName = r["AttributeName"].ToString();
                attributeValue = r["AttributeValue"].ToString();
                attributeValueId = r["AttributeValueID"].ToString();

                // If starting a new attribute (e.g. Colour, Size)
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