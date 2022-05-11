using System;

namespace Lab8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var englishDocument = EnglishDocument.Create();
            Console.WriteLine($"Вы ввели:\n{englishDocument}");
            Console.WriteLine(new string('-', 10));
            var translatedDocument = DocumentAdapter.TranslateEnglishToRussian(englishDocument);
            Console.WriteLine($"Переведённый документ:\n{translatedDocument}");
        }
    }
}
