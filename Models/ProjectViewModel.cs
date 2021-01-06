using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace ManagerAssistant.Models
{
    public class ProjectViewModel
    {
        public Project ProjectsData { get; set; }
        public List<Project> Projects { get; set; }
    }
}
