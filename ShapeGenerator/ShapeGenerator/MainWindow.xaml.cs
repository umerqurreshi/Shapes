using System;

using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        PointF[] p = new PointF[0];
        string name = String.Empty;
        int numberOfFiles = 0;
        int fileNumber = 1;

        private void button_Click(object sender, RoutedEventArgs e)
        {
            p = new PointF[0];
            int result = 0;

            if(int.TryParse(txtNumberOfFiles.Text, out result))
            {
                numberOfFiles = result;
            }

            for (fileNumber = 1; fileNumber <= numberOfFiles; fileNumber++)
            {
                if (circleCheckBox.IsChecked.Value)
                {
                    Canvas canvas = new Canvas();
                    Ellipse ellipse = new Ellipse();
                    canvas.Height = 200;
                    canvas.Width = 200;
                    ellipse.Height = randomNum.Next(1, 400);
                    ellipse.Width = ellipse.Height;
                    ellipse.Stroke = System.Windows.Media.Brushes.Black;
                    grid.Children.Add(ellipse);
                    name = "Circle";
                    int widthAndHeight = randomNum.Next(1, 400);
                    using (var bmp = new Bitmap(3000, 3000))
                    using (var gr = Graphics.FromImage(bmp))
                    {
                        gr.RotateTransform(randomNum.Next(0, 20));
                        System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Brushes.Black);
                        gr.DrawEllipse(pen, new RectangleF(randomNum.Next(100, 600), randomNum.Next(150, 650), widthAndHeight, widthAndHeight));

                        var path = System.IO.Path.Combine(
                            System.IO.Path.GetTempPath(),
                            String.Format($"{name}-{fileNumber}.png"));

                        bmp.Save(path);
                    }
                }
                // Ideally have a failsafe here, however we will always check a checkbox!
                else
                {
                    Draw();
                }
            }
            

        }

        private void Draw()
        {
            Polygon myPolygon = new Polygon();
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;
            myPolygon.StrokeThickness = 2;
            PointCollection myPointCollection = new PointCollection();

            if (lineCheckBox.IsChecked.Value)
            {
                myPointCollection.Clear();
                int x = randomNum.Next(300, 600);
                int x1 = randomNum.Next(300, 600);
                int y = randomNum.Next(600, 700);
                int y1 = randomNum.Next(600, 700); 

                myPointCollection.Add(new System.Windows.Point(x, y));
                myPointCollection.Add(new System.Windows.Point(x1, y1));
                p = new PointF[] { new PointF(x, y), new PointF (x1,y1) };
                name = "Line";
            }
            if (triangleCheckBox.IsChecked.Value)
            {
                int x = randomNum.Next(150, 500);
                int x1 = randomNum.Next(150, 600);
                int y = randomNum.Next(500, 680);
                int y1 = randomNum.Next(440, 580);

                myPointCollection.Clear();
                myPointCollection.Add(new System.Windows.Point(x, y));
                myPointCollection.Add(new System.Windows.Point(x1, y1));
                myPointCollection.Add(new System.Windows.Point(x, y1));
                p = new PointF[] { new PointF(x, y), new PointF(x1, y1), new PointF(x, y1) };
                name = "Triangle";
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

                myPointCollection.Add(new System.Windows.Point(randomNumberx, randomNumbery));
                myPointCollection.Add(new System.Windows.Point(randomNumberx, randomNumber2y));
                myPointCollection.Add(new System.Windows.Point(randomNumber2x, randomNumber2y));
                myPointCollection.Add(new System.Windows.Point(randomNumber2x, randomNumbery));
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

                myPointCollection.Add(new System.Windows.Point(randomNumberx, randomNumbery));
                myPointCollection.Add(new System.Windows.Point(randomNumberx, randomNumber2y));
                myPointCollection.Add(new System.Windows.Point(randomNumber2x, randomNumber2y));
                myPointCollection.Add(new System.Windows.Point(randomNumber2x, randomNumbery));
            }

            if (pentagonCheckBox.IsChecked.Value)
            {
                myPointCollection.Clear();
                int y = randomNum.Next(483, 600);
                int y2 = randomNum.Next(350, 400);
                int y3 = randomNum.Next(370, 590);
                int y4 = randomNum.Next(270, 300);

                myPointCollection.Add(new System.Windows.Point(413, y));
                myPointCollection.Add(new System.Windows.Point(370, y2));
                myPointCollection.Add(new System.Windows.Point(480, y4));
                myPointCollection.Add(new System.Windows.Point(590, y2));
                myPointCollection.Add(new System.Windows.Point(550, y));
            }

            if (hexagonCheckBox.IsChecked.Value)
            {
                myPointCollection.Clear();
                int x;
                int x2;
                int x3;
                int x4;
                int y;
                int y2;
                int y3;

                do
                {
                    x = randomNum.Next(450, 480);
                    x2 = randomNum.Next(500, 523);
                    x3 = randomNum.Next(280, 300);
                    x4 = randomNum.Next(330, 360);
                    y = randomNum.Next(160, 180);
                    y2 = randomNum.Next(230, 260);
                    y3 = randomNum.Next(310, 350);
                   
                } while ((y2 - y != 80) && (y3 - y2 != 80) && (x2 - x != 60) && (x4 - x3 != 60));
         

                myPointCollection.Add(new System.Windows.Point(x, y));
                myPointCollection.Add(new System.Windows.Point(x2, y2));
                myPointCollection.Add(new System.Windows.Point(x, y3));
                myPointCollection.Add(new System.Windows.Point(x4, y3));
                myPointCollection.Add(new System.Windows.Point(x3, y2));
                myPointCollection.Add(new System.Windows.Point(x4, y));
            }

            RotateTransform rotateTransform = new RotateTransform(randomNum.Next(0, 90), 0, 0);
            myPolygon.Points = myPointCollection;
            myPolygon.RenderTransform = rotateTransform;
            rotateTransform.Angle = randomNum.Next(0, 90);
            rotateTransform.CenterX = 400;
            rotateTransform.CenterY = 200;
            grid.Children.Add(myPolygon);

            using (var bmp = new Bitmap(3000, 3000))
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.RotateTransform(randomNum.Next(0, 20));
                System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Brushes.Black);
                gr.DrawPolygon(pen, p);

                var path = System.IO.Path.Combine(
                    System.IO.Path.GetTempPath(),
                    String.Format($"{name}-{fileNumber}.png"));

                bmp.Save(path);
            }
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
