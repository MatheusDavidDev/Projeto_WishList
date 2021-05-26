﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.Domains;

namespace WishList.Interfaces
{
    interface IDesejoRepository
    {
        List<Desejo> Listar();

        List<Desejo> Listar(int id);

        void Cadastrar(Desejo novoDesejo);

    }
}
