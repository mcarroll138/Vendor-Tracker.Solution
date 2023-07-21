using System.Collections.Generic;

namespace VendorTracker.Models
{
  public class Order
  {
    public string Description { get; set; }
    private static List<Order> _instances = new List<Order> { };

    public Order(string description)
    {
      Description = description;
      _instances.Add(this);
      // ID = _instances.Count;
    }

    public static List<Order> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}