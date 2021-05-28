using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.Domains;
using WishList.Interfaces;
using WishList.Repositories;

namespace WishList.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Envia os dados do usuário que será logado
        /// </summary>
        /// <param name="user">objeto do tipo usuario a ser logado</param>
        /// <returns>um usuário com email e senha</returns>
        [HttpPost]
        public IActionResult Login(Usuario user)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(user.email, user.senha);

                if (usuarioBuscado == null)
                {
                    return NotFound("E-mail ou senha inválidos!");
                }
                return Ok(_usuarioRepository.Login(user.email,user.senha));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
