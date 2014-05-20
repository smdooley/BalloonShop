using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalloonShop.BusinessTier;

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
        }
    }
}