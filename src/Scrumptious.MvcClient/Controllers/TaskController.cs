using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Scrumptious.MvcClient.Models;
using System.Threading;
using System.Text;
namespace Scrumptious.Mvclient.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class TaskController : Controller
    {
        private readonly HttpClient http = new HttpClient();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var x = await http.GetAsync("http://localhost:62021/api/task/");
            var content = JsonConvert.DeserializeObject<TaskViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "List of Tasks";
            ViewBag.content = content;
            return View();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var x = await http.GetAsync("http://localhost:62021/api/task/" + id);
            var content = JsonConvert.DeserializeObject<TaskViewModel>(await x.Content.ReadAsStringAsync());
            ViewData["pagetitle"] = "List of Tasks";
            ViewBag.content = content;
            return View();
        }

        [HttpPost]
        public void Post()
        {
            var pvm = new TaskViewModel()
            {
                Name = "billy bob",
                Completed = false,
                Requirements = "some desc",
                TaskDescription = "something works"
            };
            var content = JsonConvert.SerializeObject(pvm);
            http.PostAsync("http://localhost:62021/api/task", new StringContent(content, Encoding.UTF8, "application/json"));
        }

    }
}