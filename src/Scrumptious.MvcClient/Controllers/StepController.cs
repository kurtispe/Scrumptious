using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Scrumptious.MvcClient.Models;
using System.Threading;
using System.Text;
using System.Collections.Generic;

namespace Scrumptious.MvcClient.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class StepController : Controller
    {
        private readonly HttpClient http = new HttpClient();

        [HttpGet]
        public IActionResult Get()
        {
         
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";
           
            ViewBag.userQuery = false;
            return View();
        }

        [HttpGet("{sort}")]
        public IActionResult Get(string id)
        {
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";
            string s = Request.Query["ID"];
            ViewBag.userQuery = true;
            return Redirect("/step/" + s);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = await http.GetAsync("http://localhost:62021/api/step/" + id);
            var content = JsonConvert.DeserializeObject<StepViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";

            ViewBag.content = content;
            ViewBag.userQuery = true;
            return View();
        }

        [HttpPost]
        public IActionResult Post(StepViewModel data)
        {
            data.Completed = false;
            var content = JsonConvert.SerializeObject(data);
            http.PostAsync("http://localhost:62021/api/step", new StringContent(content, Encoding.UTF8, "application/json"));
            return Redirect("/step");
        }

    }
}