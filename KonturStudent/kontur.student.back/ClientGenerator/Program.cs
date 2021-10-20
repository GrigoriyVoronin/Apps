using System;
using System.IO;
using System.Text;
using NSwag;
using NSwag.CodeGeneration;
using NSwag.CodeGeneration.CSharp;
using NSwag.CodeGeneration.TypeScript;

namespace ClientGenerator
{
    public class Program
    {
        private static void Main()
        {
            var jsonSchemaUrl = GetSwaggerJsonUrl();
            var document = OpenApiDocument.FromUrlAsync(jsonSchemaUrl).Result;
            GenerateClient("TS", document, GetTsClient);
            GenerateClient("CSharp", document, GetCSharpClient);
        }

        private static void GenerateClient(string clientTypeName, OpenApiDocument document,
            Func<OpenApiDocument,string> createClientCodeDelegate)
        {
            var outputPath = GetOutputPath(clientTypeName);
            if (string.IsNullOrWhiteSpace(outputPath))
                return;

            File.WriteAllText(outputPath, createClientCodeDelegate(document), Encoding.UTF8);
        }

        private static string GetCSharpClient(OpenApiDocument document)
        {
            var settings = new CSharpClientGeneratorSettings
            {
                ClassName = "{controller}Client",
                GenerateClientInterfaces = true
            };
            var generator = new CSharpClientGenerator(document, settings);
            return generator.GenerateFile(ClientGeneratorOutputType.Full);
        }

        private static string GetOutputPath(string clientType)
        {
            Console.WriteLine($"Output Path for {clientType}:");
            return Console.ReadLine();
        }

        private static string GetTsClient(OpenApiDocument document)
        {
            var settings = new TypeScriptClientGeneratorSettings
            {
                ClassName = "{controller}Client",
                GenerateClientInterfaces = true
            };
            var generator = new TypeScriptClientGenerator(document, settings);
            return generator.GenerateFile(ClientGeneratorOutputType.Full);
        }

        private static string GetSwaggerJsonUrl()
        {
            Console.WriteLine("Json Schema URL:");
            return Console.ReadLine();
        }
    }
}