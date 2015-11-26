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
            newModel.GetSelectLists();
            return View(newModel);
        }

        // POST: Facturacion/Create
        [HttpPost]
        public ActionResult Insert(FacturaHeader newModel)
        {
            if (ModelState.IsValid)
            {
                try
            {
                
                    newModel.idFacturaHeader = newModel.InsertUpdateFactura();
                    foreach (var item in newModel.listaDetalle)
                    {
                        FacturaDetalle.DeleteFacturaDetalle(item.idFacturaDetalle);
                    }

                    foreach (var item in newModel.listaDetalle)
                    {
                        item.idFacturaHeader = newModel.idFacturaHeader;
                        item.InsertUpdateFactura();
                    }

                    return RedirectToAction("Index");
                
                
            }
            catch
            {
                newModel.GetSelectLists();
                return View();
            }
            }
            newModel.GetSelectLists();
            return View();
        }

        // GET: Facturacion/Edit/5
        public ActionResult Edit(int idFacturaHeader)
        {
            FacturaHeader newModel = new FacturaHeader(idFacturaHeader);
            //newModel.listaDetalle = new List<FacturaDetalle>();
            //newModel.dtFechaPago = DateTime.Now;
            newModel.GetSelectLists();
            return View(newModel);
        }

        // POST: Facturacion/Edit/5
        [HttpPost]
        public ActionResult Edit(FacturaHeader newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.idFacturaHeader = newModel.InsertUpdateFactura();
                foreach (var item in newModel.listaDetalle)
                {
                    FacturaDetalle.DeleteFacturaDetalle(item.idFacturaDetalle);
                }

                foreach (var item in newModel.listaDetalle)
                {
                    item.idFacturaHeader = newModel.idFacturaHeader;
                    item.InsertUpdateFactura();
                }

                return RedirectToAction("Index");
            }
            else
            {
                newModel.GetSelectLists();
                return View();
            }
        }

        // GET: Facturacion/Delete/5
        public ActionResult Delete(int idFacturaHeader)
        {
            FacturaHeader newModel = new FacturaHeader(idFacturaHeader);
            //newModel.listaDetalle = new List<FacturaDetalle>();
            //newModel.dtFechaPago = DateTime.Now;
            newModel.GetSelectLists();
            return View(newModel);
        }

        // POST: Facturacion/Delete/5
        [HttpPost]
        public ActionResult Delete(FacturaHeader newModel)
        {
            try
            {
                FacturaHeader.DeleteFactura(newModel.idFacturaHeader);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
