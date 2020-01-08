using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using SchoolManage.Models;

namespace SchoolManage.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var mvcName = typeof(Controller).Assembly.GetName();
            var isMono = Type.GetType("Mono.Runtime") != null;

            ViewData["Version"] = mvcName.Version.Major + "." + mvcName.Version.Minor;
            ViewData["Runtime"] = isMono ? "Mono" : ".NET";

            return View();
        }


        public ActionResult GetHellos()
        {   
            IList<HellosViewModel> hellos = null;
            using(var client = new HttpClient())
            {
                var domain = $"{Request.Url.Scheme}{System.Uri.SchemeDelimiter}{Request.Url.Authority}";
                
                client.BaseAddress = new Uri(domain+"/api/");
                domain.ToString();
                var responseTask = client.GetAsync("getHellos");
                responseTask.Wait();

                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {

#pragma warning disable CS1701 // Assuming assembly reference matches identity
                    var readTask = result.Content.ReadAsAsync<IList<HellosViewModel>>();
#pragma warning restore CS1701 // Assuming assembly reference matches identity
                    readTask.Wait();
                    hellos = readTask.Result;
                }
                else
                {//error web api response
                    //log something
                    
                    hellos = (System.Collections.Generic.IList<SchoolManage.Models.HellosViewModel>)Enumerable.Empty<HellosViewModel>();
                    ModelState.AddModelError(string.Empty, "Error in fetching data from api");
                    
                }
               
                

            }
            /*
            hellos = new List<HellosViewModel>();
            hellos.Add(new HellosViewModel(fre: "Bonjur!!!", heb: "Shalom!!!", ara: "Marhaban!!!", eng: "Hey!!!"));
            ModelState.Clear();
            */
            return View(hellos);
        }
    }
}
