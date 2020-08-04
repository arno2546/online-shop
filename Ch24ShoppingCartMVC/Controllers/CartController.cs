///////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ch24ShoppingCartMVC.Models;

namespace Ch24ShoppingCartMVC.Controllers {
   public class CartController : Controller {
      private CartModel cart = new CartModel();

      [HttpGet]
      public RedirectToRouteResult Index() {
            int i = (int)Session["LoggedIn"];
        if (i == 1) { 
                return RedirectToAction("List/"); 
            }
        return RedirectToAction("Index", "Account");
             
      }// close Index()


      [HttpGet]
      public ActionResult List() {
        int i = (int)Session["LoggedIn"];
            if (i == 1)
            {
                CartViewModel model = (CartViewModel)TempData["cart"];
                //if the model is null, then call the method GetCart
                if (model == null)
                    model = cart.GetCart();
                //Passing model to View
                return View(model);
            }
            return RedirectToAction("Index", "Account");
        }// close List()


      [HttpPost]
      public RedirectToRouteResult List(OrderViewModel order) {
         CartViewModel model = cart.GetCart(order.SelectedProduct.ProductID);
         //Assign the quantity of the selected product to the quantity of the added product
         model.AddedProduct.Quantity = order.SelectedProduct.Quantity;
         //Call the method AddtoCart
         cart.AddToCart(model);
         //Assign model to the TempData
         TempData["cart"] = model;
         return RedirectToAction("List", "Cart");
      }// close List(...)

   }// close class CartController
}// close namespace Ch24ShoppingCartMVC.Controllers
