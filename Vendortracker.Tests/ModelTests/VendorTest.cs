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
      Vendor newVendor = new Vendor("test vendor");
      Assert.AreEqual(typeof(Vendor), newVendor.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      //Arrange
      string name = "test vendor";
      Vendor newVendor = new Vendor(name);

      //Act
      string result = newVendor.Name;

      //Assert
      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void GetId_ReturnsVendorID()
    {
      //Arrange
      string name = "test vendor";
      Vendor newVendor = new Vendor(name);

      //Act
      int result = newVendor.ID;

      //Assert
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllVendors()
    {
      //Arrange
      string vendor01 = "Shelly's Bakery";
      string vendor02 = "Breaking Bread";
      Vendor newVendor1 = new Vendor(vendor01);
      Vendor newVendor2 = new Vendor(vendor02);
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
      Vendor newVendor1 = new Vendor(vendor01);
      Vendor newVendor2 = new Vendor(vendor02);

      //Act
      Vendor result = Vendor.Find(2);

      //Assert
      Assert.AreEqual(newVendor2, result);

    }
  }
}