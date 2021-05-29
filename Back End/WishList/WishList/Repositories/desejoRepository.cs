using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.Contexts;
using WishList.Domains;
using WishList.Interfaces;

namespace WishList.Repositories
{
    public class DesejoRepository : IDesejoRepository
    {
        WishListContext ctx = new WishListContext();              

        /// <summary>
        /// Método para listar desejos de um determinado usuário
        /// </summary>
        /// <param name="id">id do usuário a ser listado os desejos</param>
        /// <returns>lista dos desejos do usuário que estiver logado</returns>
        public List<Desejo> Listar(int id)
        {
            return ctx.Desejos

                .Include(d => d.idUsuarioNavigation)

                .Select(d => new Desejo
                {
                    idDesejo = d.idDesejo,
                    descricao = d.descricao,
                    dataCriacao = d.dataCriacao,

                    idUsuarioNavigation = new Usuario
                    {
                        idUsuario = d.idUsuarioNavigation.idUsuario,
                        email = d.idUsuarioNavigation.email,
                        senha = d.idUsuarioNavigation.senha,
                    }
                })
                
                .Where(d => d.idUsuarioNavigation.idUsuario == id )

                .ToList();
        }

        /// <summary>
        /// Método para cadastrar um novo desejo
        /// </summary>
        /// <param name="novoDesejo">objeto do tipo Desejo</param>
        public void Cadastrar(Desejo novoDesejo)
        {
            novoDesejo.dataCriacao = DateTime.Now;

            ctx.Desejos.Add(novoDesejo);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Método para deletar um desejo do usuário
        /// </summary>
        /// <param name="id">id do desejo a ser excluido</param>
        public void Deletar (int id)
        {
            Desejo desejo = ctx.Desejos.Find(id);

            ctx.Desejos.Remove(desejo);

            ctx.SaveChanges();
        }
    }
}
