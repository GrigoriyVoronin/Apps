namespace LentaNews
{
    public class NewsModel
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }

        public NewsModel()
        {
            //FOR EF
        }

        public NewsModel(string title, string text, string date, string category)
        {
            Title = title;
            Text = text;
            Date = date;
            if (title == null || text == null || date == null)
                Category = "Parse Error";
            else
                Category = category;
        }

        public override string ToString()
        {
            return $"{nameof(Title)}: {Title}\n" +
                   $"{nameof(Text)}: {Text}\n" +
                   $"{nameof(Date)}: {Date}\n" +
                   new string('-', 25);
        }
    }
}
