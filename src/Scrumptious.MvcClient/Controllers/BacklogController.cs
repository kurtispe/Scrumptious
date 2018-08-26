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
        public async Task<IActionResult> Get()
        {
            var x = await http.GetAsync("http://localhost:62021/api/backlog");
            var content = JsonConvert.DeserializeObject<BacklogViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";
            ViewBag.content = content;
            return View();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = await http.GetAsync("http://localhost:62021/api/backlog/" + id);
            var content = JsonConvert.DeserializeObject<BacklogViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "Scrumptious";
            ViewBag.Title = "Scrumptious, the Scrum Master Program!";
            ViewBag.content = content;
            return View();
        }

        [HttpPost]
        public void Post(BacklogViewModel data)
        {
            var content = JsonConvert.SerializeObject(data);
            http.PostAsync("http://localhost:62021/api/backlog", new StringContent(content, Encoding.UTF8, "application/json"));
        }

    }
}