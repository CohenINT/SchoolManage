using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

using System.Web.Http;
using System.Web.Http.Results;
using SchoolManage.Models;

namespace SchoolManage.Controllers
{

   
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("")]
    public class HellosController : ApiController
    {
        [HttpGet]
        [Route("api/getHellos")]
        public IHttpActionResult GetHellos()
        {
            IList<HellosViewModel> hellos = new List<HellosViewModel>();
            
            hellos.Add(new HellosViewModel(eng: "Hello!", ara: "Marhaban!", heb: "Shalom", fre: "Bonjur!"));
            return Content<IList<HellosViewModel>>(HttpStatusCode.Accepted, hellos);

             


        }

        public HellosController()
        {
            
        }
            
    }
}
