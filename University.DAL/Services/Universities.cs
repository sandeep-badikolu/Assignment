using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Interfaces;

namespace University.DAL.Services
{
    public class Universities : IUniversities
    {
        public List<string> GetAllCountries()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=SANDEEP\SQLEXPRESS;Initial Catalog=University;Integrated Security=true;"))
            {
                con.Open();
                var query = "SELECT DISTINCT Country FROM [dbo].[Universities] ORDER BY Country";

                SqlCommand command = new SqlCommand(query, con);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<string> result = new List<string>();
                    while (reader.Read())
                    {
                        result.Add(reader[0].ToString());
                    }
                    return result;
                }
            }
        }
    }
}
