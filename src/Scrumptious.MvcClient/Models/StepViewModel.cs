using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumptious.MvcClient.Models
{
    public class StepViewModel
    {
        public string Name { get; set; }
        public string StepDescription { get; set; }
        public bool Completed { get; set; }
        public int FkTaskId { get; set; }
        public int StepId { get; set; }
    }
}
