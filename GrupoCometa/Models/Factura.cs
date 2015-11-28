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
        [Display(Name = "Clave")]
        public int idFacturaHeader { get; set; }
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo es requerido")]
        public int idCliente { get; set; }
        [Display(Name = "Tipo de Pago")]
        [Required(ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo es requerido")]
        public int idTipoPago { get; set; }
        [Display(Name = "Empleado")]
        public int idEmpleado { get; set; }
        [Display(Name = "Fecha")]
        public DateTime dtFechaPago { get; set; }
        [Display(Name = "Total")]
        [DataType(DataType.Currency)]
        public decimal mTotal { get; set; }

        [Display(Name = "Empresa")]
        public string cEmpresa { get; set; }

        //Objetos
        public Cliente clienteActual { get; set; }
        public FacturaDetalle facturaDetalleActual { get; set; }

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
                this.GetSelectLists();
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

        /// <summary>
        /// Genera el contenido del dropbdown con los tipos de pago
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetListaTiposPago()
        {
            List<SelectListItem> listaTipos = new List<SelectListItem>();
            Data.dsFacturaTableAdapters.TiposPagoTableAdapter Adapter = new Data.dsFacturaTableAdapters.TiposPagoTableAdapter();
            Data.dsFactura.TiposPagoDataTable dt = Adapter.SelectListaTiposPago(null);
            
            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idTipoPago.ToString();
                item.Text = dr.cDescripcion;
                listaTipos.Add(item);
            }

            return listaTipos;
        }

        /// <summary>
        /// Genera la lista de productos de la DB
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetListaClientes()
        {
            List<SelectListItem> listaClientes = new List<SelectListItem>();
            Data.dsClienteTableAdapters.ClienteTableAdapter Adapter = new Data.dsClienteTableAdapters.ClienteTableAdapter();
            Data.dsCliente.ClienteDataTable dt = Adapter.SelectListaClientes();

            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idCliente.ToString().Trim();
               
                if (!dr.IscEmpresaNull())
                    item.Text = "[" + item.Value + "] " + dr.cEmpresa;

                listaClientes.Add(item);
            }

            return listaClientes;
        }

        public void GetSelectLists()
        {
            this.listaClientes = FacturaHeader.GetListaClientes();
            this.listaTiposPago = FacturaHeader.GetListaTiposPago();
            this.listaEmpleados = Empleado.GetSelectListEmpleado();
            this.listaProductos = Producto.GetSelectListProducto(); 
        }

        public int InsertUpdateFactura()
        {
            Data.dsFacturaTableAdapters.FacturasHeaderTableAdapter Adapter = new Data.dsFacturaTableAdapters.FacturasHeaderTableAdapter();
            return (int)Adapter.InsertUpdateFacturaHeader(this.idFacturaHeader, this.idCliente, this.idTipoPago, this.idEmpleado, this.dtFechaPago, this.mTotal);
        }

        public static void DeleteFactura(int idFacturaHeader)
        {
            Data.dsFacturaTableAdapters.FacturasHeaderTableAdapter Adapter = new Data.dsFacturaTableAdapters.FacturasHeaderTableAdapter();
            Adapter.DeleteFacturaHeader(idFacturaHeader);
        }
    }

    public class FacturaDetalle
    {
        [Display(Name = "Código de Lista")]
        public int idFacturaDetalle { get; set; }
        [Display(Name = "Código de Factura")]
        public int idFacturaHeader { get; set; }
        [Display(Name = "Clave")]
        [Required(ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo es requerido")]
        public int idProducto { get; set; }
        [Display(Name = "Cantidad")]
        public int nCantidad { get; set; }
        [Display(Name = "Nombre")]
        public string cNombre { get; set; }
        [Display(Name = "Precio")]
        //[DataType(DataType.Currency)]
        public decimal mPrecio { get; set; }

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
                if (!dr.IsmPrecioNull())
                    temp.mPrecio = dr.mPrecio;
                listaFacturas.Add(temp);
            }
            return listaFacturas;
        }

        public static void DeleteFacturaDetalle(int idFacturaDetalle)
        {
            Data.dsFacturaTableAdapters.FacturasDetalleTableAdapter Adapter = new Data.dsFacturaTableAdapters.FacturasDetalleTableAdapter();
            Adapter.DeleteElementoFactura(idFacturaDetalle);
        }

        public void InsertUpdateFactura()
        {
            Data.dsFacturaTableAdapters.FacturasDetalleTableAdapter Adapter = new Data.dsFacturaTableAdapters.FacturasDetalleTableAdapter();
            Adapter.InsertUpdateElementoFacturaDetalle(this.idFacturaDetalle, this.idFacturaHeader, this.idProducto, this.nCantidad);

        }

        public static decimal SelectPrecioByProductoId(int idProducto)
        {
            decimal result = 0;
            Data.dsFacturaTableAdapters.PrecioByProductoIdTableAdapter Adapter = new Data.dsFacturaTableAdapters.PrecioByProductoIdTableAdapter();
            Data.dsFactura.PrecioByProductoIdDataTable dt = Adapter.SelectPrecioByProductoId(idProducto);

            if (dt.Rows.Count > 0)
            {
                Data.dsFactura.PrecioByProductoIdRow dr = dt[0];
                result = dr.mPrecio;
            }

            return result;
        }
    }
}