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
    }
}
