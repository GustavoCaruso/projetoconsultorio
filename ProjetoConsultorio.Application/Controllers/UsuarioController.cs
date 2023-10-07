using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjetoConsultorio.Application.Models;
using ProjetoConsultorio.Domain.entidades;
using ProjetoConsultorio.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoConsultorio.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _config;
        private IBaseService<Usuario> _service;
        public UsuarioController(IConfiguration Configuration,
            IBaseService<Usuario> service)
        {
            _config = Configuration;
            _service = service;
        }
        private string GerarTokenJWT()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(120);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer, audience: audience,
expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        private UsuarioModel ValidarUsuario(UsuarioModel loginDetalhes)
        {

            var usuario = _service.GetFiltro<UsuarioModel>(
               p => p.email == loginDetalhes.email
               && p.senha == loginDetalhes.senha, //where
               null,
               "", null).FirstOrDefault();

            return usuario;
        }

        [HttpPost]
        [Route("validaLogin")]
        public IActionResult Login([FromBody] UsuarioModel loginDetalhes)
        {
            UsuarioModel usu = ValidarUsuario(loginDetalhes);
            if (usu != null)
            {


                var tokenString = GerarTokenJWT();
                return Ok(new
                {
                    token = tokenString,
                    id = usu.id,
                    nome = usu.nome
                });
            }
            else
            {
                return Unauthorized();
            }
        }



    }
}
