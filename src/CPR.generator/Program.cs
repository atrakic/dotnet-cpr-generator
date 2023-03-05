using RandomNameGeneratorLibrary;

namespace HelloWorld
{
  class Program
  {
    public class Person {
      public string Name { get; set; } = null!;
      public string CprNo { get; set; } = null!;
    }
    
    static Random random = new Random();
    static PersonNameGenerator personGenerator = new PersonNameGenerator();

    static void Main(string[] args)
    {
      string input = Environment.GetEnvironmentVariable("LIMIT") ?? "";
      int limit = 10;
      if (input != null)
      {
        try
        {
            limit = Int32.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{input}'");
        }
      }

      for(var i = 0; i < limit; i ++){
        System.Diagnostics.Debug.WriteLine(i);
        GeneratePerson(i);
      }
    }

    private static void GeneratePerson(object state) {
      var person = new Person {
        Name = personGenerator.GenerateRandomFirstAndLastName(),
        CprNo = GenerateCprNo()
      };
      DisplayPerson(person);
    }

    private static string GenerateCprNo()
    {
        var daysOld = random.Next(20 * 365, 100 * 365);
        var bday = DateTime.Today.AddDays(-daysOld);
        var seq = random.Next(1000, 9999);
        return bday.ToString("ddMMyy") + "-" + seq.ToString();
    }

    private static void DisplayPerson(Person obj) {
      Console.WriteLine($"CPR: {obj.CprNo} Name: {obj.Name}");
    }
  }
}
