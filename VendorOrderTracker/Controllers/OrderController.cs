using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;
using System;

namespace VendorOrderTracker.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet("/vendors/{vendorId}/orders/new")]
        public ActionResult New(int vendorId)
        {
            Vendor vendor = Vendor.Find(vendorId);
            return View("NewOrder", vendor);
        }

        [HttpPost("/vendors/{vendorId}/orders")]
        public ActionResult Create(int vendorId, string orderTitle, string orderDescription, double orderPrice, string orderDate)
        {
            DateTime parsedDate;
            if (DateTime.TryParse(orderDate, out parsedDate))
            {
                Order newOrder = new Order(orderTitle, orderDescription, orderPrice, parsedDate);
                Vendor vendor = Vendor.Find(vendorId);
                vendor.AddOrder(newOrder);
                return RedirectToAction("Show", "Vendor", new { id = vendorId });
            }
            else
            {
                // Handle the case where date parsing fails
                return View("NewOrder", Vendor.Find(vendorId));
            }
        }
    }
}