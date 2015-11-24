using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace GrupoCometa.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public int idCliente { get; set; }
        [Display(Name = "Empresa")]
        [StringLength(50, ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo no puede exceder los {1} caracteres")]
        public string cEmpresa { get; set; }
        [Display(Name = "Representante")]
        [StringLength(50, ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo no puede exceder los {1} caracteres")]
        public string cRepresentante { get; set; }
        [Display(Name = "E-Mail")]
        [StringLength(30, ErrorMessage = "<i class='fa fa-times-circle'></i> El e-mail no puede exceder los {1} caracteres")]
        public string cEmail { get; set; }
        [Display(Name = "Teléfono")]
        [StringLength(10, ErrorMessage = "<i class='fa fa-times-circle'></i> El teléfono no puede exceder los {1} caracteres")]
        public string cTelefono { get; set; }
        [Display(Name = "Descuento")]   
        [StringLength(2, ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo no puede exceder los {1} caracteres")]
        public int nDescuento { get; set; }
        [Display(Name = "RNC")]
        [StringLength(9, ErrorMessage = "<i class='fa fa-times-circle'></i> El RNC no puede exceder los {1} caracteres")]
        public string cRNC { get; set; }

        public List<SelectListItem> listaClientes { get; set; }

        /// <summary>
        /// Constuctor sin parametros 
        /// </summary>
        public Cliente() { }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idCliente"></param>
        public Cliente(int idCliente)
        {
            Data.dsClienteTableAdapters.ClienteTableAdapter Adapter = new Data.dsClienteTableAdapters.ClienteTableAdapter();
            //Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Data.dsCliente.ClienteDataTable dt = Adapter.SelectCliente(idCliente);

            if (dt.Rows.Count > 0)
            {
                Data.dsCliente.ClienteRow dr = dt[0];
                this.idCliente = dr.idCliente;
                if (!dr.IscRepresentanteNull())
                    this.cRepresentante = dr.cRepresentante;
                if(!dr.IscEmpresaNull())
                    this.cEmpresa = dr.cEmpresa;
                if(!dr.IscEmailNull())
                    this.cEmail = dr.cEmail;
                if(!dr.IscTelefonoNull())
                    this.cTelefono = dr.cTelefono;
                if(!dr.IsnDescuentoNull())
                    this.nDescuento = dr.nDescuento;
                if(!dr.IscRNCNull())
                    this.cRNC = dr.cRNC;
            }
        }

        /// <summary>
        /// Genera la lista de productos de la DB
        /// </summary>
        /// <returns></returns>
        public static List<Cliente> GetListaClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            Data.dsClienteTableAdapters.ClienteTableAdapter Adapter = new Data.dsClienteTableAdapters.ClienteTableAdapter();
            Data.dsCliente.ClienteDataTable dt = Adapter.SelectListaClientes();

            foreach (var dr in dt)
            {
                Cliente item = new Cliente();
                item.idCliente = dr.idCliente;
                if (!dr.IscRepresentanteNull())
                    item.cRepresentante = dr.cRepresentante;
                if (!dr.IscEmpresaNull())
                    item.cEmpresa = dr.cEmpresa;
                if (!dr.IscEmailNull())
                    item.cEmail = dr.cEmail;
                if (!dr.IscTelefonoNull())
                    item.cTelefono = dr.cTelefono;
                if (!dr.IsnDescuentoNull())
                    item.nDescuento = dr.nDescuento;
                if (!dr.IscRNCNull())
                    item.cRNC = dr.cRNC;

                listaClientes.Add(item);
            }

            return listaClientes;
        }
        

        /// <summary>
        /// Inserta el cliente a la DB
        /// </summary>
        public void InsertCliente()
        {
            Data.dsClienteTableAdapters.ClienteTableAdapter Adapter = new Data.dsClienteTableAdapters.ClienteTableAdapter();
            Adapter.InsertCliente(this.cRepresentante, this.cEmpresa, this.cEmail, this.cTelefono, this.nDescuento, this.cRNC);
        }

        /// <summary>
        /// Actualiza el cliente a la DB
        /// </summary>
        public void UpdateCliente()
        {
            Data.dsClienteTableAdapters.ClienteTableAdapter Adapter = new Data.dsClienteTableAdapters.ClienteTableAdapter();
            Adapter.UpdateCliente(this.idCliente ,this.cRepresentante, this.cEmpresa, this.cEmail, this.cTelefono, this.nDescuento, this.cRNC);
        }

        /// <summary>
        /// Elimina el cliente de la DB
        /// </summary>
        /// <param name="idCliente"></param>
        public static void DeleteCliente(int idCliente)
        {
            Data.dsClienteTableAdapters.ClienteTableAdapter Adapter = new Data.dsClienteTableAdapters.ClienteTableAdapter();
            Adapter.DeleteCliente(idCliente);
        }
    }
}