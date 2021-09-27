using System;
using System.Collections.Generic;
using System.Text;

namespace Medicinpriser.Models {
  public class DateAndPrice {
    public DateTime Date { get; set; }
    public double Price { get; set; }

    public override string ToString() {
      return $"Date: {Date.ToString()}, Price: {Price}\n";
    }
  }
}
