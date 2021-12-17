using System;
using System.Globalization;

namespace UserLocales
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var enUS = new CultureInfo("en-US");
      Console.WriteLine(enUS.DateTimeFormat.GetDayName(DayOfWeek.Monday));
      Console.WriteLine(enUS.NumberFormat.NumberDecimalSeparator);

      var nlBE = new CultureInfo("nl-BE");
      Console.WriteLine(nlBE.DateTimeFormat.GetDayName(DayOfWeek.Monday));
      Console.WriteLine(nlBE.NumberFormat.NumberDecimalSeparator);

      Console.WriteLine(DateTime.Now.ToString("D", nlBE));

      CultureInfo.CurrentCulture = nlBE;
      Console.WriteLine($"{DateTime.Now:D}");
    }
  }
}
