using System;

using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ShapeGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            dict = new Dictionary<CheckBox, Func<Shape>>
            {
                {circleCheckBox,  ()=> new Circle(writer)},
                {lineCheckBox,  ()=> new Line(writer)},
                {squareCheckBox,  ()=> new Square(writer)},
                {rectangleCheckBox,  ()=> new Rectangle(writer)},
                {pentagonCheckBox,  ()=> new Pentagon(writer)},
                {hexagonCheckBox,  ()=> new Hexagon(writer)},
                {triangleCheckBox,  ()=> new Triangle(writer)}
            };
        }

        ImageWriter writer = new ImageWriter();

        Dictionary<CheckBox, Func<Shape>> dict { get; set; }

        Random random = new Random();

        int numberOfFiles = 0;
        int fileNumber = 0;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            fileNumber = 0;

            if (!dict.Keys.Any(x => x.IsChecked.Value))
            {
                MessageBox.Show("Please select a value");
                return;
            }

            var watch = Stopwatch.StartNew();

            var itemTypesSelected = dict.Where(x => x.Key.IsChecked.Value).ToList();
            var itemTypesSelectedCount = itemTypesSelected.Count;

            int result = 0;

            if (int.TryParse(txtNumberOfFiles.Text, out result))
            {
                numberOfFiles = result;
            }

            Parallel.For(0, numberOfFiles, (index) =>
            {
                var itemToGenerate = itemTypesSelected[random.Next(0, itemTypesSelectedCount)];
                var x = itemToGenerate.Value();
                x.Draw();
                Interlocked.Increment(ref fileNumber);
            });

            watch.Stop();

            var timeTaken = watch.Elapsed;

            lblNumberOfFiles.Foreground = System.Windows.Media.Brushes.Green;
            lblNumberOfFiles.Content = $"{numberOfFiles} files saved in {timeTaken.TotalSeconds}";
        }
    }
}
