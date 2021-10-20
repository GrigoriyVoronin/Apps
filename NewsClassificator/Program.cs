using System;
using System.IO;
using LentaNews;
using Microsoft.Data.SqlClient;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms.Text;

namespace NewsСlassifiсator
{
    public class Program
    {
        private const string Text = "Text";
        private const string Title = "Title";
        private static MLContext mlContext;
        private static string AppPath => Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        private static string ModelPath => Path.Combine(AppPath, "..", "..", "..", "Models", "model.zip");

        public static void Main()
        {
            mlContext = new MLContext(0);
            var trainingDataView = GetData(false);
            var pipeline = ProcessData();
            var trainedModel = BuildAndTrainModel(pipeline, trainingDataView);
            Evaluate(trainingDataView.Schema, trainedModel);
        }

        private static IEstimator<ITransformer> ProcessData()
        {
            var pipeline =
                mlContext.Transforms.Conversion.MapValueToKey(inputColumnName: "Category", outputColumnName: "Label");
            pipeline
                .Append(mlContext.Transforms.Text.NormalizeText(Text))
                .Append(mlContext.Transforms.Text.TokenizeIntoWords(Text))
                .Append(mlContext.Transforms.Text.RemoveDefaultStopWords(Text, Text,
                    StopWordsRemovingEstimator.Language.Russian))
                .Append(mlContext.Transforms.Text.FeaturizeText(Text))
                .Append(mlContext.Transforms.Text.NormalizeText(Title))
                .Append(mlContext.Transforms.Text.TokenizeIntoWords(Title))
                .Append(mlContext.Transforms.Text.RemoveDefaultStopWords(Title, Title,
                    StopWordsRemovingEstimator.Language.Russian))
                .Append(mlContext.Transforms.Text.FeaturizeText(Title))
                .Append(mlContext.Transforms.Concatenate("Features", Title, Text))
                .AppendCacheCheckpoint(mlContext);
            return pipeline;
        }

        private static ITransformer BuildAndTrainModel(IEstimator<ITransformer> pipeline, IDataView trainingDataView)
        {
            var trainingPipeline = pipeline
                .Append(mlContext.MulticlassClassification.Trainers.SdcaMaximumEntropy())
                .Append(mlContext.Transforms.Conversion.MapKeyToValue("PredictedLabel"));
            return trainingPipeline.Fit(trainingDataView);
        }

        private static void Evaluate(DataViewSchema trainingDataViewSchema, ITransformer trainedModel)
        {
            var testDataView = GetData(true);
            var testMetrics = mlContext.MulticlassClassification.Evaluate(trainedModel.Transform(testDataView));
            Console.WriteLine("*       Metrics for Multi-class Classification model - Test Data     ");
            Console.WriteLine($"*      MicroAccuracy:    {testMetrics.MicroAccuracy:0.###}");
            Console.WriteLine($"*      MacroAccuracy:    {testMetrics.MacroAccuracy:0.###}");
            mlContext.Model.Save(trainedModel, trainingDataViewSchema, ModelPath);
        }

        private static IDataView GetData(bool isTest)
        {
            const string sqlCommandForLearn =
                "SELECT TOP 80 PERCENT Title, Text, Category, Date\nFROM News\nORDER BY Title";
            const string sqlCommandForTest =
                "SELECT TOP 20 PERCENT Title, Text, Category, Date\nFROM News\nORDER BY Title DESC";
            return mlContext.Data
                .CreateDatabaseLoader<NewsModel>()
                .Load(new DatabaseSource(SqlClientFactory.Instance, NewsDbContext.Connection,
                    isTest ? sqlCommandForTest : sqlCommandForLearn));
        }
    }

    public class CategoryPrediction
    {
        [ColumnName("PredictedLabel")] public string Category;

        public override string ToString() => Category;
    }
}