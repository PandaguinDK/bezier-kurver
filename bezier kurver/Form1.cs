using System;
using System.Drawing;
using System.Windows.Forms;

namespace bezier_kurver
{
    public partial class Form1 : Form
    {
        private Point[] controlPoints = new Point[4];
        private const int numPoints = 100;
        private Point[] curvePoints = new Point[numPoints];

        public Form1()
        {
            InitializeComponent();
            InitializeControlPoints();
            CalculateBezierCurve();
        }

        private void InitializeControlPoints()
        {
            // Laver kontrol punkterne
            controlPoints[0] = new Point(130, 150);
            controlPoints[1] = new Point(100, 50);
            controlPoints[2] = new Point(100, 300);
            controlPoints[3] = new Point(250, 150);
        }

        private void CalculateBezierCurve()
        {
            // Beregner bezier kurve punkterne
            for (int i = 0; i < numPoints; i++)
            {
                double t = (double)i / (numPoints - 1);
                int x = (int)CalculateBezierCoordinate(controlPoints[0].X, controlPoints[1].X, controlPoints[2].X, controlPoints[3].X, t);
                int y = (int)CalculateBezierCoordinate(controlPoints[0].Y, controlPoints[1].Y, controlPoints[2].Y, controlPoints[3].Y, t);
                curvePoints[i] = new Point(x, y);
            }
        }

        private double CalculateBezierCoordinate(double p0, double p1, double p2, double p3, double t)
        {
            return Math.Pow(1 - t, 3) * p0 + 3 * Math.Pow(1 - t, 2) * t * p1 + 3 * (1 - t) * Math.Pow(t, 2) * p2 + Math.Pow(t, 3) * p3;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Tegner bezier kurven
            Pen pen = new Pen(Color.Blue);
            g.DrawLines(pen, curvePoints);

            // Tegn kontrol punkterne
            foreach (Point point in controlPoints)
            {
                g.FillRectangle(Brushes.Red, point.X - 3, point.Y - 3, 6, 6);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
