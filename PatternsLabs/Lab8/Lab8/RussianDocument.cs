using System;
using System.Globalization;

namespace Lab8
{
    public class RussianDocument : Document
    {
        public static RussianDocument Create()
        {
            Console.WriteLine("Введите название: ");
            var title = Console.ReadLine();
            Console.WriteLine("Введите текст: ");
            var text = Console.ReadLine();
            Console.WriteLine("Введите позицию: ");
            var position = Console.ReadLine();
            Console.WriteLine("Введи ФИО: ");
            var fullName = Console.ReadLine();
            Console.WriteLine("Введите дату в формате дд.мм.гггг: ");
            var date = DateTime.Parse(Console.ReadLine(), CultureInfo.CurrentCulture, DateTimeStyles.AssumeLocal);
            return new RussianDocument(title, text, position, fullName, date);
        }

        public RussianDocument(string title, string text, string position, string fullName, DateTime date)
            : base(title, text, position, fullName, date)
        {
        }

        public override string ToString()
        {
            return "Русский документ: \n" +
                   $"Название: {Title}\n" +
                   $"Текст: {Text}\n" +
                   $"Позиция: {Position}\n" +
                   $"Полное имя: {FullName}\n" +
                   $"Дата: {Date.ToShortDateString()}";
        }
    }
}