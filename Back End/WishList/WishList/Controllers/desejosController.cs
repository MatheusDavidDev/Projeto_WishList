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
    /// <summary>
    /// Controller responsável pelos endpoints referentes às presenças
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato domínio/api/NomeController
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class DesejosController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _desejoRepository que irá receber todos os métodos definidos na interface
        /// </summary>
        private IDesejoRepository _desejoRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public DesejosController()
        {
            _desejoRepository = new DesejoRepository();
        }               

        /// <summary>
        /// Lista os desejos de quem estiver logado,caso tenha cadastrado
        /// </summary>
        /// <param name="id">id do usuario logado</param>
        /// <returns>lista de desejos do usuario logado</returns>
        [HttpGet("{id}")]
        public IActionResult GetMy(int id)
        {
            try
            {
                return Ok(_desejoRepository.Listar(id));
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
        /// <returns>status code 201</returns>
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

        /// <summary>
        /// Deleta um desejo do usuário logado
        /// </summary>
        /// <param name="id">id do desejo a ser deletado</param>
        /// <returns>status code 204</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _desejoRepository.Deletar(id);

            return StatusCode(204);
        }
    }
}
