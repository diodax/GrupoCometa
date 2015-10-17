using GrupoCometa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            List<Producto> listaProductos = new List<Producto>();
            listaProductos = Producto.GetListaProductos(); 
            return View(listaProductos);
        }

        // GET: Producto/Details/
        public ActionResult Details(int idCodigo)
        {
            Producto newModel = new Producto(idCodigo);
            return View(newModel);
        }

        // GET: Producto/Insert/
        public ActionResult Insert()
        {
            Producto newModel = new Producto();
            newModel.listaTiposProducto = Producto.GetListaTiposProducto();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Insert(Producto newModel)
        {
            if(ModelState.IsValid)
            {
                newModel.InsertProducto();
                return RedirectToAction("Index");
            }
            else
            {
                newModel.listaTiposProducto = Producto.GetListaTiposProducto();
                return View(newModel);
            }
        }

        // GET: Producto/Edit/
        public ActionResult Edit(int idCodigo)
        {
            Producto newModel = new Producto(idCodigo);
            newModel.listaTiposProducto = Producto.GetListaTiposProducto();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Edit(Producto newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.UpdateProducto();
                return RedirectToAction("Index");
            }
            else
            {
                newModel.listaTiposProducto = Producto.GetListaTiposProducto();
                return View(newModel);
            }
        }

        // GET: Producto/Delete/
        public ActionResult Delete(int idCodigo)
        {
            Producto newModel = new Producto(idCodigo);
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Delete(int idCodigo, Producto newModel)
        {
            Producto.DeleteProducto(idCodigo);
            return RedirectToAction("Index");
        }
    }
}