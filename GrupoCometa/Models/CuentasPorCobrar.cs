using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace GrupoCometa.Models
{
    public class CuentasPorCobrar
    {
        [Display(Name = "Código de la Transacción")]
        public int idTransaccion { get; set; }
        [Display(Name = "Código de Factura")]
        public int idFacturaHeader { get; set; }
        [Display(Name = "Balance de la Cuenta")]
        public decimal mBalance { get; set; }

        public List<SelectListItem>  listaFacturaHeader { get; set; }

        /// <summary>
        /// Constuctor sin parametros 
        /// </summary>
        public CuentasPorCobrar() { }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idTransaccion"></param>
        public CuentasPorCobrar(int idTransaccion)
        {
            Data.dsCuentasTableAdapters.CuentasPorCobrarTableAdapter Adapter = new Data.dsCuentasTableAdapters.CuentasPorCobrarTableAdapter();
            //Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Data.dsCuentas.CuentasPorCobrarDataTable dt = Adapter.SelectCPC(idTransaccion);

            if (dt.Rows.Count > 0)
            {
                Data.dsCuentas.CuentasPorCobrarRow dr = dt[0];
                this.idTransaccion = dr.idTransaccion;
                if (!dr.IsidFacturaHeaderNull())
                    this.idFacturaHeader = dr.idFacturaHeader;
                this.mBalance = dr.mBalance;
            }
        }

        public static List<CuentasPorCobrar> GetListaCuentasPorCobrar()
        {
            List<CuentasPorCobrar> listaCuentasPorCobrar = new List<CuentasPorCobrar>();
            Data.dsCuentasTableAdapters.CuentasPorCobrarTableAdapter Adapter = new Data.dsCuentasTableAdapters.CuentasPorCobrarTableAdapter();
            Data.dsCuentas.CuentasPorCobrarDataTable dt = Adapter.SelectListaCPC();

            foreach (var dr in dt)
            {
                CuentasPorCobrar item = new CuentasPorCobrar();
                item.idTransaccion = dr.idTransaccion;
                if (!dr.IsidFacturaHeaderNull())
                    item.idFacturaHeader = dr.idFacturaHeader;
                if (!dr.IsmBalanceNull())
                    item.mBalance = dr.mBalance;
                
                listaCuentasPorCobrar.Add(item);
            }

            return listaCuentasPorCobrar;
        }

        public static List<SelectListItem> GetListaFacturaHeader()
        {
            List<SelectListItem> listaFacturaHeader = new List<SelectListItem>();
            Data.dsCuentasTableAdapters.FacturasHeaderTableAdapter Adapter = new Data.dsCuentasTableAdapters.FacturasHeaderTableAdapter();
            Data.dsCuentas.FacturasHeaderDataTable dt = Adapter.SelectListaFacturasHeader(null);

            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idFacturaHeader.ToString();
                item.Text = "[" + dr.idFacturaHeader.ToString() + "] - " + dr.cEmpresa;
                listaFacturaHeader.Add(item);
            }

            return listaFacturaHeader;
        }

        /// <summary>
        /// Inserta el cliente a la DB
        /// </summary>
        public void InsertCuentasPorCobrar()
        {
            Data.dsCuentasTableAdapters.CuentasPorCobrarTableAdapter Adapter =
                new Data.dsCuentasTableAdapters.CuentasPorCobrarTableAdapter();
            Adapter.InsertCPC(this.idFacturaHeader, this.mBalance);

        }

        /// <summary>
        /// Actualiza el inventario a la DB
        /// </summary>
        public void UpdateCuentasPorCobrar()
        {
            Data.dsCuentasTableAdapters.CuentasPorCobrarTableAdapter Adapter =
                new Data.dsCuentasTableAdapters.CuentasPorCobrarTableAdapter();
            Adapter.UpdateCPC(this.idTransaccion, this.idFacturaHeader, this.mBalance);
        }

        /// <summary>
        /// Elimina el elemento de la DB
        /// </summary>
        /// <param name="idInventario"></param>
        public static void DeleteCuentasPorCobrar(int idTransaccion)
        {
            Data.dsCuentasTableAdapters.CuentasPorCobrarTableAdapter Adapter =
                new Data.dsCuentasTableAdapters.CuentasPorCobrarTableAdapter();
            Adapter.DeleteCPC(idTransaccion);
        }
    }
}