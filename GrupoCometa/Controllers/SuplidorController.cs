using GrupoCometa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Controllers
{
    public class SuplidorController : Controller
    {
        // GET: Suplidor
        public ActionResult Index()
        {
            List<Suplidor> ListaSuplidores = new List<Suplidor>();
            ListaSuplidores = Suplidor.GetListaSuplidores();
            return View(ListaSuplidores);
        }

        // GET: Suplidor/Details/5
        public ActionResult Details(int idSuplidor)
        {
            Suplidor newModel = new Suplidor(idSuplidor);
            return View(newModel);
        }

        //GET: Producto/Insert/
        public ActionResult Insert()
        {
            Suplidor newModel = new Suplidor();
            //newModel.listaTiposProducto = Producto.GetListaTiposProducto();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Insert(Suplidor newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.InsertSuplidor();
                return RedirectToAction("Index");
            }
            else
            {
                //newModel.listaSuplidor = Producto.GetListaTiposProducto();
                return View(newModel);
            }
        }



        // GET: Suplidor/Edit/5
        public ActionResult Edit(int idSuplidor)
        {
            Suplidor newModel = new Suplidor(idSuplidor);
            //newModel.listaTiposProducto = Producto.GetListaTiposProducto();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Edit(Suplidor newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.UpdateSuplidor();
                return RedirectToAction("Index");
            }
            else
            {
                //newModel.listaTiposProducto = Producto.GetListaTiposProducto();
                return View(newModel);
            }
        }

        // GET: Suplidor/Delete/5
        public ActionResult Delete(int idSuplidor)
        {
            Suplidor newModel = new Suplidor(idSuplidor);
            return View(newModel);
        }

        // POST: Suplidor/Delete/5
        [HttpPost]
        public ActionResult Delete(int idSuplidor, Suplidor newModel)
        {
            Suplidor.DeleteSuplidor(idSuplidor);
            return RedirectToAction("Index");
        }
    }
}
