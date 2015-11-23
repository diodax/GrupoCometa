using GrupoCometa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GrupoCometa.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> ListaClientes = new List<Cliente>();
            ListaClientes = Cliente.GetListaClientes();
            return View(ListaClientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            Cliente newModel = new Cliente(id);
            return View(newModel);
        }

        //GET: Producto/Insert/
        public ActionResult Insert()
        {
            Cliente newModel = new Cliente();
            //newModel.listaTiposProducto = Producto.GetListaTiposProducto();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Insert(Cliente newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.InsertCliente();
                return RedirectToAction("Index");
            }
            else
            {
                //newModel.listaCliente = Producto.GetListaTiposProducto();
                return View(newModel);
            }
        }



        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            Cliente newModel = new Cliente(id);
            //newModel.listaTiposProducto = Producto.GetListaTiposProducto();
            return View(newModel);
        }

        [HttpPost]
        public ActionResult Edit(Cliente newModel)
        {
            if (ModelState.IsValid)
            {
                newModel.UpdateCliente();
                return RedirectToAction("Index");
            }
            else
            {
                //newModel.listaTiposProducto = Producto.GetListaTiposProducto();
                return View(newModel);
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            Cliente newModel = new Cliente(id);
            return View(newModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Cliente newModel)
        {
            Cliente.DeleteCliente(id);
            return RedirectToAction("Index");
        }
    }
}
