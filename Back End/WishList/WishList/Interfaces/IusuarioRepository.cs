using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.Domains;

namespace WishList.Interfaces
{
    interface IUsuarioRepository
    {
        Usuario Login(string email, string senha);
    }
}
