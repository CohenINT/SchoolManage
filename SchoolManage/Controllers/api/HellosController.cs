using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;
using SchoolManage.Models;

namespace SchoolManage.Controllers
{
    public class HellosController : ApiController
    {
        [HttpGet]
        [Route("api/getHellos")]
        public IHttpActionResult GetHellos()
        {
            IList<HellosViewModel> hellos = new List<HellosViewModel>();

            hellos.Add(new HellosViewModel(eng: "Hello!", ara: "Marhaban!", heb: "Shalom", fre: "Bonjur!"));

            hellos.ToList<HellosViewModel>();
            
            return Ok(hellos);
        
        }

        public HellosController()
        {

        }
            
    }
}
