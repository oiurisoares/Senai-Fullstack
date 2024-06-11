using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Exo.WebApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Area { get; set; }
        public bool Status { get; set; }
    }
}