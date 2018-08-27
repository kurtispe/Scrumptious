using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Scrumptious.MvcClient.Models;
using System.Threading;
using System.Text;

namespace Scrumptious.MvcClient.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class BacklogController : Controller
    {
        private readonly HttpClient http = new HttpClient();

        [HttpGet]
        public IActionResult Get()
        {
          
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";
            return View();
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Post(BacklogViewModel data)
        {
            var content = JsonConvert.SerializeObject(data);
            await http.PostAsync("http://localhost:62021/api/backlog", new StringContent(content, Encoding.UTF8, "application/json"));
            return Redirect("/backlog");
        }

    }
}