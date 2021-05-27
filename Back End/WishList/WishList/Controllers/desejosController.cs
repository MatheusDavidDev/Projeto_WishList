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
    public class DesejosController : ControllerBase
    {
        private IDesejoRepository _desejoRepository { get; set; }

        public DesejosController()
        {
            _desejoRepository = new DesejoRepository();
        }

        /// <summary>
        /// Lista todos os desejos dos usuários
        /// </summary>
        /// <returns>lista de desejos dos usuários</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_desejoRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Método para listar os desejos de um determinado usuario
        /// </summary>
        /// <param name="user">objeto tipo usuario que será passado no corpo da requisição</param>
        /// <returns>Lista dos desejos do usuário buscado</returns>    
        [HttpGet("Minhas")]
        public IActionResult GetMy(Usuario user)
        {
            try
            {
                return Ok(_desejoRepository.Listar(user));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        /// <summary>
        /// Cadastra um novo desejo para um usuário
        /// </summary>
        /// <param name="novoDesejo">objeto do tipo Desejo que será cadastrado</param>
        /// <returns>um novo desejo</returns>
        [HttpPost]
        public IActionResult Post(Desejo novoDesejo)
        {
            try
            {
                _desejoRepository.Cadastrar(novoDesejo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
