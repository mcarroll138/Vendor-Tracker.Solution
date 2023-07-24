using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendorTracker.Models;
using System.Collections.Generic;
using System;

namespace VendorTracker.Tests
{
  [TestClass]
  public class VendorTests : IDisposable
  {
    public void Dispose()
    {
      Vendor.ClearAll();
    }

    [TestMethod]
    public void VendorConstructor_CreatesInstanceOfVendor()
    {
      Vendor newVendor = new Vendor("vendor", "description");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "vendor";
      string description = "description";
      Vendor newVendor = new Vendor(name, description);

      //Act
      string result = newVendor.Name;
      string result2 = newVendor.Description;

      //Assert
      Assert.AreEqual(name, result);
      Assert.AreEqual(description, result2);
    }
    [TestMethod]
    public void GetId_ReturnsVendorID()
    {
      //Arrange
      string name = "vendor";
      Vendor newVendor = new Vendor(name, "description");

      //Act
      int result = newVendor.Id;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendors()
    {
      //Arrange
      string vendor01 = "Shelly's Bakery";
      string vendor02 = "Breaking Bread";
      Vendor newVendor1 = new Vendor(vendor01, "description");
      Vendor newVendor2 = new Vendor(vendor02, "description");
      List<Vendor> newList = new List<Vendor> { newVendor1, newVendor2 };

      //Act
      List<Vendor> result = Vendor.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectVendor()
    {
      //Arrange
      string vendor01 = "Shelly's Bakery";
      string vendor02 = "Breaking Bread";
      Vendor newVendor1 = new Vendor(vendor01, "description");
      Vendor newVendor2 = new Vendor(vendor02, "description");

      //Act
      Vendor result = Vendor.Find(2);

      //Assert
      Assert.AreEqual(newVendor2, result);

    }
    [TestMethod]
    public void AddOrder_AssociateWithVendor()
    {
      //Arrange
      string description = "100 Loaves of bread.";
      Order newOrder = new Order("Vendor Name", description);
      List<Order> newList = new List<Order> { newOrder };
      string name = "Shelly's Bakery";
      Vendor newVendor = new Vendor(name, "description");
      newVendor.AddOrder(newOrder);

      //Act
      List<Order> result = newVendor.Orders;

      //Assert
      CollectionAssert.AreEqual(newList, result);
    }
  }
}