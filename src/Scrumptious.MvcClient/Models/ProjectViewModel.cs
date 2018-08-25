using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scrumptious.MvcClient.Models
{
    public class ProjectViewModel
    {

        public ProjectViewModel() { 
              sprint = new HashSet<SprintViewModel>();
        }

        public string projectName { get; set; }
        public int projectId { get; set; }
        public string projectDescription { get; set; }
        public ICollection<SprintViewModel> sprint { get; set; }
        public bool active { get; set; }
        public string projectRequirements { get; set; }
      
    }
}