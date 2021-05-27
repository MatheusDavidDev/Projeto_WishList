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
        /// Método para cadastrar um novo desejo
        /// </summary>
        /// <param name="novoDesejo">objeto do tipo Desejo</param>
        public void Cadastrar(Desejo novoDesejo)
        {
            ctx.Desejos.Add(novoDesejo);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Método para listar os desejos de todos os usuários
        /// </summary>
        /// <returns>Lista dos desejos e seus usuários</returns>
        public List<Desejo> Listar()
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
                        email = d.idUsuarioNavigation.email
                    }
                })
                                
                .ToList();                
        }

        /// <summary>
        /// Método para listar os desejos de um determinado usuario
        /// </summary>
        /// <param name="user">objeto tipo usuario que será passado no corpo da requisição</param>
        /// <returns>Lista dos desejos do usuário buscado</returns>
        public List<Desejo> Listar(Usuario user)
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

                //.Where(d => d.idUsuarioNavigation.idUsuario == id)

                .Where(d => d.idUsuarioNavigation.email == user.email && d.idUsuarioNavigation.senha == user.senha)

                .ToList();
        }
    }
}
