using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCookBook.WCFDataService
{
    public class DapperTest
    {
        private string connString = @"Data Source=(LocalDb)\MSSQLLocalDB;Database=WpfForHumansDevDB;Trusted_Connection=True;MultipleActiveResultSets=true";

        public ModuleDao GetModuleByID(long id = 1)
        {
            using (IDbConnection dbConnection = new SqlConnection(connString))
            {
                dbConnection.Open();
                var result = dbConnection.QuerySingleOrDefault<ModuleDao>("dbo.GetModuleByID", new { ID = 1 }, commandType: CommandType.StoredProcedure);

                return result;
            }
        }


    }
}
