using HardwarePC.Data.Model;
using HardwarePC.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HardwarePC.WebSite.Controllers
{
    public class OrderController : BaseController
    {
        // GET: Shop
        private readonly BaseDataService<CartItem> MyContext = new BaseDataService<CartItem>();
        private readonly ArtShopDbContext db = new ArtShopDbContext();

        [Authorize]
        public ActionResult Index(int CartId)
        {

            //var orderDetail = db.OrderDetail.Include(c => c.Order);

            var order = new Order
            {
                OrderDate = DateTime.Now,
                TotalPrice = 5000,
                ItemCount = 40,
                UserId = 9,
                OrderNumber = 1
            };
            this.CheckAuditPattern(order, true);

            var orderDet = new OrderDetail
            {
                Price = (float)MyContext.GetById(CartId).Price,
                ProductId = MyContext.GetById(CartId).ProductId,
                Quantity = MyContext.GetById(CartId).Quantity,
            };
            this.CheckAuditPattern(orderDet, true);

            order.OrderDetail = new List<OrderDetail>() { orderDet };
            db.Order.Add(order);
            db.SaveChanges();            
            return View(order.OrderDetail);
        }
        
        public ActionResult finalizarCompra()
        {
            return View();
        }

    }
}