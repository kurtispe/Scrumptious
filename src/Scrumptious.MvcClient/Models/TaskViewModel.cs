using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumptious.MvcClient.Models
{
    public class TaskViewModel
    {
        public string Name { get; set; }
        public string TaskDescription { get; set; }
        public string Requirements { get; set; }
        public bool Completed { get; set; }
        public List<StepViewModel> Step { get; set; }
        public int FkBacklogId { get; set; }
        public int TaskId { get; set; }
        public int FkUserId { get; set; }
    }
}