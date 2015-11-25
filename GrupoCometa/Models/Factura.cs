using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Models
{
    public class FacturaHeader
    {
        [Display(Name = "Código de Factura")]
        public int idFacturaHeader { get; set; }
        [Display(Name = "Cliente")]
        public int idCliente { get; set; }
        [Display(Name = "Tipo de Pago")]
        public int idTipoPago { get; set; }
        [Display(Name = "Empleado")]
        public int idEmpleado { get; set; }
        [Display(Name = "Fecha")]
        public DateTime dtFechaPago { get; set; }
        [Display(Name = "Total")]
        public decimal mTotal { get; set; }

        [Display(Name = "Código de Factura")]
        public string cEmpresa { get; set; }

        //Objetos
        public Cliente clienteActual { get; set; }
        public List<FacturaDetalle> listaDetalle { get; set; }
        public List<SelectListItem> listaClientes { get; set; }
        public List<SelectListItem> listaTiposPago { get; set; }
        public List<SelectListItem> listaEmpleados { get; set; }
        public List<SelectListItem> listaProductos { get; set; }

        public FacturaHeader() { }

        public FacturaHeader(int idFacturaHeader)
        {
            Data.dsFacturaTableAdapters.FacturasHeaderTableAdapter Adapter = new Data.dsFacturaTableAdapters.FacturasHeaderTableAdapter();
            Data.dsFactura.FacturasHeaderDataTable dt = Adapter.SelectListaFacturasHeader(idFacturaHeader);

            if (dt.Rows.Count > 0)
            {
                Data.dsFactura.FacturasHeaderRow dr = dt[0];
                this.idFacturaHeader = dr.idFacturaHeader;
                this.idCliente = dr.idCliente;
                this.idTipoPago = dr.idTipoPago;
                if (!dr.IsidEmpleadoNull())
                    this.idEmpleado = dr.idEmpleado;
                if (!dr.IsdtFechaPagoNull())
                    this.dtFechaPago = dr.dtFechaPago;
                if (!dr.IsmTotalNull())
                    this.mTotal = dr.mTotal;
                if (!dr.IscEmpresaNull())
                    this.cEmpresa = dr.cEmpresa.Trim();

                this.clienteActual = new Cliente(this.idCliente);
                this.listaDetalle = FacturaDetalle.GetListaFacturasDetalle(this.idFacturaHeader);
            }
        }

        public static List<FacturaHeader> GetListaFacturas()
        {
            List<FacturaHeader> listaFacturas = new List<FacturaHeader>();
            Data.dsFacturaTableAdapters.FacturasHeaderTableAdapter Adapter = new Data.dsFacturaTableAdapters.FacturasHeaderTableAdapter();
            Data.dsFactura.FacturasHeaderDataTable dt = Adapter.SelectListaFacturasHeader(null);

            foreach(var dr in dt)
            {
                FacturaHeader temp = new FacturaHeader();
                temp.idFacturaHeader = dr.idFacturaHeader;
                temp.idCliente = dr.idCliente;
                temp.idTipoPago = dr.idTipoPago;
                if (!dr.IsidEmpleadoNull())
                    temp.idEmpleado = dr.idEmpleado;
                if (!dr.IsdtFechaPagoNull())
                    temp.dtFechaPago = dr.dtFechaPago;
                if (!dr.IsmTotalNull())
                    temp.mTotal = dr.mTotal;
                if (!dr.IscEmpresaNull())
                    temp.cEmpresa = dr.cEmpresa.Trim();

                listaFacturas.Add(temp);
            }

            return listaFacturas;
        }

        public void GetSelectLists()
        {
            //public List<SelectListItem> listaClientes { get; set; }
            //public List<SelectListItem> listaTiposPago { get; set; }
            //public List<SelectListItem> listaEmpleados { get; set; }
            //public List<SelectListItem> listaProductos { get; set; }
        }
    }

    public class FacturaDetalle
    {
        public int idFacturaDetalle { get; set; }
        public int idFacturaHeader { get; set; }
        public int idProducto { get; set; }
        public int nCantidad { get; set; }

        public string cNombre { get; set; }

        public FacturaDetalle() { }

        public static List<FacturaDetalle> GetListaFacturasDetalle(int idFacturaHeader)
        {
            List<FacturaDetalle> listaFacturas = new List<FacturaDetalle>();
            Data.dsFacturaTableAdapters.FacturasDetalleTableAdapter Adapter = new Data.dsFacturaTableAdapters.FacturasDetalleTableAdapter();
            Data.dsFactura.FacturasDetalleDataTable dt = Adapter.SelectListaFacturasDetalle(idFacturaHeader, null);


            foreach(var dr in dt)
            {
                FacturaDetalle temp = new FacturaDetalle();
                temp.idFacturaDetalle = dr.idFacturaDetalle;
                temp.idFacturaHeader = dr.idFacturaHeader;
                temp.idProducto = dr.idProducto;
                
                temp.cNombre = dr.cNombre.Trim();
                if (!dr.IsnCantidadNull())
                    temp.nCantidad = dr.nCantidad;
                listaFacturas.Add(temp);
            }
            return listaFacturas;
        }
    }
}