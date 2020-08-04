///////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers {
   public class CheckoutController : Controller {
      private CartModel cart = new CartModel();

      public RedirectToRouteResult Index() {
         return RedirectToAction("List/");
      }


      [HttpGet]
      public ActionResult List() {
         CartViewModel model = (CartViewModel)TempData["cart"];         
         if (model == null)
            model = cart.GetCart();        
         return View(model);
      }


      [HttpPost]
      public RedirectToRouteResult List(OrderViewModel order) {
         CartViewModel model = cart.GetCart(order.SelectedProduct.ProductID);         
         model.AddedProduct.Quantity = order.SelectedProduct.Quantity;
         cart.AddToCart(model);         
         TempData["cart"] = model;
         return RedirectToAction("Index", "Checkout");
      }

   }
}
