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
            return View(vendor);
        }

        [HttpPost("/vendors/{vendorId}/orders")]
        public ActionResult Create(int vendorId, string title, string description, double price, string date)
        {
            DateTime orderDate = DateTime.Parse(date);  // Convert string to DateTime
            Order newOrder = new Order(title, description, price, orderDate);
            Vendor vendor = Vendor.Find(vendorId);
            vendor.AddOrder(newOrder);
            return RedirectToAction("Show", "Vendor", new { id = vendorId });
        }
    }
}