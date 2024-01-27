using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorOrderTracker.Models;
using System;

namespace VendorOrderTracker.Tests
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void OrderConstructor_CreatesInstanceOfOrder_Order()
        {
            Order newOrder = new Order("Order Title", "Description", 10.99, DateTime.Now);
            Assert.AreEqual(typeof(Order), newOrder.GetType());
        }

        [TestMethod]
        public void GetProperties_ReturnsProperties_PropertyValues()
        {
            // Arrange
            string title = "Order Title";
            string description = "Description";
            double price = 10.99;
            DateTime date = DateTime.Now;

            // Act
            Order newOrder = new Order(title, description, price, date);

            // Assert
            Assert.AreEqual(title, newOrder.Title);
            Assert.AreEqual(description, newOrder.Description);
            Assert.AreEqual(price, newOrder.Price);
            Assert.AreEqual(date, newOrder.Date);
        }
    }
}