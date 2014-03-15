using System.Data;
using System.Data.Common;
using System;

namespace BalloonShop.BusinessTier
{
    #region structs

    /// <summary>
    /// Wraps department details data
    /// </summary>
    public struct DepartmentDetails
    {
        public string Name;
        public string Description;
    }

    /// <summary>
    /// Wraps category details data
    /// </summary>
    public struct CategoryDetails
    {
        public int DepartmentID;
        public string Name;
        public string Description;
    }

    /// <summary>
    /// Wraps product details data
    /// </summary>
    public struct ProductDetails
    {
        public int ProductID;
        public string Name;
        public string Description;
        public decimal Price;
        public string Thumbnail;
        public string Image;
        public bool PromoFront;
        public bool PromoDept;
    }

    #endregion

    /// <summary>
    /// Product catalog business tier component
    /// </summary>
    public static class CatalogAccess
    {
        static CatalogAccess()
        {
        }

        /// <summary>
        /// Retrieve the list of departments
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDepartments()
        {
            // Get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // Set the stored procedure name
            comm.CommandText = "GetDepartments";
            // Execute the stored procedure and return the results
            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        /// <summary>
        /// Get department details
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public static DepartmentDetails GetDepartmentDetails(string departmentID)
        {
            // Get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();

            // Set the stored procedure name
            comm.CommandText = "CatalogGetDepartmentDetails";

            // Create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DepartmentID";
            param.Value = departmentID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // Execute the store procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            // Wrap retrieved data into a DepartmentDetails object
            DepartmentDetails details = new DepartmentDetails();
            if (table.Rows.Count > 0)
            {
                details.Name = table.Rows[0]["Name"].ToString();
                details.Description = table.Rows[0]["Description"].ToString();
            }

            // Return department details
            return details;
        }

        /// <summary>
        /// Get category details
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static CategoryDetails GetCategoryDetails(string categoryID)
        {
            // Get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();

            // Set the stored procedure name
            comm.CommandText = "CatalogGetCategoryDetails";

            // Create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CategoryID";
            param.Value = categoryID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // Execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            // Wrap retrieved data into a CategoryDetails object
            CategoryDetails details = new CategoryDetails();

            if (table.Rows.Count > 0)
            {
                details.DepartmentID = Int32.Parse(table.Rows[0]["DepartmentID"].ToString());
                details.Name = table.Rows[0]["Name"].ToString();
                details.Description = table.Rows[0]["Description"].ToString();
            }

            // Return category details
            return details;
        }

        /// <summary>
        /// Get product details
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static ProductDetails GetProductDetails(string productID)
        {
            //-- get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            //-- set the stored procedure name
            comm.CommandText = "CatalogGetProductDetails";
            //-- create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@ProductID";
            param.Value = productID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //-- execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            //-- wrap retrieved data into a ProductDetails object
            ProductDetails productDetails = new ProductDetails();
            if (table.Rows.Count > 0)
            {
                //-- get the first table row
                DataRow dr = table.Rows[0];

                //-- get product details
                productDetails.ProductID = int.Parse(productID);
                productDetails.Name = dr["Name"].ToString();
                productDetails.Description = dr["Description"].ToString();
                productDetails.Price = Decimal.Parse(dr["Price"].ToString());
                productDetails.Thumbnail = dr["Thumbnail"].ToString();
                productDetails.Image = dr["Image"].ToString();
                productDetails.PromoFront = bool.Parse(dr["PromoFront"].ToString());
                productDetails.PromoDept = bool.Parse(dr["PromoDept"].ToString());
            }

            //-- return product details
            return productDetails;
        }

        /// <summary>
        /// Retrieve the list of categoires in a department
        /// </summary>
        /// <param name="departmentID"></param>
        /// <returns></returns>
        public static DataTable GetCategoriesInDepartment(string departmentID)
        {
            //-- get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            
            //-- set the stored procedure name
            comm.CommandText = "CatalogGetCategoriesInDepartment";
            
            //-- create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DepartmentID";
            param.Value = departmentID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //-- execute the stored procedure
            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        /// <summary>
        /// Retrieve the list of products on catalog promotion
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="howManyPages"></param>
        /// <returns></returns>
        public static DataTable GetProductsOnFrontPromo(int pageNumber, out int howManyPages)
        {
            //-- get a confiured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();

            //-- set the stored procedure name
            comm.CommandText = "CatalogGetProductsOnFrontPromo";

            //-- create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = BalloonShopConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //-- create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //-- create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = BalloonShopConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //-- create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //-- execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            
            //-- calculate how many pages of products and set the out parameter
            int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)BalloonShopConfiguration.ProductsPerPage);

            //-- return the page of products
            return table;
        }

        /// <summary>
        /// Retrieve the list of products featured for a department
        /// </summary>
        /// <param name="departmentID"></param>
        /// <param name="pageNumber"></param>
        /// <param name="howManyPages"></param>
        /// <returns></returns>
        public static DataTable GetProductsOnDeptPromo(string departmentID, string pageNumber, out int howManyPages)
        {
            //-- get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            comm.CommandText = "CatalogGetProductsOnDeptPromo";

            //-- create the parameters
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DepartmentID";
            param.Value = departmentID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = BalloonShopConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = BalloonShopConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //-- execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)BalloonShopConfiguration.ProductsPerPage);

            //-- return the page of products
            return table
        }

        /// <summary>
        /// Retrieve the list of products in a category
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="pageNumber"></param>
        /// <param name="howManyPages"></param>
        /// <returns></returns>
        public static DataTable GetProductsInCategory(string categoryID, string pageNumber, out int howManyPages)
        {
            //-- get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();

            //-- set the stored procedure name
            comm.CommandText = "CatalogGetProductsInCategory";

            //-- create stored procedure parameter(s)
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@CategoryID";
            param.Value = categoryID;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@DescriptionLength";
            param.Value = BalloonShopConfiguration.ProductDescriptionLength;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = BalloonShopConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            //-- execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);

            //-- calculate homw many pages of products and set the out parameter
            int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts / (double)BalloonShopConfiguration.ProductsPerPage);

            //-- return the page of products
            return table;
        }
    }
}