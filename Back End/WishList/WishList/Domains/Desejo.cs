using System;
using System.Collections.Generic;

#nullable disable

namespace WishList.Domains
{
    public partial class Desejo
    {
        public int idDesejo { get; set; }
        public int? idUsuario { get; set; }
        public string descricao { get; set; }
        public DateTime dataCriacao { get; set; }

        public virtual Usuario idUsuarioNavigation { get; set; }
    }
}
