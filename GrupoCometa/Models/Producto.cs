using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Models
{
    public class Producto
    {
        [Display(Name = "Código")]
        public int idCodigo { get; set; }
        [Display(Name = "Nombre")]
        public string cNombre { get; set; }
        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        public decimal mPrecio { get; set; }
        //[Display(Name = "Cantidad")]
        //public int nCantidad { get; set; }
        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo es requerido")]
        public string idTipo { get; set; }
        [Display(Name = "Modelo")]
        public string cModelo { get; set; }
        [Display(Name = "Código de Suplidor")]
        [Required(ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo es requerido")]
        public int idSuplidor { get; set; }

        public List<SelectListItem> listaTiposProducto { get; set; }
        public List<SelectListItem> listaSuplidores { get; set; }

        /// <summary>
        /// Constuctor sin parametros 
        /// </summary>
        public Producto() { }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idCodigo"></param>
        public Producto(int idCodigo)
        {
            Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Data.dsProducto.ProductosDataTable dt = Adapter.SelectProducto( idCodigo);

            if (dt.Rows.Count > 0)
            {
                Data.dsProducto.ProductosRow dr = dt[0];
                this.idCodigo = dr.idCodigo;
                this.cNombre = dr.cNombre;
                if (!dr.IsmPrecioNull())
                    this.mPrecio = dr.mPrecio;
                //this.nCantidad = dr.nCantidad;
                this.idTipo = dr.idTipo;
                if (!dr.IscModeloNull())
                    this.cModelo = dr.cModelo;
                this.idSuplidor = dr.idSuplidor;
            }
        }

        /// <summary>
        /// Genera la lista de productos de la DB
        /// </summary>
        /// <returns></returns>
        public static List<Producto> GetListaProductos()
        {
            List<Producto> listaProductos = new List<Producto>();
            Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Data.dsProducto.ProductosDataTable dt = Adapter.SelectListaProductos();

            foreach(var dr in dt)
            {
                Producto item = new Producto();
                item.idCodigo = dr.idCodigo;
                item.cNombre = dr.cNombre;
                if(!dr.IsmPrecioNull())
                    item.mPrecio = dr.mPrecio;
                //item.nCantidad = dr.nCantidad;
                item.idTipo = dr.idTipo;
                if(!dr.IscModeloNull())
                    item.cModelo = dr.cModelo;
                item.idSuplidor = dr.idSuplidor;
                listaProductos.Add(item);
            }

            return listaProductos;
        }

        /// <summary>
        /// Genera el contenido del dropbdown con los productos
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetSelectListProducto()
        {
            List<SelectListItem> listaProductos = new List<SelectListItem>();
            Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Data.dsProducto.ProductosDataTable dt = Adapter.SelectListaProductos();

            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idCodigo.ToString().Trim();
                if (dr.IscModeloNull())
                    dr.cModelo = "";
                
                item.Text = dr.cNombre.Trim() + " " + dr.cModelo.Trim();
                listaProductos.Add(item);
            }

            return listaProductos;
        }

        /// <summary>
        /// Genera el contenido del dropbdown con los tipos de productos
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetListaTiposProducto()
        {
            List<SelectListItem> listaTipos = new List<SelectListItem>();
            Data.dsProductoTableAdapters.TiposProductoTableAdapter Adapter = new Data.dsProductoTableAdapters.TiposProductoTableAdapter();
            Data.dsProducto.TiposProductoDataTable dt = Adapter.SelectListaTiposProducto();

            foreach(var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idTipo;
                item.Text = dr.cDescripcion;
                listaTipos.Add(item);
            }

            return listaTipos;
        }

        /// <summary>
        /// Genera el contenido del dropbdown con los suplidores
        /// </summary>
        /// <returns></returns>
        public static List<SelectListItem> GetListaSuplidores()
        {
            List<SelectListItem> listaSuplidores = new List<SelectListItem>();
            Data.dsProductoTableAdapters.SuplidorTableAdapter Adapter = new Data.dsProductoTableAdapters.SuplidorTableAdapter();
            Data.dsProducto.SuplidorDataTable dt = Adapter.SelectListaSuplidores();

            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idSuplidor.ToString();
                item.Text = dr.cNombre;
                listaSuplidores.Add(item);
            }

            return listaSuplidores;
        }

        /// <summary>
        /// Inserta el producto a la DB
        /// </summary>
        public void InsertProducto()
        {
            Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Adapter.InsertProducto(this.cNombre, this.mPrecio, /*this.nCantidad,*/ this.idTipo, this.cModelo, this.idSuplidor);
        }

        /// <summary>
        /// Actualiza el producto a la DB
        /// </summary>
        public void UpdateProducto()
        {
            Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Adapter.UpdateProducto(this.idCodigo, this.cNombre, this.mPrecio, /*this.nCantidad,*/ this.idTipo, this.cModelo, this.idSuplidor);
        }

        /// <summary>
        /// Elimina el producto de la DB
        /// </summary>
        /// <param name="idCodigo"></param>
        public static void DeleteProducto(int idCodigo)
        {
            Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Adapter.DeleteProducto(idCodigo);
        }

    }
}