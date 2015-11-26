using GrupoCometa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Controllers
{
    public class CuentasPorCobrarController : Controller
    {
        // GET: CuentasPorCobrar
        public ActionResult Index()
        {

            List<CuentasPorCobrar> ListaCuentasPorCobrar = new List<CuentasPorCobrar>();
            ListaCuentasPorCobrar = CuentasPorCobrar.GetListaCuentasPorCobrar();
            return View(ListaCuentasPorCobrar);
        }

        // GET: CuentasPorCobrar/Details/5
        public ActionResult Details(int idTransaccion)
        {
            CuentasPorCobrar newModel = new CuentasPorCobrar(idTransaccion);
            return View(newModel);
        }

        // GET: CuentasPorCobrar/Insert
        public ActionResult Insert()
        {
            CuentasPorCobrar newModel = new CuentasPorCobrar();
            newModel.listaFacturaHeader = CuentasPorCobrar.GetListaFacturaHeader();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Insert(CuentasPorCobrar newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.InsertCuentasPorCobrar();
                return RedirectToAction("Index");
            }
            else
            {
                newModel.listaFacturaHeader = CuentasPorCobrar.GetListaFacturaHeader();
                return View(newModel);
            }
        }

        // GET: CuentasPorCobrar/Edit/5
        public ActionResult Edit(int idTransaccion)
        {
            CuentasPorCobrar newModel = new CuentasPorCobrar(idTransaccion);
            newModel.listaFacturaHeader = CuentasPorCobrar.GetListaFacturaHeader();
            return View(newModel);
        }

        // POST: CuentasPorCobrar/Edit/5
        [HttpPost]
        public ActionResult Edit(CuentasPorCobrar newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.UpdateCuentasPorCobrar();
                return RedirectToAction("Index");
            }
            else
            {
                newModel.listaFacturaHeader = CuentasPorCobrar.GetListaFacturaHeader();
                return View(newModel);
            }
        }

        // GET: CuentasPorCobrar/Delete/5
        public ActionResult Delete(int idTransaccion)
        {
            CuentasPorCobrar newModel = new CuentasPorCobrar(idTransaccion);
            return View(newModel);
        }

        // POST: CuentasPorCobrar/Delete/5
        [HttpPost]
        public ActionResult Delete(int idTransaccion, CuentasPorCobrar newModel)
        {
            Inventario.DeleteInventario(idTransaccion);
            return RedirectToAction("Index");
        }
    }
}
