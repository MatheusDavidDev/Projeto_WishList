using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.Domains;

namespace WishList.Interfaces
{
    interface IusuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorID(int id);
    }
}
