using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.Common.Entities
{
    public class UsuTematica
    {
        public Int32 Id { get; set; }

        public Usuario Usuario { get; set; }

        public Tematica Tematica { get; set; }
    }
}
