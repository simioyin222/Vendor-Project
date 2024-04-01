using Microsoft.AspNetCore.Mvc;
using VendorOrderTracker.Models;
using System.Collections.Generic;

namespace VendorOrderTracker.Controllers
{
    public class VendorController : Controller
    {
        [HttpGet("/vendors")]
        public ActionResult Index()
        {
            List<Vendor> allVendors = Vendor.GetAll();
            return View(allVendors);
        }

        [HttpGet("/vendors/new")]
        public ActionResult New()
        {
            return View("NewVendor"); // Updated to the new view name
        }

        [HttpPost("/vendors")]
        public ActionResult Create(string vendorName, string vendorDescription)
        {
            Vendor newVendor = new Vendor(vendorName, vendorDescription);
            return RedirectToAction("Index");
        }

        [HttpGet("/vendors/{id}")]
        public ActionResult Show(int id)
        {
            Vendor foundVendor = Vendor.Find(id);
            if (foundVendor == null)
            {
                return NotFound();
            }
            return View(foundVendor);
        }

        [HttpPost("/vendors/delete/{id}")]
public ActionResult Delete(int id)
{
    var vendorToDelete = Vendor.Find(id);
    if (vendorToDelete == null)
    {
        // Vendor not found, redirect back to the details page
        return RedirectToAction("Show", new { id = id });
    }

    Vendor.Delete(id);
    // Assuming you have an Index view to list all vendors
    return RedirectToAction("Index");
}
    }
}