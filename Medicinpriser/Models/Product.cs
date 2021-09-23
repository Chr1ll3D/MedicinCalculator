using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Medicinpriser.Models
{
  public class Product
  {
    public int VareNumber { get; set; }
    public string ATC { get; set; }
    public string Medicine { get; set; }
    public string Packing { get; set; }
    public string Strength { get; set; }
    public string Form { get; set; }
    public string Firm { get; set; }
    public string Indicator { get; set; }
    public List<DateAndPrice> DateAndPrices { get; set; }

  }
}
