using GrupoCometa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Controllers
{
    public class CuentasPorPagarController : Controller
    {
        // GET: CuentasPorPagar
        public ActionResult Index()
        {
            List<CuentasPorPagar> ListaCuentasPorPagar = new List<CuentasPorPagar>();
            ListaCuentasPorPagar = CuentasPorPagar.GetListaCuentasPorPagar();
            return View(ListaCuentasPorPagar);
        }

        // GET: CuentasPorPagar/Details/5
        public ActionResult Details(int idTransaccion)
        {
            CuentasPorPagar newModel = new CuentasPorPagar(idTransaccion);
            return View(newModel);
        }

        // GET: CuentasPorPagar/Insert
        public ActionResult Insert()
        {
            CuentasPorPagar newModel = new CuentasPorPagar();
            newModel.listaFacturaHeader = CuentasPorPagar.GetListaFacturaHeader();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Insert(CuentasPorPagar newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.InsertCuentasPorPagar();
                return RedirectToAction("Index");
            }
            else
            {
                newModel.listaFacturaHeader = CuentasPorPagar.GetListaFacturaHeader();
                return View(newModel);
            }
        }

        // GET: CuentasPorPagar/Edit/5
        public ActionResult Edit(int idTransaccion)
        {
            CuentasPorPagar newModel = new CuentasPorPagar(idTransaccion);
            newModel.listaFacturaHeader = CuentasPorPagar.GetListaFacturaHeader();
            return View(newModel);
        }

        // POST: CuentasPorPagar/Edit/5
        [HttpPost]
        public ActionResult Edit(CuentasPorPagar newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.UpdateCuentasPorPagar();
                return RedirectToAction("Index");
            }
            else
            {
                newModel.listaFacturaHeader = CuentasPorPagar.GetListaFacturaHeader();
                return View(newModel);
            }
        }

        // GET: CuentasPorPagar/Delete/5
        public ActionResult Delete(int idTransaccion)
        {
            CuentasPorPagar newModel = new CuentasPorPagar(idTransaccion);
            return View(newModel);
        }

        // POST: CuentasPorPagar/Delete/5
        [HttpPost]
        public ActionResult Delete(int idTransaccion, CuentasPorPagar newModel)
        {
            Inventario.DeleteInventario(idTransaccion);
            return RedirectToAction("Index");
        }
    }
}
