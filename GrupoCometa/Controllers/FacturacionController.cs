using GrupoCometa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Controllers
{
    public class FacturacionController : Controller
    {
        // GET: Facturacion
        public ActionResult Index()
        {
            List<FacturaHeader> newModel = new List<FacturaHeader>();
            newModel = FacturaHeader.GetListaFacturas();
            return View(newModel);
        }

        // GET: Facturacion/Create
        public ActionResult Insert()
        {
            FacturaHeader newModel = new FacturaHeader();
            newModel.listaDetalle = new List<FacturaDetalle>();
            newModel.dtFechaPago = DateTime.Now;
            return View(newModel);
        }

        // POST: Facturacion/Create
        [HttpPost]
        public ActionResult Insert(FacturaHeader newModels)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facturacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Facturacion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facturacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Facturacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
