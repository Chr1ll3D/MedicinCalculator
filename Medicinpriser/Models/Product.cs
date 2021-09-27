using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Medicinpriser.Models
{
  public class Product
  {
    public int ItemNumber { get; set; }
    public string ATC { get; set; }
    public string Medicine { get; set; }
    public string Packing { get; set; }
    public string Strength { get; set; }
    public string Form { get; set; }
    public string Firm { get; set; }
    public string Indicator { get; set; }
    public List<DateAndPrice> DateAndPrices { get; set; }

    public override string ToString() {
      var text = $"ItemNumber: {ItemNumber}, ATC: {ATC}, Medicine: {Medicine}, Packing: {Packing}, Strength: {Strength}, Form: {Form}, Firm: {Firm}, Indicator: {Indicator}\n"
                + "----------------------------------------------------------------------------------------------------------------------------------------------------------\n";
      foreach (DateAndPrice dateAndPrice in DateAndPrices) {
        text += dateAndPrice.ToString();
      }
      return text;
    }
  }
}
