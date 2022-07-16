using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Tests
{
    public class ConnectoSqlServerTest
    {

        [Fact]
        public void connectoToSqlServer()
        {

            Configuration configuration = ConfigurationAppSettings.Configuration();

            string connectionString = configuration.ConnectionStrings.ConnectionStrings["testtmpdb"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                try
                {
                    connection.Close();
                }
                catch (Exception)
                {
                }
                
            }

            Assert.True(true);

        }
    }
}
