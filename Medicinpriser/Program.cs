
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

      for (int row = 1; row <= rowCount; row++) // Numeration starts from 0 to MaxDataRow
      {
        for (int column = 1; column <= columnCount; column++)  // Numeration starts from 0 to MaxDataColumn
        {
        var row2 = cells.Columns[0];
          Product product = new Product();
          if (column < 8) {
            //product.ATC = cells[row, column].Value;

          }
          strCell = "";
          strCell = Convert.ToString(cells[row, column].Value);
          if (String.IsNullOrEmpty(strCell))
          {
            continue;
          }
          else
          {
            // Do your staff here
            Console.WriteLine(strCell);
          }
        }
      }
    }
  }
}
