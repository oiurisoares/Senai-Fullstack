using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace Exo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectRepository
        _projectRepository;
        public ProjectsController(ProjectRepository
        projectRepository)
        {
            _projectRepository = projectRepository;
        }
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_projectRepository.List());
        }

        [HttpPost]
        public IActionResult Register(Project project)
        {
            _projectRepository.Register(project);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult SearchById(int id)
        {
            Project project = _projectRepository.SearchById(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Project project)
        {
            _projectRepository.Update(id, project);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _projectRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
