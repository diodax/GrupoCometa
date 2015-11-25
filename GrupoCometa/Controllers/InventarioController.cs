using GrupoCometa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Controllers
{
    public class InventarioController : Controller
    {
        // GET: Inventario
        public ActionResult Index()
        {
            List<Inventario> ListaInventarios = new List<Inventario>();
            ListaInventarios = Inventario.GetListaInventarios();
            return View(ListaInventarios);
        }

        // GET: Inventario/Details/5
        public ActionResult Details(int idInventario)
        {
            Inventario newModel = new Inventario(idInventario);
            return View(newModel);
        }

        //GET: Producto/Insert/
        public ActionResult Insert()
        {
            Inventario newModel = new Inventario();
            newModel.dtFechaIngreso = System.DateTime.Now;
            newModel.listaProductos = Inventario.GetListaProductos();
            newModel.listaAlmacenes = Inventario.GetListaAlmacenes();
            newModel.listaEstados = Inventario.GetListaEstados();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Insert(Inventario newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.InsertInventario();
                return RedirectToAction("Index");
            }
            else
            {
                newModel.dtFechaIngreso = System.DateTime.Now;
                newModel.listaProductos = Inventario.GetListaProductos();
                newModel.listaAlmacenes = Inventario.GetListaAlmacenes();
                newModel.listaEstados = Inventario.GetListaEstados();
                return View(newModel);
            }
        }



        // GET: Inventario/Edit/5
        public ActionResult Edit(int idInventario)
        {
            Inventario newModel = new Inventario(idInventario);
            //newModel.dtFechaIngreso = System.DateTime.Now;
            newModel.listaProductos = Inventario.GetListaProductos();
            newModel.listaAlmacenes = Inventario.GetListaAlmacenes();
            newModel.listaEstados = Inventario.GetListaEstados();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Edit(Inventario newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.UpdateInventario();
                return RedirectToAction("Index");
            }
            else
            {
                //newModel.dtFechaIngreso = System.DateTime.Now;
                newModel.listaProductos = Inventario.GetListaProductos();
                newModel.listaAlmacenes = Inventario.GetListaAlmacenes();
                newModel.listaEstados = Inventario.GetListaEstados();
                return View(newModel);
            }
        }

        // GET: Inventario/Delete/5
        public ActionResult Delete(int idInventario)
        {
            Inventario newModel = new Inventario(idInventario);
            return View(newModel);
        }

        // POST: Inventario/Delete/5
        [HttpPost]
        public ActionResult Delete(int idInventario, Inventario newModel)
        {
            Inventario.DeleteInventario(idInventario);
            return RedirectToAction("Index");
        }
    }
}
