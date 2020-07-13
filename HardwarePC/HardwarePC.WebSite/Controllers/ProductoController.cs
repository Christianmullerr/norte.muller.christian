using HardwarePC.Data.Model;
using HardwarePC.Data.Services;
using HardwarePC.WebSite.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HardwarePC.WebSite.Controllers
{
    [Authorize]
    public class  ProductoController : BaseController
    {
        private readonly BaseDataService<Product> MyContext = new BaseDataService<Product>();
        private readonly ArtShopDbContext db = new ArtShopDbContext();
        public ProductoController()
        {

        }
        // GET: Producto
        public ActionResult Index()
        {
            var products = MyContext.Get(null, null, "Artist");
            return View(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName");
            return View();
        }
        //ActionResult para el botón Grabar del formulario de producto
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            this.CheckAuditPattern(product, true);
            var listModel = MyContext.ValidateModel(product);
            if (ModelIsValid(listModel))
                return View(product);
            try
            {
                if (file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("/Content/Products"), filename);
                    file.SaveAs(path);

                    product.Image = filename;
                    this.CheckAuditPattern(product, true);
                    db.Product.Add(product);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                //MyContext.Create(product);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
            }
            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName", product.ArtistId);
            ViewBag.MessageDanger = "¡Error al cargar el Producto con su imagen.";
            return View(product);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = db.Product.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName", producto.ArtistId);
            return View(producto);
        }
        [HttpPost]
        public ActionResult Edit(Product product, HttpPostedFileBase file)
        {
            this.CheckAuditPattern(product);
            var listModel = MyContext.ValidateModel(product);
            if (ModelIsValid(listModel))
                return View(product);
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    string path = Path.Combine(Server.MapPath("/content/products"), filename);
                    file.SaveAs(path);
                    product.Image = filename;
                }
                this.CheckAuditPattern(product, false);
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

                //MyContext.Update(product);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
            }

            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName", product.ArtistId);
            ViewBag.MessageDanger = "¡Error al modificar el Producto con su imagen.";
            return View(product);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = MyContext.GetById(id.Value);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }       
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var producto = db.Product.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            db.Product.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
