using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw_Circle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        int Scale = 2;

        int CircleRadius;
        int Angle;

        private double RtoD(double radians) //RadianToDegree
        {
            double degrees = (180 / Math.PI) * radians;
            return degrees;
        }
        private double DtoR(double degrees) //DegreesToRadians
        {
            double radians = (Math.PI / 180) * degrees;
            return radians;
        }

        private int OppositeSide_Lenght(int degree, int hypotenuseLength)
        {
            double SideLenght = hypotenuseLength * Math.Sin(DtoR(degree));
            return (int)Math.Round(SideLenght, MidpointRounding.AwayFromZero);
        }
        private int AdjacentSide_Lenght(int Opposite, int Hypotenus)
        {
            double Adjacent = Math.Sqrt(Math.Pow(Hypotenus, 2) - Math.Pow(Opposite, 2));
            return (int)Math.Round(Adjacent, MidpointRounding.AwayFromZero);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics l = e.Graphics;
            Pen p = new Pen(Color.Blue, 5);


            CircleRadius = 80 * Scale;

            int Quadrant = 1;

            int CentrePointX = 100 * Scale;
            int CentrePointY = 100 * Scale;

            int PlotX = 0;
            int PlotY = 0;

            int PrevX = 0;
            int PrevY = 0;

            int Hypotenuse_Len = CircleRadius;
            int Opposite_Len = OppositeSide_Lenght(Angle, Hypotenuse_Len);
            int Adjacent_Len = AdjacentSide_Lenght(Opposite_Len, Hypotenuse_Len);


            for (int i = 0; i <= 360; i++)
            {
                Angle = i;

                if (Angle >= 0 && Angle <= 90) { Quadrant = 1; }
                if (Angle > 90 && Angle <= 180) { Quadrant = 2; }
                if (Angle > 180 && Angle <= 270) { Quadrant = 3; }
                if (Angle > 270 && Angle <= 360) { Quadrant = 4; }

                Hypotenuse_Len = CircleRadius;
                Opposite_Len = OppositeSide_Lenght(i, Hypotenuse_Len);
                Adjacent_Len = AdjacentSide_Lenght(Opposite_Len, Hypotenuse_Len);

                if (Quadrant == 1)
                {
                    PlotX = CentrePointX + Adjacent_Len;
                    PlotY = CentrePointY - Opposite_Len;
                }
                if (Quadrant == 2)
                {
                    PlotX = CentrePointX - Adjacent_Len;
                    PlotY = CentrePointY - Opposite_Len;
                }
                if (Quadrant == 3)
                {
                    PlotX = CentrePointX - Adjacent_Len;
                    PlotY = CentrePointY + Math.Abs(Opposite_Len);
                }
                if (Quadrant == 4)
                {
                    PlotX = CentrePointX + Adjacent_Len;
                    PlotY = CentrePointY - Opposite_Len;
                }

                if (i >= 1)
                {
                    l.DrawLine(p, PrevX, PrevY, PlotX, PlotY);
                }

                PrevX = PlotX;
                PrevY = PlotY;   
            }
            l.Dispose();
        }
    }
}
