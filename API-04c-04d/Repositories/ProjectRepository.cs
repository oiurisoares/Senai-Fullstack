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

        public void Register(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }
        public Project SearchById(int id)
        {
            return _context.Projects.Find(id);
        }

        public void Update(int id, Project project)
        {
            Project findedProject = _context.Projects.Find(id);
            if (findedProject != null)
            {
                findedProject.ProjectName = project.ProjectName;
                findedProject.Area = project.Area;
                findedProject.Status = project.Status;
            }
            _context.Projects.Update(findedProject);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Project findedProject = _context.Projects.Find(id);
            _context.Projects.Remove(findedProject);
            _context.SaveChanges();
        }
    }
}