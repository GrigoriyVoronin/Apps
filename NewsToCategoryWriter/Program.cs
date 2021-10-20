using System;
using System.Linq;
using LentaNews;
using Microsoft.ML;
using NewsСlassifiсator;

namespace NewsToCategoryWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NewsDbContext();
            var predicter = GetPredictionEngine();
            while (true)
            {
                Console.WriteLine("Title: ");
                var title = Console.ReadLine();
                if(string.IsNullOrWhiteSpace(title))
                    break;

                Console.WriteLine("Text: ");
                var text = string.Empty;
                while (true)
                {
                    var a =Console.ReadLine();
                    if (a == "break")
                        break;

                    text += a;
                }

                Console.WriteLine(predicter.Predict(new NewsModel(title, text, DateTime.Today.ToShortDateString(), null)).Category);
            }
        }


        public static PredictionEngine<NewsModel, CategoryPrediction> GetPredictionEngine()
        {
            var mlContext = new MLContext(0);
            var loadedModel = mlContext.Model.Load("C:\\Users\\molch\\Desktop\\Razrabotka\\С#\\2к\\SoftwareEngineering\\NewsClassificator\\Models\\model.zip", out _);
            return mlContext.Model.CreatePredictionEngine<NewsModel, CategoryPrediction>(loadedModel);
        }
    }
}
