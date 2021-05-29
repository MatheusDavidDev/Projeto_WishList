using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WishList.Domains
{
    public partial class Desejo
    {
        public int idDesejo { get; set; }
        public int? idUsuario { get; set; }
        public string descricao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime dataCriacao { get; set; }

        public virtual Usuario idUsuarioNavigation { get; set; }
    }
}
