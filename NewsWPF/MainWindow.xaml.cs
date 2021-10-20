using System;
using System.Windows;
using LentaNews;
using Microsoft.ML;
using NewsСlassifiсator;

namespace NewsWPF
{
    public partial class MainWindow : Window
    {
        private readonly PredictionEngine<NewsModel, CategoryPrediction> _predictionEngine;

        public MainWindow()
        {
            var mlContext = new MLContext(0);
            var pipeLine = mlContext.Model.Load("Models/model.zip", out _);
            _predictionEngine = mlContext.Model.CreatePredictionEngine<NewsModel, CategoryPrediction>(pipeLine);
            InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var category = _predictionEngine
                .Predict(new NewsModel(TitleBox.Text, TextBox.Text, DateTime.Today.ToShortDateString(),
                    null));
            CategoryBlock.Text = category.Category;
        }
    }
}