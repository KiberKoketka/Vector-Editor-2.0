using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinFormGamVector2D
{
    public class Figure
    {

    }
    public class Point
    {
        public int X;
        public int Y;
    }
    public class Line : Figure
    {
        public Point Point1;
        public Point Point2;
        public int Thickness;
        public Color Color;
        public override string ToString()
        {
            return $"<line x1=\"{Point1.X}\" y1=\"{Point1.Y}\" x2=\"{Point2.X}\" y2=\"{Point2.Y}\" stroke=\"rgb({Color.R}, {Color.G}, {Color.B})\" stroke-width=\"{Thickness}\"  />";
        }
    }
    public class Rectagle : Figure
    {
        public Point Point;
        public int H;
        public int W;
        public double Rotate;
        public int Thickness;
        public Color ColorLine;
        public Color ColorFill;
        public override string ToString()
        {
            return $"<rect x =\"{Point.X - W / 2.0}\" y=\"{Point.Y - H / 2.0}\" width=\"{W}\" height=\"{H}\" fill=\"rgb({ColorFill.R}, {ColorFill.G}, {ColorFill.B})\" stroke=\"rgb({ColorLine.R}, {ColorLine.G}, {ColorLine.B})\" stroke-width=\"{Thickness}\"  />";
            //return $"<rect transform=\"rotate({Rotate})\" x =\"{Point.X}\" y=\"{Point.Y}\" width=\"{W}\" height=\"{H}\" fill=\"rgb({ColorFill.R}, {ColorFill.G}, {ColorFill.B})\" stroke=\"rgb({ColorLine.R}, {ColorLine.G}, {ColorLine.B})\" stroke-width=\"{Thickness}\"  />";
        }
    }
    public class Ellipse : Figure
    {
        public Point Point;
        public int Rx;
        public int Ry; 
        public double Rotate;
        public int Thickness;
        public Color ColorLine;
        public Color ColorFill;
        public override string ToString()
        {
            return $"<ellipse cx=\"{Point.X}\" cy=\"{Point.Y}\" rx=\"{Rx}\" ry=\"{Ry}\" fill=\"rgb({ColorFill.R}, {ColorFill.G}, {ColorFill.B})\" stroke=\"rgb({ColorLine.R}, {ColorLine.G}, {ColorLine.B})\" stroke-width=\"{Thickness}\"  />";
            //return $"<ellipse transform=\"rotate({Rotate} {Point.X} {Point.Y})\" cx=\"{Point.X}\" cy=\"{Point.Y}\" rx=\"{Rx}\" ry=\"{Ry}\" fill=\"rgb({ColorFill.R}, {ColorFill.G}, {ColorFill.B})\" stroke=\"rgb({ColorLine.R}, {ColorLine.G}, {ColorLine.B})\" stroke-width=\"{Thickness}\"  />";
        }
    }
    public class SvgImage
    {
        public List<Figure> Figures = new List<Figure>();
        public override string ToString()
        {
            string svg = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>\r\n <svg xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\" height = \"640px\"  width = \"640px\">\r\n";
            foreach (Figure f in Figures)
                svg += "\t" + f.ToString() + "\r\n";
            svg += "</svg>";
            return svg;
        }
    }
}
