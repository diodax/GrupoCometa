using GrupoCometa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            List<Empleado> ListaEmpleados = new List<Empleado>();
            ListaEmpleados = Empleado.GetListaEmpleado();
            return View(ListaEmpleados);
        }


        // GET: Empleado/Details/5
        public ActionResult Details(int idEmpleado)
        {
            Empleado newModel = new Empleado(idEmpleado);
            return View(newModel);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            Empleado newModel = new Empleado();
            newModel.listaDepartamentos = Empleado.GetListaDepartamento();
            newModel.listaSucursal = Empleado.GetListaSucursal();
            return View(newModel);
        }

        

        [HttpPost]
        public ActionResult Create(Empleado newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.InsertEmpleado();
                return RedirectToAction("Index");
            }
            else
            {
                newModel.listaDepartamentos = Empleado.GetListaDepartamento();
                newModel.listaSucursal = Empleado.GetListaSucursal();
                return View(newModel);
            }
        }

      

        

        // GET: Empleado/Edit/5
        public ActionResult Edit(int idEmpleado)
        {
            Empleado newModel = new Empleado(idEmpleado);
            return View(newModel);
        }

        // POST: Empleado/Edit/5
        [HttpPost]
        public ActionResult Edit(Empleado newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.UpdateEmpleado();
                return RedirectToAction("Index");
            }
            else
            {
                
                return View(newModel);
            }
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int idEmpleado)
        {
            Empleado newModel = new Empleado(idEmpleado);
            return View(newModel);
        }

        // POST: Empleado/Delete/5
        [HttpPost]
        public ActionResult Delete(int idEmpleado, Empleado newModel)
        {
            Empleado.DeleteEmpleado(idEmpleado);
            return RedirectToAction("Index");
        }
    }
}
