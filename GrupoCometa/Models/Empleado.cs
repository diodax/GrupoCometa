using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Models
{
    public class Empleado
    {
       
            [Display(Name = "Código")]
            public int idEmpleado { get; set; }
            [Display(Name = "Nombre")]
            public string cNombre { get; set; }
            [Display(Name = "Apellido")]
            public string cApellido { get; set; }
        [Display(Name = "Fecha Ingreso")]
        public DateTime dtFechaIngreso  { get; set; }
            [Display(Name = "Puesto")]
            public string cPuesto { get; set; }
            [Display(Name = "Salario")]
            public decimal mSalario { get; set; }
            [Display(Name = "Departamento")]
            public string idDepto { get; set; }
            [Display(Name = "Sucursal")]
            public string idSucursal { get; set; }

            public List<SelectListItem> listaEmpleado { get; set; }
        public List<SelectListItem> listaDepartamentos { get; set; }
        public List<SelectListItem> listaSucursal { get; set; }

        /// <summary>
        /// Constuctor sin parametros 
        /// </summary>
        public Empleado() { }

        public static List<SelectListItem> GetListaDepartamento()
        {
            List<SelectListItem> listaDepartamento = new List<SelectListItem>();
            Data.dsEmpleadoTableAdapters.DepartamentoTableAdapter Adapter = new Data.dsEmpleadoTableAdapters.DepartamentoTableAdapter();
            Data.dsEmpleado.DepartamentoDataTable dt = Adapter.SelectListaDepartamento() ;

            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idDepto;
                item.Text = dr.cNombre;
                listaDepartamento.Add(item);
            }

            return listaDepartamento;
        }

        public static List<SelectListItem> GetListaSucursal()
        {
            List<SelectListItem> listaSucursal = new List<SelectListItem>();
            Data.dsEmpleadoTableAdapters.SucursalTableAdapter Adapter = new Data.dsEmpleadoTableAdapters.SucursalTableAdapter();
            Data.dsEmpleado.SucursalDataTable dt = Adapter.SelectListaSucursal();

            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idSucursal;
                item.Text = dr.cNombre + " - "+ dr.cDireccion;
                //item.Text = dr.cDireccion;
                listaSucursal.Add(item);
            }

            return listaSucursal;
        }

        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="idEmpleado"></param>
        public Empleado(int idEmpleado)
            {
                Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter Adapter = new Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter();
                //Data.dsProductoTableAdapters.ProductosTableAdapter Adapter = new Data.dsProductoTableAdapters.ProductosTableAdapter();
                Data.dsEmpleado.EmpleadoDataTable dt = Adapter.SelectEmpleado(idEmpleado);

                if (dt.Rows.Count > 0)
                {
                    Data.dsEmpleado.EmpleadoRow dr = dt[0];
                    this.idEmpleado = dr.idEmpleado;
                    if (!dr.IscNombreNull())
                        this.cNombre = dr.cNombre;
                    if (!dr.IscApellidoNull())
                        this.cApellido = dr.cApellido;
                    if (!dr.IsdtFechaIngresoNull())
                        this.dtFechaIngreso = dr.dtFechaIngreso;
                    if (!dr.IscPuestoNull())
                        this.cPuesto = dr.cPuesto;
                    if(!dr.IsmSalarioNull())
                        this.mSalario = dr.mSalario;
                    if(!dr.IsidSucursalNull())
                        this.idSucursal = dr.idSucursal;
                    if(!dr.IsidDeptoNull())
                        this.idDepto = dr.idDepto;
                }
            }

            /// <summary>
            /// Genera la lista de productos de la DB
            /// </summary>
            /// <returns></returns>
            public static List<Empleado> GetListaEmpleado()
            {
                List<Empleado> listaEmpleado = new List<Empleado>();
                Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter Adapter = new Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter();
                Data.dsEmpleado.EmpleadoDataTable dt = Adapter.SelectListaEmpleado();

                foreach (var dr in dt)
                {
                    Empleado item = new Empleado();
                    item.idEmpleado = dr.idEmpleado;
                    if (!dr.IscNombreNull())
                        item.cNombre = dr.cNombre;
                    if (!dr.IscApellidoNull())
                        item.cApellido = dr.cApellido;
                     if (!dr.IsdtFechaIngresoNull())
                    item.dtFechaIngreso = dr.dtFechaIngreso;
                     if (!dr.IscPuestoNull())
                    item.cPuesto = dr.cPuesto;
                   if (!dr.IsmSalarioNull())
                    item.mSalario = dr.mSalario;
                   if(!dr.IsidSucursalNull())
                    item.idSucursal = dr.idSucursal;
                if (!dr.IsidDeptoNull())
                    item.idDepto = dr.idDepto;
                    listaEmpleado.Add(item);
                }

                return listaEmpleado;
            }

        public static List<SelectListItem> GetSelectListEmpleado()
        {
            List<SelectListItem> listaEmpleado = new List<SelectListItem>();
            Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter Adapter = new Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter();
            Data.dsEmpleado.EmpleadoDataTable dt = Adapter.SelectListaEmpleado();

            foreach (var dr in dt)
            {
                SelectListItem item = new SelectListItem();
                item.Value = dr.idEmpleado.ToString().Trim();
                item.Text = dr.cNombre;
                listaEmpleado.Add(item);
            }

            return listaEmpleado;
        }


        /// <summary>
        /// Inserta el cliente a la DB
        /// </summary>
        public void InsertEmpleado()
            {
                Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter Adapter = new Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter();
                Adapter.InsertEmpleado(this.cNombre, this.cApellido, this.dtFechaIngreso, this.cPuesto, this.mSalario, this.idSucursal,this.idDepto);
            }

            /// <summary>
            /// Actualiza el cliente a la DB
            /// </summary>
            public void UpdateEmpleado()
            {
                Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter Adapter = new Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter();
                Adapter.UpdateEmpleado(this.idEmpleado,this.cNombre, this.cApellido, this.dtFechaIngreso, this.cPuesto, this.mSalario, this.idDepto,this.idSucursal);
            }

            /// <summary>
            /// Elimina el cliente de la DB
            /// </summary>
            /// <param name="idEmpleado"></param>
            public static void DeleteEmpleado(int idEmpleado)
            {
                Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter Adapter = new Data.dsEmpleadoTableAdapters.EmpleadoTableAdapter();
                Adapter.DeleteEmpleado(idEmpleado);
            }
        }
    }
