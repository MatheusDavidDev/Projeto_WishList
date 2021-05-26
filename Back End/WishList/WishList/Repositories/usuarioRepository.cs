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
    public class usuarioRepository : IusuarioRepository
    {
        WishListContext ctx = new WishListContext();
        public Usuario BuscarPorID(int id)
        {
            return ctx.Usuarios
                .Include(u => u.)
        }

        public List<Usuario> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
