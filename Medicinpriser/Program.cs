
//using Spire.Xls;
using Aspose.Cells;
using Medicinpriser.Models;
using System;
using System.Collections.Generic;

namespace Medicinpriser
{
  class Program
  {
    //public static void Main(string[] args)
    //{
    //  // The path to the documents directory.
    //  Workbook workbook = new Workbook();

    //  workbook.LoadFromFile(@"C:\Users\Chril\Desktop\Programming\Medicinpriser\Medicinpriser\Medicinpriser\lmpriser_eSundhed_210920.xlsx", ExcelVersion.Version2016);
    //  Worksheet sheet = workbook.Worksheets[1];
    //  var dataTable = sheet.ExportDataTable();
    //  Console.ReadKey();
    //}

    static void Main(string[] args)
    {
      // Replace path for your file
      readXLS(@"C:\Users\Chril\Desktop\Programmering\MedicinCalculator\Medicinpriser\lmpriser_eSundhed_210920.xlsx"); // or "*.xlsx"
      Console.ReadKey();
    }

    public static void readXLS(string PathToMyExcel)
    {
      //Open your template file.
      Workbook wb = new Workbook(PathToMyExcel);

      //Get the first worksheet.
      Worksheet worksheet = wb.Worksheets[1];

      //Get cells
      Cells cells = worksheet.Cells;

      // Get row and column count
      int rowCount = cells.MaxDataRow;
      int columnCount = cells.MaxDataColumn;

      var dataTable = cells.ExportDataTable(0, 0, rowCount, columnCount);

      // Current cell value
      string strCell = "";

      Console.WriteLine(String.Format("rowCount={0}, columnCount={1}", rowCount, columnCount));

      List<Product> products = new List<Product>();

      for (int i = 1; i <= rowCount; i++) // Numeration starts from 0 to MaxDataRow
      {
        Product product = new Product();
        product.ATC = cells.GetCell(i, 0).StringValue;
          product.Medicine = cells.GetCell(i, 1).StringValue;
        product.ItemNumber = int.Parse(cells.GetCell(i, 2).StringValue);
          product.Packing = cells.GetCell(i, 3).StringValue;
          product.Strength = cells[i, 4].Value != null ? cells.GetCell(i, 4).StringValue : "";
          product.Form = cells.GetCell(i, 5).StringValue;
          product.Firm = cells.GetCell(i, 6).StringValue;
          product.Indicator = cells.GetCell(i, 7).StringValue;
        product.DateAndPrices = new List<DateAndPrice>();

        for (int j = 8; j <= columnCount; j++)  // Numeration starts from 0 to MaxDataColumn
        {
          strCell = "";
          strCell = Convert.ToString(cells[i, j].Value);
          if (cells[i, j].Value == null) {
            Console.WriteLine("No value");
            continue;
          }

          var date = cells[0, j].StringValue;
          var year = int.Parse(date.Substring(0, 4));
          var month = int.Parse(date.Substring(4, 2));
          var day = int.Parse(date.Substring(6, 2));

          
          product.DateAndPrices.Add(new DateAndPrice() { Date = new DateTime(year, month, day), Price = cells[i, j].DoubleValue });
          //if (String.IsNullOrEmpty(strCell))
          //{
          //  continue;
          //}
          //else
          //{
          //  // Do your staff here
          //  Console.WriteLine(strCell);
          //}
        }
        products.Add(product);
      }
      foreach (var product in products) {
        Console.WriteLine(product.ToString());
      }
    }
  }
}
