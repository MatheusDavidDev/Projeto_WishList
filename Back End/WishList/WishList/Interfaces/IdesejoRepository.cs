using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.Domains;

namespace WishList.Interfaces
{
    interface IDesejoRepository
    {        
        /// <summary>
        /// Listar todos os desejos de um determinado usuário 
        /// </summary>
        /// <param name="id">id do usuário a ser listado os desejos</param>
        /// <returns>lista de desejos do usuário</returns>
        List<Desejo> Listar(int id);

        /// <summary>
        /// Cadastrar um novo desejo
        /// </summary>
        /// <param name="novoDesejo">objeto do tipo Desejo</param>
        void Cadastrar(Desejo novoDesejo);

        /// <summary>
        /// Deletar um desejo
        /// </summary>
        /// <param name="id">id do desejo a ser deletado</param>
        void Deletar(int id);

    }
}
