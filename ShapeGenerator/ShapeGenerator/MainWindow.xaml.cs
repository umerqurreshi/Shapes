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

        private enum Shapes
        {
            Circle = 1,
            Hexagon = 2,
            Line = 3,
            Pentagon = 4,
            Rectangle = 5,
            Square = 6,
            Triangle = 7
        }

        Random randomNum = new Random();
        PointF[] vertices = new PointF[0];
        string name = String.Empty;
        int numberOfFiles = 0;
        int fileNumber = 1;

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (!circleCheckBox.IsChecked.Value && !lineCheckBox.IsChecked.Value && !triangleCheckBox.IsChecked.Value && !squareCheckBox.IsChecked.Value && !rectangleCheckBox.IsChecked.Value && !pentagonCheckBox.IsChecked.Value && !hexagonCheckBox.IsChecked.Value)
            {
                MessageBox.Show("Please select a value");
            }

            vertices = new PointF[0];
            int result = 0;

            if (int.TryParse(txtNumberOfFiles.Text, out result))
            {
                numberOfFiles = result;
            }

            for (fileNumber = 1; fileNumber <= numberOfFiles; fileNumber++)
            {
                await CircleCheckboxChecked();
            }
        }

        private async Task CircleCheckboxChecked()
        {
            if (circleCheckBox.IsChecked.Value)
            {
                name = Shapes.Circle.ToString();
                int widthAndHeight = randomNum.Next(1, 400);

                using (var bmp = new Bitmap(3000, 3000))
                {
                    using (var gr = Graphics.FromImage(bmp))
                    {
                        gr.RotateTransform(randomNum.Next(0, 20));
                        System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Brushes.Black);
                        gr.DrawEllipse(pen, new RectangleF(randomNum.Next(100, 600), randomNum.Next(150, 650), widthAndHeight, widthAndHeight));

                        var path = System.IO.Path.Combine(
                            System.IO.Path.GetTempPath(),
                            String.Format($"{name}-{fileNumber}.png"));

                        await Task.Run(() => bmp.Save(path));

                        // Keeping the user updated of file saving progress
                        lblNumberOfFiles.Foreground = System.Windows.Media.Brushes.Green;
                        lblNumberOfFiles.Content = fileNumber == numberOfFiles ? String.Format($"All {numberOfFiles} files saved") : String.Format($"{fileNumber} files saved");
                    }
                }
            }
            // Ideally have a failsafe here, however we will always check a checkbox!
            else
            {
                await Draw();

                // Keeping the user updated of file saving progress
                lblNumberOfFiles.Foreground = System.Windows.Media.Brushes.Green;
                lblNumberOfFiles.Content = fileNumber == numberOfFiles ? String.Format($"All {numberOfFiles} files saved") : String.Format($"{fileNumber} files saved");
            }
        }

        private async Task Draw()
        {
            LineCheckboxChecked();
            TriangleCheckboxChecked();
            SquareCheckboxChecked();
            RectangleCheckboxChecked();
            PentagonCheckboxChecked();
            HexagonCheckboxChecked();
            await DrawImage();
        }

        private async Task DrawImage()
        {
            using (var bmp = new Bitmap(3000, 3000))
            {
                using (var gr = Graphics.FromImage(bmp))
                {
                    gr.RotateTransform(randomNum.Next(0, 20));
                    System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Brushes.Black);
                    //Note - we could use gr.DrawRectangle() to render a rectangle!
                    gr.DrawPolygon(pen, vertices);

                    var path = System.IO.Path.Combine(
                        System.IO.Path.GetTempPath(),
                        String.Format($"{name}-{fileNumber}.png"));

                    await Task.Run(() => bmp.Save(path));
                }
            }
        }

        private void HexagonCheckboxChecked()
        {
            if (hexagonCheckBox.IsChecked.Value)
            {
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

                vertices = new PointF[] { new PointF(x, y), new PointF(x2, y2), new PointF(x, y3), new PointF(x4, y3), new PointF(x3, y2), new PointF(x4, y) };
                name = Shapes.Hexagon.ToString();
            }
        }

        private void PentagonCheckboxChecked()
        {
            if (pentagonCheckBox.IsChecked.Value)
            {
                int y = randomNum.Next(483, 600);
                int y2 = randomNum.Next(350, 400);
                int y3 = randomNum.Next(370, 590);
                int y4 = randomNum.Next(270, 300);

                vertices = new PointF[] { new PointF(413, y), new PointF(370, y2), new PointF(480, y4), new PointF(590, y2), new PointF(550, y) };
                name = Shapes.Pentagon.ToString();
            }
        }

        private void RectangleCheckboxChecked()
        {
            if (rectangleCheckBox.IsChecked.Value)
            {
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

                vertices = new PointF[] { new PointF(randomNumberx, randomNumbery), new PointF(randomNumberx, randomNumber2y), new PointF(randomNumber2x, randomNumber2y), new PointF(randomNumber2x, randomNumbery) };
                name = Shapes.Rectangle.ToString();
            }
        }

        private void SquareCheckboxChecked()
        {
            if (squareCheckBox.IsChecked.Value)
            {
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

                vertices = new PointF[] { new PointF(randomNumberx, randomNumbery), new PointF(randomNumberx, randomNumber2y), new PointF(randomNumber2x, randomNumber2y), new PointF(randomNumber2x, randomNumbery) };
                name = Shapes.Square.ToString();
            }
        }

        private void TriangleCheckboxChecked()
        {
            if (triangleCheckBox.IsChecked.Value)
            {
                int x = randomNum.Next(150, 500);
                int x1 = randomNum.Next(150, 600);
                int y = randomNum.Next(500, 680);
                int y1 = randomNum.Next(440, 580);

                vertices = new PointF[] { new PointF(x, y), new PointF(x1, y1), new PointF(x, y1) };
                name = Shapes.Triangle.ToString();
            }
        }

        private void LineCheckboxChecked()
        {
            if (lineCheckBox.IsChecked.Value)
            {
                int x = randomNum.Next(300, 600);
                int x1 = randomNum.Next(300, 600);
                int y = randomNum.Next(600, 700);
                int y1 = randomNum.Next(600, 700);

                vertices = new PointF[] { new PointF(x, y), new PointF(x1, y1) };
                name = Shapes.Line.ToString();
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
