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
    public class UsuarioRepository : IUsuarioRepository
    {
        WishListContext ctx = new WishListContext();

        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.email == email && u.senha == senha);
        }
    }
}
