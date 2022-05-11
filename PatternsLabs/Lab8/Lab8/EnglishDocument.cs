using System;
using System.Globalization;

namespace Lab8
{
    public class EnglishDocument : Document
    {
        public static EnglishDocument Create()
        {
            Console.WriteLine("Enter title: ");
            var title = Console.ReadLine();
            Console.WriteLine("Enter text: ");
            var text = Console.ReadLine();
            Console.WriteLine("Enter position: ");
            var position = Console.ReadLine();
            Console.WriteLine("Enter fullname: ");
            var fullName = Console.ReadLine();
            Console.WriteLine("Enter date in format dd.mm.yyyy: ");
            var date = DateTime.Parse(Console.ReadLine(), CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
            return new EnglishDocument(title, text, position, fullName, date);
        }

        public EnglishDocument(string title, string text, string position, string fullName, DateTime date)
            : base(title, text, position, fullName, date)
        {
        }

        public override string ToString()
        {
            return "English document: \n" +
                   $"Title: {Title}\n" +
                   $"Text: {Text}\n" +
                   $"Position: {Position}\n" +
                   $"FullName: {FullName}\n" +
                   $"Date: {Date.ToShortDateString()}";
        }
    }
}