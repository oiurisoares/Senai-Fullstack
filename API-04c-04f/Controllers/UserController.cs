using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public IActionResult Post(User user)
        {
            User findedUser = _userRepository.Login(user.Email,
            user.Password);
            if (findedUser == null)
            {
                return NotFound("E-mail ou senha inválidos!");
            }

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Email, findedUser.Email),
            new Claim(JwtRegisteredClaimNames.Jti,
            findedUser.Id.ToString()),
            };

            var key = new
            SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chaveautenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "exoapi.webapi",
                audience: "exoapi.webapi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            return Ok(
            new { token = new JwtSecurityTokenHandler().WriteToken(token) }
            );
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
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Update(int id, User user)
        {
            _userRepository.Update(id, user);
            return StatusCode(204);
        }
        // delete -> /api/usuarios/{id}
        [Authorize]
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