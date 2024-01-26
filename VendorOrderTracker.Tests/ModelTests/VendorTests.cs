using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System.Collections.Generic;

namespace VendorOrderTracker.Tests.ModelTests
{
    [TestClass]
    public class VendorTests
    {
        [TestMethod]
        public void VendorConstructor_CreatesInstanceOfVendor_Vendor()
        {
            Vendor newVendor = new Vendor("Suzie's Cafe", "Local cafe");
            Assert.AreEqual(typeof(Vendor), newVendor.GetType());
        }

        [TestMethod]
        public void AddOrder_AssociatesOrderWithVendor_OrderList()
        {
        
            string title = "Pastry Order";
            string description = "Croissants";
            int price = 18;
            string date = "2024-01-24";
            Order newOrder = new Order(title, description, price, date);
            List<Order> newList = new List<Order> { newOrder };
            Vendor newVendor = new Vendor("Suzie's Cafe", "Local cafe");

            
            newVendor.AddOrder(newOrder);
            List<Order> result = newVendor.Orders;

            
            CollectionAssert.AreEqual(newList, result);
        }
    }
}