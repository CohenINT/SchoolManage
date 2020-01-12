using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using MySql.Data.MySqlClient;
using SchoolManage.Models;

namespace SchoolManage.Controllers
{

   
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
    [RoutePrefix("api")]
    public class HellosController : ApiController
    {
        [HttpGet]
        [Route("getHellos")]
        public IHttpActionResult GetHellos()
        {
            IList<HellosViewModel> hellos = new List<HellosViewModel>();
            //TODO: Get hellos from database
            hellos.Add(new HellosViewModel(eng: "Hello!", ara: "Marhaban!", heb: "Shalom", fre: "Bonjur!"));
            return Content<IList<HellosViewModel>>(HttpStatusCode.Accepted, hellos);

        }
        
        [HttpPost]
        [Route("postHello")]
        public async Task<IHttpActionResult> postHello([FromBody] ApiModel body)
        {
            try
            {
                string _con = "Server=127.0.0.1;Database=HellosDBu;Uid=root;Pwd=12345678;";
                using (MySqlConnection con = new MySqlConnection(_con))
                {
                    string _cmd = string.Format("INSERT INTO hellotb (name, lang, hello) VALUES('{0}','{1}','{2}'); ",body.Content.name,body.Content.lang,body.Content.hello);  
                    using (MySqlCommand cmd = new MySqlCommand(_cmd,con))
                    {
                        con.Open();
                        await cmd.ExecuteNonQueryAsync();
                        con.Close();
                    }
                }
                return Ok(string.Format("its good, {0}", body.Content.name));
                
            }
            catch (Exception ex)
            {
                return base.Content(HttpStatusCode.InternalServerError, ex.ToString());
            }
        }

        public HellosController()
        {
            
        }
            
    }
}
