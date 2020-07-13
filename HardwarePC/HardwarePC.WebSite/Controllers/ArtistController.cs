using HardwarePC.Data.Model;
using HardwarePC.Data.Services;
using HardwarePC.WebSite.Services;
using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HardwarePC.WebSite.Controllers
{
    [Authorize]
    public class ArtistController : BaseController
    {
       
        private readonly BaseDataService<Artist> MyContext = new BaseDataService<Artist>();
        private readonly ArtShopDbContext db = new ArtShopDbContext();
        public ArtistController()
        {
            
        }
        public ActionResult Index()
        {
            var artist = MyContext.Get();
            return View(artist);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ArtistId = new SelectList(db.Artist, "Id", "FullName");
            return View();
        }

        //ActionResult para el botón Grabar del formulario de producto
        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            this.CheckAuditPattern(artist, true);
            var listModel = MyContext.ValidateModel(artist);
            if (ModelIsValid(listModel))
                return View(artist);
            try
            {         
                    this.CheckAuditPattern(artist, true);
                    db.Artist.Add(artist);
                    db.SaveChanges();

                    return RedirectToAction("Index");
                             
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
            }

            return View(artist);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = MyContext.GetById(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }
        [HttpPost]
        public ActionResult Edit(Artist artist)
        {
            this.CheckAuditPattern(artist);
            var listModel = MyContext.ValidateModel(artist);
            if (ModelIsValid(listModel))
                return View(artist);
            try
            {
                MyContext.Update(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var artist = MyContext.GetById(id.Value);
            if (artist == null)
            {
                return HttpNotFound();
            }
            return View(artist);
        }
        [HttpPost]
        public ActionResult Delete(Artist artist)
        {
            try
            {
                MyContext.Delete(artist);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Instance.LogException(ex);
                ViewBag.MessageDanger = ex.Message;
                return View(artist);
            }
        }
    }
}