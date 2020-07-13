using HardwarePC.Data.Services;
using System.Data.Entity;
using System.Web.Mvc;

namespace HardwarePC.WebSite.Controllers
{
    public class CartItemController : BaseController
    {
        private readonly ArtShopDbContext db = new ArtShopDbContext();
        public ActionResult Index()
        {
            var cartItem = db.CartItem.Include(c => c.Cart);
            return View(cartItem);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var item = db.CartItem.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var item = db.CartItem.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            db.CartItem.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
        //public ActionResult finalizarCompra()
        //{
        //    return RedirectToAction("Order/Index");
        //}
    }
}