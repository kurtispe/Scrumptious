﻿using System;
using System.Collections.Generic;

namespace Scrumptious.Library.Models
{
    public partial class Backlog
    {
        public Backlog()
        {
            Task = new HashSet<Task>();
        }

        public void AddTask()
        {
            Task.Add(new Models.Task());
        }
        
        public ICollection<Task> Task { get; set; }
    }
}
