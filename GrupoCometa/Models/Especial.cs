using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GrupoCometa.Data;
using GrupoCometa.Data.dsClienteTableAdapters;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace GrupoCometa.Models
{
    public class Especial
    {

        public int EmpleadosSuma { get; set; }

        public int ClientesCount { get; set; }

        public int FacturasCount { get; set; }

        public int ProductosSum { get; set; }

        /// <summary>
        /// Constuctor sin parametros 
        /// </summary>
        public Especial()
        {
            Data.dsFacturaTableAdapters.FacturasHeaderTableAdapter Adapter1 = new Data.dsFacturaTableAdapters.FacturasHeaderTableAdapter();
            this.FacturasCount = (int) Adapter1.CountFacturas();
            Data.dsClienteTableAdapters.ClienteTableAdapter Adapter2 =
                new Data.dsClienteTableAdapters.ClienteTableAdapter();
            this.ClientesCount = (int)Adapter2.CountClientes();
            Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter Adapter3 =
                new Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter();
            this.EmpleadosSuma = (int) Adapter3.SumEmpleados();
            Data.dsProductoTableAdapters.ProductosTableAdapter Adapter4 = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            this.ProductosSum = (int) Adapter4.SumProductosInv();


        }
        
    }
        
    }