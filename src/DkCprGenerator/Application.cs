
using Microsoft.Extensions.Configuration;
using System.CommandLine;
using RandomNameGeneratorLibrary;

using DkCprGenerator.Helpers;
using DkCprGenerator.Interfaces;
using DkCprGenerator.Model;

namespace DkCprGenerator;

public class Application
{
    private readonly IConfiguration _configuration;

    public Application(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public static async Task<int> RunAsync(string[] args)
    {
        var formatOption = new Option<string>(
            "--format",
            getDefaultValue: () => "default",
            description: "The format to display the person in. Options: dump, csv, xml, json"
        );

        var countOption = new Option<int>(
            "--count",
            getDefaultValue: () => 1,
            description: "The number of persons to generate"
        );

        var rootCommand = new RootCommand("Generate CPR numbers and display them in various formats.");
        rootCommand.AddOption(formatOption);
        rootCommand.AddOption(countOption);

        rootCommand.SetHandler((format, count) =>
            {
                GeneratePerson(format!, count);
            }, formatOption, countOption);

        return await rootCommand.InvokeAsync(args);
    }

    internal static void GeneratePerson(string format, int count = 1)
    {
        IDisplayStrategy displayStrategy = DisplayStrategyFactory.GetDisplayStrategy(format);

        for (var i = 0; i < count; i++)
        {
            var person = new Person
            {
                Name = new RandomNameGeneratorLibrary.PersonNameGenerator().GenerateRandomFirstAndLastName(),
                Cpr = new GenerateCprNumber().Generate()
            };
            displayStrategy.Display(person);
        }
    }
}

public static class DisplayStrategyFactory
{
    public static IDisplayStrategy GetDisplayStrategy(string format)
    {
        return format.ToLower() switch
        {
            "dump" => new DumpDisplayStrategy(),
            "csv" => new CsvDisplayStrategy(),
            "xml" => new XmlDisplayStrategy(),
            "json" => new JsonDisplayStrategy(),
            _ => new DefaultDisplayStrategy(),
        };
    }
}
