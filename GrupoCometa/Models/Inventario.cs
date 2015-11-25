using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace GrupoCometa.Models
{
    public class Inventario
    {
        [Display(Name = "Código de Inventario")]
        public int idInventario { get; set; }
        [Display(Name = "Código de Producto")]
        public int idProducto { get; set; }
        [Display(Name = "Código de Almacén")]
        public int idAlmacen { get; set; }
        [Display(Name = "Cantidad de producto")]
        public int nCantidad { get; set; }
        [Display(Name = "Código de estado de mercancía")]
        public int idEstado { get; set; }
        [Display(Name = "Fecha de Ingreso")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime dtFechaIngreso { get; set; }

        public List<SelectListItem> listaProductos { get; set; }
        public List<SelectListItem> listaAlmacenes { get; set; }
        public List<SelectListItem> listaEstados { get; set; }

        /// <summary>
        /// Constuctor sin parametros 
        /// </summary>
        public Inventario() { }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idInventario"></param>
        public Inventario(int idInventario)
        {
            Data.dsInventarioTableAdapters.InventarioTableAdapter Adapter = new Data.dsInventarioTableAdapters.InventarioTableAdapter();
            //Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Data.dsInventario.InventarioDataTable dt = Adapter.SelectInventario(idInventario);

            if (dt.Rows.Count > 0)
            {
                Data.dsInventario.InventarioRow dr = dt[0];
                this.idInventario = dr.idInventario;
                this.idProducto = dr.idProducto;
                if (!dr.IsidAlmacenNull())
                    this.idAlmacen = dr.idAlmacen;
                if (!dr.IsnCantidadNull())
                    this.nCantidad = dr.nCantidad;
                this.idEstado= dr.idEstado;
                this.dtFechaIngreso = dr.dtFechaIngreso;
            }
        }

        /// <summary>
        /// Genera la lista de productos de la DB
        /// </summary>
        /// <returns></returns>
        public static List<Inventario> GetListaInventarios()
        {
            List<Inventario> listaInventarios = new List<Inventario>();
            Data.dsInventarioTableAdapters.InventarioTableAdapter Adapter = new Data.dsInventarioTableAdapters.InventarioTableAdapter();
            Data.dsInventario.InventarioDataTable dt = Adapter.SelectListaInventarios();

            foreach (var dr in dt)
            {
                Inventario item = new Inventario();
                item.idInventario = dr.idInventario;
                item.idProducto = dr.idProducto;
                if (!dr.IsidAlmacenNull())
                    item.idAlmacen = dr.idAlmacen;
                if (!dr.IsnCantidadNull())
                    item.nCantidad = dr.nCantidad;
                item.idEstado = dr.idEstado;
                item.dtFechaIngreso = dr.dtFechaIngreso;

                listaInventarios.Add(item);
            }

            return listaInventarios;
        }

        public static List<SelectListItem> GetListaProductos()
        {
            List<SelectListItem> listaProductos = new List<SelectListItem>();
            Data.dsInventarioTableAdapters.ProductosTableAdapter Adapter = new Data.dsInventarioTableAdapters.ProductosTableAdapter();
            Data.dsInventario.ProductosDataTable dt = Adapter.SelectListaProductos();

            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idCodigo.ToString();
                item.Text = dr.cNombre;
                listaProductos.Add(item);
            }

            return listaProductos;
        }

        public static List<SelectListItem> GetListaAlmacenes()
        {
            List<SelectListItem> listaAlmacenes = new List<SelectListItem>();
            Data.dsInventarioTableAdapters.AlmacenTableAdapter Adapter = new Data.dsInventarioTableAdapters.AlmacenTableAdapter();
            Data.dsInventario.AlmacenDataTable dt = Adapter.SelectListaAlmacenes();

            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idAlmacen.ToString();
                item.Text = dr.cNombre;
                listaAlmacenes.Add(item);
            }

            return listaAlmacenes;
        }

        public static List<SelectListItem> GetListaEstados()
        {
            List<SelectListItem> listaEstados = new List<SelectListItem>();
            Data.dsInventarioTableAdapters.EstadosMercanciaTableAdapter Adapter = new Data.dsInventarioTableAdapters.EstadosMercanciaTableAdapter();
            Data.dsInventario.EstadosMercanciaDataTable dt = Adapter.SelectListaEstadosMercancia();

            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idEstado.ToString();
                item.Text = dr.cEstado;
                listaEstados.Add(item);
            }

            return listaEstados;
        }

        /// <summary>
        /// Inserta el cliente a la DB
        /// </summary>
        public void InsertInventario()
        {
            Data.dsInventarioTableAdapters.InventarioTableAdapter Adapter = new Data.dsInventarioTableAdapters.InventarioTableAdapter();
            Adapter.InsertInventario(this.idProducto, this.idAlmacen, this.nCantidad, this.idEstado, this.dtFechaIngreso);
        }

        /// <summary>
        /// Actualiza el inventario a la DB
        /// </summary>
        public void UpdateInventario()
        {
            Data.dsInventarioTableAdapters.InventarioTableAdapter Adapter = new Data.dsInventarioTableAdapters.InventarioTableAdapter();
            Adapter.UpdateInventario(this.idInventario, this.idProducto, this.idAlmacen, this.nCantidad, this.idEstado, this.dtFechaIngreso);
        }

        /// <summary>
        /// Elimina el elemento de la DB
        /// </summary>
        /// <param name="idInventario"></param>
        public static void DeleteInventario(int idInventario)
        {
            Data.dsInventarioTableAdapters.InventarioTableAdapter Adapter = new Data.dsInventarioTableAdapters.InventarioTableAdapter();
            Adapter.DeleteInventario(idInventario);
        }
    }
}