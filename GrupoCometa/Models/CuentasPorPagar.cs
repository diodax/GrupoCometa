﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrupoCometa.Models
{
    public class CuentasPorPagar
    {
        public int idTransaccion { get; set; }
        public int idFacturaHeader { get; set; }
        public decimal mBalance { get; set; }

        public CuentasPorPagar() { }
    }
}