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
    public class CuentasPorPagar
    {
        [Display(Name = "Código")]
        public int idTransaccion { get; set; }
        [Display(Name = "Clave de Factura")]
        public int idFacturaHeader { get; set; }
        [Display(Name = "Balance de Cuenta")]
        [DataType(DataType.Currency)]
        public decimal mBalance { get; set; }

        public List<SelectListItem> listaFacturaHeader { get; set; }

        /// <summary>
        /// Constuctor sin parametros 
        /// </summary>
        public CuentasPorPagar() { }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idTransaccion"></param>
        public CuentasPorPagar(int idTransaccion)
        {
            Data.dsCuentasTableAdapters.CuentasPorPagarTableAdapter Adapter = new Data.dsCuentasTableAdapters.CuentasPorPagarTableAdapter();
            //Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Data.dsCuentas.CuentasPorPagarDataTable dt = Adapter.SelectCPP(idTransaccion);

            if (dt.Rows.Count > 0)
            {
                Data.dsCuentas.CuentasPorPagarRow dr = dt[0];
                this.idTransaccion = dr.idTransaccion;
                if (!dr.IsidFacturaHeaderNull())
                    this.idFacturaHeader = dr.idFacturaHeader;
                this.mBalance = dr.mBalance;
            }
        }

        public static List<CuentasPorPagar> GetListaCuentasPorPagar()
        {
            List<CuentasPorPagar> listaCuentasPorPagar = new List<CuentasPorPagar>();
            Data.dsCuentasTableAdapters.CuentasPorPagarTableAdapter Adapter = new Data.dsCuentasTableAdapters.CuentasPorPagarTableAdapter();
            Data.dsCuentas.CuentasPorPagarDataTable dt = Adapter.SelectListaCPP();

            foreach (var dr in dt)
            {
                CuentasPorPagar item = new CuentasPorPagar();
                item.idTransaccion = dr.idTransaccion;
                if (!dr.IsidFacturaHeaderNull())
                    item.idFacturaHeader = dr.idFacturaHeader;
                if (!dr.IsmBalanceNull())
                    item.mBalance = dr.mBalance;

                listaCuentasPorPagar.Add(item);
            }

            return listaCuentasPorPagar;
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
        public void InsertCuentasPorPagar()
        {
            Data.dsCuentasTableAdapters.CuentasPorPagarTableAdapter Adapter =
                new Data.dsCuentasTableAdapters.CuentasPorPagarTableAdapter();
            Adapter.InsertCPP(this.idFacturaHeader, this.mBalance);

        }

        /// <summary>
        /// Actualiza el inventario a la DB
        /// </summary>
        public void UpdateCuentasPorPagar()
        {
            Data.dsCuentasTableAdapters.CuentasPorPagarTableAdapter Adapter =
                new Data.dsCuentasTableAdapters.CuentasPorPagarTableAdapter();
            Adapter.UpdateCPP(this.idTransaccion, this.idFacturaHeader, this.mBalance);
        }

        /// <summary>
        /// Elimina el elemento de la DB
        /// </summary>
        /// <param name="idInventario"></param>
        public static void DeleteCuentasPorPagar(int idTransaccion)
        {
            Data.dsCuentasTableAdapters.CuentasPorPagarTableAdapter Adapter =
                new Data.dsCuentasTableAdapters.CuentasPorPagarTableAdapter();
            Adapter.DeleteCPP(idTransaccion);
        }
    }
}