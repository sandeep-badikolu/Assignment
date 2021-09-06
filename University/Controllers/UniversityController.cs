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
    [RoutePrefix("api/university")]
    public class UniversityController : ApiController
    {
        [Route("countries")]
        public IHttpActionResult GetAllCountries()
        {
            var res = new Universities().GetAllCountries();
            return Ok(res);
        }
    }
}
