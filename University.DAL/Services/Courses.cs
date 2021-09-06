using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DAL.Interfaces;
using University.DTO.Modals;

namespace University.DAL.Services
{
    public class Courses : ICourses
    {
        public List<SearchResult> GetCourses(int gpa, int gre, string country, string courseName)
        {
            using(SqlConnection con = new SqlConnection(@"Data Source=SANDEEP\SQLEXPRESS;Initial Catalog=University;Integrated Security=true;"))
            {
                con.Open();
                var query = "Select C.[Name] as Course, U.Country, U.[Description] AS University "
                            + "FROM Courses as C "
                            + "JOIN Universities AS U on U.Id = C.University_Id "
                            + $"Where U.Minimum_GPA >= {gpa} "
                            + $"and U.Minimum_GRE_Score >= {gre} "
                            + $"and U.Country = '{country}' "
                            + $"and C.[Name] like '%{courseName}%' ";

                SqlCommand command = new SqlCommand(query, con);
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    List<SearchResult> result = new List<SearchResult>();
                    while (reader.Read())
                    {
                        result.Add(new SearchResult { Course = reader[0].ToString(), Country = reader[1].ToString(), University = reader[2].ToString() });
                    }
                    return result;
                }
            }
        }
    }
}
