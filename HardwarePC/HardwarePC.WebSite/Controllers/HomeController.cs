using HardwarePC.Data.Model;
using HardwarePC.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardwarePC.WebSite.Controllers
{
    public class HomeController : BaseController
    {
        BaseDataService<Product> db;
        public HomeController()
        {
            db = new BaseDataService<Product>();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public ActionResult Covid_19()
        {
            ViewBag.Message = "COVID-19";
            return View();
        }
        public ActionResult Ubicacion()
        {
            ViewBag.Message = "Nuestra ubicación";
            return View();
        }
        public ActionResult catalogoProductos()
        {
            ViewBag.Message = "Cat. Productos";
            var list = db.Get();
            return View(list);
        }
    }
}