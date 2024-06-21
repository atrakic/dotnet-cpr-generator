using System;
using System.CommandLine;
using RandomNameGeneratorLibrary;

using DkCprGenerator.Helpers;
using DkCprGenerator.Interfaces;
using DkCprGenerator.Model;

namespace DkCprGenerator
{
    class Program
    {
        static PersonNameGenerator personGenerator = new RandomNameGeneratorLibrary.PersonNameGenerator();

        static async Task<int> Main(string[] args)
        {
            var formatOption = new Option<string>(
                 "--format",
                getDefaultValue: () => "default",
                description: "The format to display the person in. Options: plain, csv, xml, json"
            );

            var limitOption = new Option<int>(
                "--limit",
                getDefaultValue: () => 3,
                description: "The number of persons to generate"
            );

            var rootCommand = new RootCommand("Generate CPR numbers and display them in various formats. Uses strategy pattern for displaying.");

            rootCommand.AddOption(formatOption);
            rootCommand.AddOption(limitOption);

            rootCommand.SetHandler((format, limit) =>
            {
                GenerateAndDisplay(format!, limit);
            }, formatOption, limitOption);

            return await rootCommand.InvokeAsync(args);
        }

        internal static void GenerateAndDisplay(string format, int limit)
        {
            IDisplayStrategy displayStrategy = DisplayStrategyFactory.GetDisplayStrategy(format);

            for (var i = 0; i < limit; i++)
            {
                var person = new Person
                {
                    Name = personGenerator.GenerateRandomFirstAndLastName(),
                    CprNo = new GenerateCprNumber().Generate()
                };
                DisplayPerson(i, displayStrategy, person);
            }
        }

        internal static void DisplayPerson(object state, IDisplayStrategy displayStrategy, Person person)
        {
            displayStrategy.Display(person);
        }
    }

    public static class DisplayStrategyFactory
    {
        public static IDisplayStrategy GetDisplayStrategy(string format)
        {
            return format.ToLower() switch
            {
                "plain" => new PlainDisplayStrategy(),
                "csv" => new CsvDisplayStrategy(),
                "xml" => new XmlDisplayStrategy(),
                "json" => new JsonDisplayStrategy(),
                _ => new DefaultDisplayStrategy(),
            };
        }
    }
}
