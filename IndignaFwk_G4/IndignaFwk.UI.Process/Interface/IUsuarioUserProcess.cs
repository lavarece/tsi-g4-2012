﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndignaFwk.Business.Entities;

namespace IndignaFwk.UI.Process
{
    public interface IUsuarioUserProcess
    {
        Int32 CrearUsuario(Usuario usuario);
    }
}