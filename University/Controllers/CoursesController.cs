using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using University.DAL.Services;

namespace University.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/courses")]
    public class CoursesController : ApiController
    {
        //[Route("{gpa:int,}")]
        public IHttpActionResult Get(int gpa, int gre, string country, string courseName)
        {
            var res = new Courses().GetCourses(gpa, gre, country, courseName);
            return Ok(res);
        }
    }
}
