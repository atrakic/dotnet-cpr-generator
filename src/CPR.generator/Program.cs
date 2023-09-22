using Dumpify;
using RandomNameGeneratorLibrary;
using System.Text.Json;
using System.Xml.Serialization;

namespace CPRGenerator
{
    public class Person
    {
        public string Name { get; set; } = null!;
        public string CprNo { get; set; } = null!;
    }

    class Program
    {
        static Random random = new Random();
        static PersonNameGenerator personGenerator = new PersonNameGenerator();

        static void Main(string[] args)
        {
            string input = Environment.GetEnvironmentVariable("LIMIT") ?? "";
            string format = Environment.GetEnvironmentVariable("FORMAT") ?? "";
            int limit = 3;

            if (input != "")
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

            for (var i = 0; i < limit; i++)
            {
                //System.Diagnostics.Debug.WriteLine(i);
                GeneratePerson(i, format);
            }
        }

        public static void GeneratePerson(object state, string format)
        {
            var person = new Person
            {
                Name = personGenerator.GenerateRandomFirstAndLastName(),
                CprNo = GenerateCprNo()
            };
            DisplayPerson(person, format);
        }

        private static string GenerateCprNo()
        {
            var daysOld = random.Next(20 * 365, 100 * 365);
            var bday = DateTime.Today.AddDays(-daysOld);
            var seq = random.Next(1000, 9999);
            return bday.ToString("ddMMyy") + "-" + seq.ToString();
        }

        private static void DisplayPerson(Person obj, string format)
        {
            switch (format)
            {
                case "plain":
                    Console.WriteLine($"CPR: {obj.CprNo} Name: {obj.Name}");
                    break;
                case "csv":
                    Console.WriteLine($"{obj.CprNo},{obj.Name}");
                    break;
                case "xml":
                    XmlSerializer x = new XmlSerializer(obj.GetType());
                    x.Serialize(Console.Out, obj);
                    Console.WriteLine();
                    break;
                case "json":
                    string jsonString = JsonSerializer.Serialize(obj);
                    Console.WriteLine(jsonString);
                    break;
                default:
                    obj?.Dump();
                    break;
            }
        }
    }
}
