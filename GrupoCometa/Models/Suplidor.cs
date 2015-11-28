using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace GrupoCometa.Models
{
    public class Suplidor
    {
        [Display(Name = "Código")]
        public int idSuplidor { get; set; }
        [Display(Name = "Empresa")]
        [StringLength(50, ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo no puede exceder los {1} caracteres")]
        public string cNombre { get; set; }
        [Display(Name = "Representante")]
        [StringLength(50, ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo no puede exceder los {1} caracteres")]
        public string cRepresentante { get; set; }
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "<i class='fa fa-times-circle'></i> El e-mail no contiene un formato válido")]
        [StringLength(30, ErrorMessage = "<i class='fa fa-times-circle'></i> El e-mail no puede exceder los {1} caracteres")]
        public string cEmail { get; set; }
        [Display(Name = "Teléfono")]
        [StringLength(15, ErrorMessage = "<i class='fa fa-times-circle'></i> El teléfono no puede exceder los {1} caracteres")]
        public string cTelefono { get; set; }
        [Display(Name = "Dirección")]
        [StringLength(150, ErrorMessage = "<i class='fa fa-times-circle'></i> Este campo no puede exceder los {1} caracteres")]
        public string cDireccion { get; set; }

        public List<SelectListItem> listaSuplidores { get; set; }

        /// <summary>
        /// Constuctor sin parametros 
        /// </summary>
        public Suplidor() { }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idSuplidor"></param>
        public Suplidor(int idSuplidor)
        {
            Data.dsSuplidorTableAdapters.SuplidorTableAdapter Adapter = new Data.dsSuplidorTableAdapters.SuplidorTableAdapter();
            //Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
            Data.dsSuplidor.SuplidorDataTable dt = Adapter.SelectSuplidor(idSuplidor);

            if (dt.Rows.Count > 0)
            {
                Data.dsSuplidor.SuplidorRow dr = dt[0];
                this.idSuplidor = dr.idSuplidor;
                if (!dr.IscNombreNull())
                    this.cNombre = dr.cNombre;
                if (!dr.IscRepresentanteNull())
                    this.cRepresentante = dr.cRepresentante;
                if (!dr.IscEmailNull())
                    this.cEmail = dr.cEmail;
                if (!dr.IscTelefonoNull())
                    this.cTelefono = dr.cTelefono;
                if (!dr.IscDireccionNull())
                    this.cDireccion = dr.cDireccion;
            }
        }

        /// <summary>
        /// Genera la lista de productos de la DB
        /// </summary>
        /// <returns></returns>
        public static List<Suplidor> GetListaSuplidores()
        {
            List<Suplidor> listaSuplidores = new List<Suplidor>();
            Data.dsSuplidorTableAdapters.SuplidorTableAdapter Adapter = new Data.dsSuplidorTableAdapters.SuplidorTableAdapter();
            Data.dsSuplidor.SuplidorDataTable dt = Adapter.SelectListaSuplidores();

            foreach (var dr in dt)
            {
                Suplidor item = new Suplidor();
                item.idSuplidor = dr.idSuplidor;
                if (!dr.IscNombreNull())
                    item.cNombre = dr.cNombre;
                if (!dr.IscRepresentanteNull())
                    item.cRepresentante = dr.cRepresentante;
                if (!dr.IscEmailNull())
                    item.cEmail = dr.cEmail;
                if (!dr.IscTelefonoNull())
                    item.cTelefono = dr.cTelefono;
                if (!dr.IscDireccionNull())
                    item.cDireccion = dr.cDireccion;

                listaSuplidores.Add(item);
            }

            return listaSuplidores;
        }


        /// <summary>
        /// Inserta el cliente a la DB
        /// </summary>
        public void InsertSuplidor()
        {
            Data.dsSuplidorTableAdapters.SuplidorTableAdapter Adapter = new Data.dsSuplidorTableAdapters.SuplidorTableAdapter();
            Adapter.InsertSuplidor(this.cNombre, this.cRepresentante, this.cEmail, this.cTelefono, this.cDireccion);
        }

        /// <summary>
        /// Actualiza el cliente a la DB
        /// </summary>
        public void UpdateSuplidor()
        {
            Data.dsSuplidorTableAdapters.SuplidorTableAdapter Adapter = new Data.dsSuplidorTableAdapters.SuplidorTableAdapter();
            Adapter.UpdateSuplidor(this.idSuplidor, this.cNombre, this.cRepresentante, this.cEmail, this.cTelefono, this.cDireccion);
        }

        /// <summary>
        /// Elimina el cliente de la DB
        /// </summary>
        /// <param name="idSuplidor"></param>
        public static void DeleteSuplidor(int idSuplidor)
        {
            Data.dsSuplidorTableAdapters.SuplidorTableAdapter Adapter = new Data.dsSuplidorTableAdapters.SuplidorTableAdapter();
            Adapter.DeleteSuplidor(idSuplidor);
        }
    }
}