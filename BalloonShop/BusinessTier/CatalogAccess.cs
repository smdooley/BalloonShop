using System.Data;
using System.Data.Common;

namespace BalloonShop.BusinessTier
{
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
    }
}