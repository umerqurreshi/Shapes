using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        }

        Random randomNum = new Random();

        private void button_Click(object sender, RoutedEventArgs e)
        {

            if (circleCheckBox.IsChecked.Value)
            {
                Canvas canvas = new Canvas();
                Ellipse ellipse = new Ellipse();
                canvas.Height = 200;
                canvas.Width = 200;
                ellipse.Height = randomNum.Next(1, 400);
                ellipse.Width = ellipse.Height;
                ellipse.Stroke = Brushes.Black;
                grid.Children.Add(ellipse);
            }
            else
            {
                Draw();
            }

        }

        private void Draw()
        {
            Polygon myPolygon = new Polygon();
            myPolygon.Stroke = Brushes.Black;
            myPolygon.StrokeThickness = 2;



            PointCollection myPointCollection = new PointCollection();

            if (lineCheckBox.IsChecked.Value)
            {
                myPointCollection.Clear();
                myPointCollection.Add(new Point(randomNum.Next(300, 600), randomNum.Next(600, 700)));
                myPointCollection.Add(new Point(randomNum.Next(300, 600), randomNum.Next(600, 700)));
            }
            if (triangleCheckBox.IsChecked.Value)
            {
                myPointCollection.Clear();
                myPointCollection.Add(new Point(randomNum.Next(150, 500), randomNum.Next(500, 680)));
                myPointCollection.Add(new Point(randomNum.Next(150, 600), randomNum.Next(440, 580)));
                myPointCollection.Add(new Point(randomNum.Next(150, 500), randomNum.Next(440, 580)));
            }
            if (squareCheckBox.IsChecked.Value)
            {
                myPointCollection.Clear();
                int randomNumberx;
                int randomNumber2x;
                int randomNumber2y;
                int randomNumbery;

                do
                {
                    randomNumberx = randomNum.Next(350, 900);
                    randomNumber2x = randomNum.Next(400, 700);
                    randomNumbery = randomNum.Next(100, 300);
                    randomNumber2y = randomNum.Next(100, 300);
                } while (randomNumber2x - randomNumberx != randomNumber2y - randomNumbery);

                myPointCollection.Add(new Point(randomNumberx, randomNumbery));
                myPointCollection.Add(new Point(randomNumberx, randomNumber2y));
                myPointCollection.Add(new Point(randomNumber2x, randomNumber2y));
                myPointCollection.Add(new Point(randomNumber2x, randomNumbery));
            }

            if (rectangleCheckBox.IsChecked.Value)
            {
                myPointCollection.Clear();
                int randomNumberx;
                int randomNumber2x;
                int randomNumber2y;
                int randomNumbery;

                do
                {
                    randomNumberx = randomNum.Next(350, 900);
                    randomNumber2x = randomNum.Next(400, 700);
                    randomNumbery = randomNum.Next(100, 300);
                    randomNumber2y = randomNum.Next(100, 300);
                } while (randomNumber2x - randomNumberx == randomNumber2y - randomNumbery);

                myPointCollection.Add(new Point(randomNumberx, randomNumbery));
                myPointCollection.Add(new Point(randomNumberx, randomNumber2y));
                myPointCollection.Add(new Point(randomNumber2x, randomNumber2y));
                myPointCollection.Add(new Point(randomNumber2x, randomNumbery));
            }

            RotateTransform rotateTransform = new RotateTransform(randomNum.Next(0, 90), 0, 0);
            myPolygon.Points = myPointCollection;
            myPolygon.RenderTransform = rotateTransform;
            rotateTransform.Angle = randomNum.Next(0, 90);
            rotateTransform.CenterX = 400;
            rotateTransform.CenterY = 200;
            grid.Children.Add(myPolygon);
        }

        private void circleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            lineCheckBox.IsChecked = false;
            squareCheckBox.IsChecked = false;
            triangleCheckBox.IsChecked = false;
            rectangleCheckBox.IsChecked = false;
            pentagonCheckBox.IsChecked = false;
            hexagonCheckBox.IsChecked = false;
        }

        private void lineCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            circleCheckBox.IsChecked = false;
            squareCheckBox.IsChecked = false;
            triangleCheckBox.IsChecked = false;
            rectangleCheckBox.IsChecked = false;
            pentagonCheckBox.IsChecked = false;
            hexagonCheckBox.IsChecked = false;
        }

        private void triangleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            circleCheckBox.IsChecked = false;
            squareCheckBox.IsChecked = false;
            lineCheckBox.IsChecked = false;
            rectangleCheckBox.IsChecked = false;
            pentagonCheckBox.IsChecked = false;
            hexagonCheckBox.IsChecked = false;
        }

        private void squareCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            circleCheckBox.IsChecked = false;
            lineCheckBox.IsChecked = false;
            triangleCheckBox.IsChecked = false;
            rectangleCheckBox.IsChecked = false;
            pentagonCheckBox.IsChecked = false;
            hexagonCheckBox.IsChecked = false;
        }

        private void rectangleCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            circleCheckBox.IsChecked = false;
            squareCheckBox.IsChecked = false;
            triangleCheckBox.IsChecked = false;
            lineCheckBox.IsChecked = false;
            pentagonCheckBox.IsChecked = false;
            hexagonCheckBox.IsChecked = false;
        }

        private void pentagonCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            circleCheckBox.IsChecked = false;
            squareCheckBox.IsChecked = false;
            triangleCheckBox.IsChecked = false;
            rectangleCheckBox.IsChecked = false;
            lineCheckBox.IsChecked = false;
            hexagonCheckBox.IsChecked = false;
        }

        private void hexagonCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            circleCheckBox.IsChecked = false;
            squareCheckBox.IsChecked = false;
            triangleCheckBox.IsChecked = false;
            rectangleCheckBox.IsChecked = false;
            pentagonCheckBox.IsChecked = false;
            lineCheckBox.IsChecked = false;
        }
    }
}
