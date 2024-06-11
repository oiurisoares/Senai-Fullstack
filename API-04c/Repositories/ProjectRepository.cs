using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Exo.WebApi.Repositories
{
    public class ProjectRepository
    {
        private readonly ExoContext _context;
        public ProjectRepository(ExoContext context)
        {
            _context = context;
        }
        public List<Project> List()
        {
            return _context.Projects.ToList();
        }
    }
}