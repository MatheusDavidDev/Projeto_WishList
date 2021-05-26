using System;
using System.Collections.Generic;

#nullable disable

namespace WishList.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Desejos = new HashSet<Desejo>();
        }

        public int idUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }

        public virtual ICollection<Desejo> Desejos { get; set; }
    }
}
