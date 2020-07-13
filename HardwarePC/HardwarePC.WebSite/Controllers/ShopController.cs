using HardwarePC.Data.Model;
using HardwarePC.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HardwarePC.WebSite.Controllers
{
    public class ShopController : BaseController
    {
        // GET: Shop
        private readonly BaseDataService<Product> MyContext = new BaseDataService<Product>();
        private readonly ArtShopDbContext db = new ArtShopDbContext();
        public ActionResult Index()
        {
            var products = MyContext.Get(null, null, "Artist");
            return View(products);
        }

        public ActionResult Buy(int id)
        {
            var cookie = "shop-art-cookie";
            var cart = new Cart
            {
                CartDate = DateTime.Now,
                Cookie = cookie,
                ItemCount = 1,
            };
            this.CheckAuditPattern(cart, true);
            var cartitem = new CartItem
            {
                
                Price = MyContext.GetById(id).Price,
                ProductId = id,
                Quantity = 1,
            };
            this.CheckAuditPattern(cartitem, true);

            cart.CartItem = new List<CartItem>() { cartitem };
            db.Cart.Add(cart);
            db.SaveChanges();
            return RedirectToAction("Index", "CartItem");
        }
    }
}