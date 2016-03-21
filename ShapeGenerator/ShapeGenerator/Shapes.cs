using System;
using System.Drawing;

namespace ShapeGenerator
{
    class Hexagon : Polygon
    {
        public Hexagon(ImageWriter writer)
            : base(writer)
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
                x = RandomNum.Next(450, 480);
                x2 = RandomNum.Next(500, 523);
                x3 = RandomNum.Next(280, 300);
                x4 = RandomNum.Next(330, 360);
                y = RandomNum.Next(160, 180);
                y2 = RandomNum.Next(230, 260);
                y3 = RandomNum.Next(310, 350);

            } while ((y2 - y != 80) && (y3 - y2 != 80) && (x2 - x != 60) && (x4 - x3 != 60));

            this.Vertices = new PointF[] { new PointF(x, y), new PointF(x2, y2), new PointF(x, y3), new PointF(x4, y3), new PointF(x3, y2), new PointF(x4, y) };
        }
    }
    class Pentagon : Polygon
    {
        public Pentagon(ImageWriter writer)
            :base(writer)
        {
            int y = RandomNum.Next(483, 600);
            int y2 = RandomNum.Next(350, 400);
            int y3 = RandomNum.Next(370, 590);
            int y4 = RandomNum.Next(270, 300);

            this.Vertices = new PointF[] { new PointF(413, y), new PointF(370, y2), new PointF(480, y4), new PointF(590, y2), new PointF(550, y) };
        }
    }
    class Rectangle : Polygon
    {
        public Rectangle(ImageWriter writer)
            : base(writer)
        {
            int randomNumberx;
            int randomNumber2x;
            int randomNumber2y;
            int randomNumbery;

            do
            {
                randomNumberx = RandomNum.Next(350, 900);
                randomNumber2x = RandomNum.Next(400, 700);
                randomNumbery = RandomNum.Next(100, 300);
                randomNumber2y = RandomNum.Next(100, 300);
            } while (randomNumber2x - randomNumberx == randomNumber2y - randomNumbery);

            this.Vertices = new PointF[] { new PointF(randomNumberx, randomNumbery), new PointF(randomNumberx, randomNumber2y), new PointF(randomNumber2x, randomNumber2y), new PointF(randomNumber2x, randomNumbery) };
        }
    }

    class Square : Polygon
    {
        public Square(ImageWriter writer)
            : base(writer)
        {
            int randomNumberx;
            int randomNumber2x;
            int randomNumber2y;
            int randomNumbery;

            do
            {
                randomNumberx = RandomNum.Next(350, 900);
                randomNumber2x = RandomNum.Next(400, 700);
                randomNumbery = RandomNum.Next(100, 300);
                randomNumber2y = RandomNum.Next(100, 300);
            } while (randomNumber2x - randomNumberx != randomNumber2y - randomNumbery);

            this.Vertices = new PointF[] { new PointF(randomNumberx, randomNumbery), new PointF(randomNumberx, randomNumber2y), new PointF(randomNumber2x, randomNumber2y), new PointF(randomNumber2x, randomNumbery) };
        }
    }
    class Triangle : Polygon
    {
        public Triangle(ImageWriter writer)
            : base(writer)
        {
            int x = RandomNum.Next(150, 500);
            int x1 = RandomNum.Next(150, 600);
            int y = RandomNum.Next(500, 680);
            int y1 = RandomNum.Next(440, 580);

            this.Vertices = new PointF[] { new PointF(x, y), new PointF(x1, y1), new PointF(x, y1) };
        }
    }
    class Line : Polygon
    {
        public Line(ImageWriter writer)
            : base(writer)
        {
            int x = RandomNum.Next(300, 600);
            int x1 = RandomNum.Next(300, 600);
            int y = RandomNum.Next(600, 700);
            int y1 = RandomNum.Next(600, 700);

            this.Vertices = new PointF[] { new PointF(x, y), new PointF(x1, y1) };
        }
    }
    abstract class Polygon : Shape
    {
        public PointF[] Vertices { get; set; }
        public Polygon(ImageWriter writer)
            : base(writer)
        {


        }

        public override void Draw()
        {
            using (var bmp = new Bitmap(3000, 3000))
            using (var gr = Graphics.FromImage(bmp))
            {
                gr.RotateTransform(RandomNum.Next(0, 20));
                Pen pen = new Pen(Brushes.Black);
                //Note - we could use gr.DrawRectangle() to render a rectangle!
                gr.DrawPolygon(pen, this.Vertices);

                var fileName = $"{this.Name}.png";

                this.ImageWriter.WriteImage(fileName, bmp);
            }
        }
    }

    class Circle: Shape
    {
        public Circle(ImageWriter writer)
            : base(writer)
        {
            this.WidthAndHeight = RandomNum.Next(1, 400);
        }

        public int WidthAndHeight { get; private set; }

        public override void Draw()
        {
            using (var bmp = new Bitmap(3000, 3000))
            {
                using (var gr = Graphics.FromImage(bmp))
                {
                    gr.RotateTransform(RandomNum.Next(0, 20));
                    Pen pen = new Pen(Brushes.Black);
                    gr.DrawEllipse(pen, new RectangleF(RandomNum.Next(100, 600), RandomNum.Next(150, 650), WidthAndHeight, WidthAndHeight));

                    var fileName = $"{this.Name}.png";

                    this.ImageWriter.WriteImage(fileName, bmp);
                }
            }
        }
    }
    abstract class Shape
    {
        public Random RandomNum = new Random();

        public string Name { get; set; }
        public ImageWriter ImageWriter { get; private set; }

        public Shape(ImageWriter writer)
        {
            this.ImageWriter = writer;
            this.Name = $"{this.GetType().Name}-{Guid.NewGuid()}";
        }

        public abstract void Draw();
    }
}
