using System;
using System.Globalization;

namespace Lab8
{
    public class Document
    {
        public Document(string title, string text, string position, string fullName, DateTime date)
        {
            Title = title;
            Text = text;
            Position = position;
            FullName = fullName;
            Date = date;
        }

        public string Title { get; }
        public string Text { get; }
        public string Position { get; }
        public string FullName { get; }
        public DateTime Date { get; }
    }
}