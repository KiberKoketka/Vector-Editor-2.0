using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormGamVector2D
{

    public partial class Form1 : Form
    {
        State state = new State();
        SvgImage svg = new SvgImage();
        Figure figure;
        Bitmap bmp;

        public Form1()
        {
            InitializeComponent();
            listBox1.SelectedIndex = 0;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < pictureBox1.Height; i++)
                for (int j = 0; j < pictureBox1.Width; j++)
                    bmp.SetPixel(j, i, Color.Transparent);

            pictureBox1.Image = bmp;
            state.Flag = StateFlag.DrawLine1;
        }
        public StateFlag SetState(int index)
        {
            switch (index)
            {
                case 0:
                    return StateFlag.DrawLine1;
                case 1:
                    return StateFlag.DrawEllipse1;
                case 2:
                    return StateFlag.DrawRectangle1;
                default:
                    return StateFlag.DrawLine1;
            }
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (state.Flag)
            {
                case StateFlag.DrawLine1:
                    figure = new Line();
                    ((Line)figure).Point1 = new Point() { X = e.X, Y = e.Y };
                    state.Flag = StateFlag.DrawLine2;
                    pictureBox1.CreateGraphics().DrawEllipse(new Pen(Color.Yellow, 3), new Rectangle(e.X, e.Y, 4, 4));
                    break;
                case StateFlag.DrawLine2:
                    Line l = (Line)figure;
                    l.Point2 = new Point() { X = e.X, Y = e.Y };
                    l.Thickness = (int)numericUpDown1.Value;
                    l.Color = colorDialog1.Color;
                    pictureBox1.CreateGraphics().DrawEllipse(new Pen(Color.Yellow, 3), new Rectangle(e.X, e.Y, 4, 4));
                    svg.Figures.Add(figure);
                    using (StreamWriter sw = new StreamWriter(Path.Combine(Application.StartupPath, "temp.svg"), false))
                        sw.Write(svg.ToString());
                    pictureBox1.Image = Svg.SvgDocument.Open(Path.Combine(Application.StartupPath, "temp.svg")).Draw();
                    state.Flag = SetState(listBox1.SelectedIndex);
                    break;
                case StateFlag.DrawEllipse1:
                    figure = new Ellipse();
                    ((Ellipse)figure).Point = new Point() { X = e.X, Y = e.Y };
                    pictureBox1.CreateGraphics().DrawEllipse(new Pen(Color.Yellow, 3), new Rectangle(e.X, e.Y, 4, 4));
                    state.Flag = StateFlag.DrawEllipse2;
                    break;
                case StateFlag.DrawEllipse2:
                    Ellipse el = (Ellipse)figure;
                    el.Rx = (int)Math.Round(Math.Sqrt(Math.Pow(e.X - el.Point.X, 2) + Math.Pow(e.Y - el.Point.Y, 2)));
                    el.Rotate = Math.Acos((e.Y - el.Point.Y) / (double)el.Rx) * 180 / Math.PI;
                    pictureBox1.CreateGraphics().DrawEllipse(new Pen(Color.Yellow, 3), new Rectangle(e.X, e.Y, 4, 4));
                    state.Flag = StateFlag.DrawEllipse3;
                    break;
                case StateFlag.DrawEllipse3:
                    Ellipse el1 = (Ellipse)figure;
                    el1.Ry = (int)Math.Round(Math.Sqrt(Math.Pow(e.X - el1.Point.X, 2) + Math.Pow(e.Y - el1.Point.Y, 2)));
                    el1.Thickness = (int)numericUpDown1.Value;
                    el1.ColorLine = colorDialog1.Color;
                    el1.ColorFill = colorDialog2.Color;
                    pictureBox1.CreateGraphics().DrawEllipse(new Pen(Color.Yellow, 3), new Rectangle(e.X, e.Y, 4, 4));
                    svg.Figures.Add(figure);
                    using (StreamWriter sw = new StreamWriter(Path.Combine(Application.StartupPath, "temp.svg"), false))
                        sw.Write(svg.ToString());
                    pictureBox1.Image = Svg.SvgDocument.Open(Path.Combine(Application.StartupPath, "temp.svg")).Draw();
                    state.Flag = SetState(listBox1.SelectedIndex);
                    break;
                case StateFlag.DrawRectangle1:
                    figure = new Rectagle();
                    ((Rectagle)figure).Point = new Point() { X = e.X, Y = e.Y };
                    pictureBox1.CreateGraphics().DrawEllipse(new Pen(Color.Yellow, 3), new Rectangle(e.X, e.Y, 4, 4));
                    state.Flag = StateFlag.DrawRectangle2;
                    break;
                case StateFlag.DrawRectangle2:
                    Rectagle r = (Rectagle)figure;
                    r.W = 2 * (int)Math.Round(Math.Sqrt(Math.Pow(e.X - r.Point.X, 2) + Math.Pow(e.Y - r.Point.Y, 2)));
                    r.Rotate = Math.Acos(2 * (e.Y - r.Point.Y) / (double)r.W) * 180 / Math.PI;
                    pictureBox1.CreateGraphics().DrawEllipse(new Pen(Color.Yellow, 3), new Rectangle(e.X, e.Y, 4, 4));
                    state.Flag = StateFlag.DrawRectangle3;
                    break;
                case StateFlag.DrawRectangle3:
                    Rectagle r1 = (Rectagle)figure;
                    r1.H = 2 * (int)Math.Round(Math.Sqrt(Math.Pow(e.X - r1.Point.X, 2) + Math.Pow(e.Y - r1.Point.Y, 2)));
                    r1.Thickness = (int)numericUpDown1.Value;
                    r1.ColorLine = colorDialog1.Color;
                    r1.ColorFill = colorDialog2.Color;
                    pictureBox1.CreateGraphics().DrawEllipse(new Pen(Color.Yellow, 3), new Rectangle(e.X, e.Y, 4, 4));
                    svg.Figures.Add(figure);
                    using (StreamWriter sw = new StreamWriter(Path.Combine(Application.StartupPath, "temp.svg"), false))
                        sw.Write(svg.ToString());
                    pictureBox1.Image = Svg.SvgDocument.Open(Path.Combine(Application.StartupPath, "temp.svg")).Draw();
                    state.Flag = SetState(listBox1.SelectedIndex);
                    break;
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            state.Flag = SetState(listBox1.SelectedIndex);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            button1.BackColor = colorDialog1.Color;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            colorDialog2.ShowDialog();
            button2.BackColor = colorDialog2.Color;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
