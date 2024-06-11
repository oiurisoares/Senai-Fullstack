using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
namespace Exo.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository
        userRepository)
        {
            _userRepository = userRepository;
        }
        // get -> /api/usuarios
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_userRepository.List());
        }
        // post -> /api/usuarios
        [HttpPost]
        public IActionResult Register(User user)
        {
            _userRepository.Register(user);
            return StatusCode(201);
        }
        // get -> /api/usuarios/{id}
        [HttpGet("{id}")] // Faz a busca pelo ID.
        public IActionResult SearchById(int id)
        {
            User user = _userRepository.SearchById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        // put -> /api/usuarios/{id}
        // Atualiza.
        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            _userRepository.Update(id, user);
            return StatusCode(204);
        }
        // delete -> /api/usuarios/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userRepository.Delete(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}