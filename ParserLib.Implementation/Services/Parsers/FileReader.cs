using Newtonsoft.Json;
using ParserLib.Services.Parsers;
using YamlDotNet.Serialization;

namespace ParserLib.Implementation.Services.Parsers;

internal class FileReader : IFileReader
{
    public string Read(string filePath)
    {
        var fileName = filePath.Split('.').Last();
        switch (fileName)
        {
            case "yaml": return ReadYamlFile(filePath);
            case "json": return ReadTextFile(filePath);
        }
        throw new Exception("Parser not available");
    }

    private string ReadTextFile(string filePath)
    {
        if (File.Exists(filePath))
            return File.ReadAllText(filePath);
        throw new ArgumentException("File not found");
    }

    private string ReadYamlFile(string filePath)
    {
        var r = new StreamReader(filePath);
        var deserializer = new Deserializer();
        var yamlObject = deserializer.Deserialize(r);

        JsonSerializer js = new JsonSerializer();

        var w = new StringWriter();
        js.Serialize(w, yamlObject);
        return w.ToString();
    }
}