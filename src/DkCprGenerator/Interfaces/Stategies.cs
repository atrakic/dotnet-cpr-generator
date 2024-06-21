using System;
using System.Text.Json;
using System.Xml.Serialization;
using Dumpify;

using DkCprGenerator.Model;

namespace DkCprGenerator.Interfaces;

public interface IDisplayStrategy
{
    void Display(Person person);
}

public class PlainDisplayStrategy : IDisplayStrategy
{
    public void Display(Person person)
    {
        Console.WriteLine($"CPR: {person.CprNo} Name: {person.Name}");
    }
}

public class CsvDisplayStrategy : IDisplayStrategy
{
    public void Display(Person person)
    {
        Console.WriteLine($"{person.CprNo},{person.Name}");
    }
}

public class XmlDisplayStrategy : IDisplayStrategy
{
    public void Display(Person person)
    {
        XmlSerializer x = new XmlSerializer(person.GetType());
        x.Serialize(Console.Out, person);
        Console.WriteLine();
    }
}

public class JsonDisplayStrategy : IDisplayStrategy
{
    public void Display(Person person)
    {
        string jsonString = JsonSerializer.Serialize(person);
        Console.WriteLine(jsonString);
    }
}

public class DefaultDisplayStrategy : IDisplayStrategy
{
    public void Display(Person person)
    {
        person?.Dump();
    }
}
