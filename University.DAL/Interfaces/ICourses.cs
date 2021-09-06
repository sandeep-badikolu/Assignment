using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University.DTO.Modals;

namespace University.DAL.Interfaces
{
    public interface ICourses
    {
        List<SearchResult> GetCourses(int gpa, int gre, string country, string courseName);
    }
}
