namespace E1News
{
    public class NewsModel
    {
        public NewsModel(string title, string text, string date)
        {
            Title = title;
            Text = text;
            Date = date;
        }

        public string Title { get; }
        public string Text { get; }
        public string Date { get; }

        public override string ToString()
        {
            return $"{nameof(Title)}: {Title}\n" +
                   $"{nameof(Text)}: {Text}\n" +
                   $"{nameof(Date)}: {Date}";
        }
    }
}
