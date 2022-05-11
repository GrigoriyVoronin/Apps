using System;

namespace Lab8
{
    public static class DocumentAdapter
    {
        public static RussianDocument TranslateEnglishToRussian(EnglishDocument englishDocument)
        {
            Console.WriteLine("Перевод документа:");
            Console.WriteLine($"Переведите название \"{englishDocument.Title}\": ");
            var russianTitle = Console.ReadLine();
            Console.WriteLine($"Переведите позицию \"{englishDocument.Position}\": ");
            var russianPosition = Console.ReadLine();
            return new RussianDocument(russianTitle, englishDocument.Text, russianPosition, englishDocument.FullName, englishDocument.Date);
        }
    }
}