namespace Draw_Ellipse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.WindowState = FormWindowState.Maximized;
        }

        int Scale = 2;

        int YRadius = 50;
        int XRadius = 70;

        int Angle = 0;

        private double DtoR(double degrees) //DegreesToRadians
        {
            return (Math.PI / 180) * degrees;
        }
        private double OppositeSide_Lenght(int degree, double hypotenuseLength)
        {
            return (hypotenuseLength * Math.Sin(DtoR(degree)));
        }
        private double AdjacentSide_Lenght(double Opposite, double Hypotenus)
        {
            return (Math.Sqrt(Math.Pow(Hypotenus, 2) - Math.Pow(Opposite, 2)));
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics l = e.Graphics;
            Pen p = new Pen(Color.Blue, 5);

            YRadius *= Scale;
            XRadius *= Scale;

            int Quadrant = 1;

            int CentrePointX = 200 * Scale;
            int CentrePointY = 150 * Scale;

            int PlotX = 0;
            int PlotY = 0;

            int PrevX = 0;
            int PrevY = 0;

            //Big Triangle bottom left (OMN)
            double Hypotenuse_Len_1;
            double Opposite_Len_1;
            double Adjacent_Len_1;

            //Small Triangle top right (MRP)
            double Hypotenuse_Len_2;
            double Opposite_Len_2;
            double Adjacent_Len_2;


            Hypotenuse_Len_1 = YRadius;
            Hypotenuse_Len_2 = XRadius;
            Opposite_Len_1 = OppositeSide_Lenght(Angle, Hypotenuse_Len_1);
            Opposite_Len_2 = OppositeSide_Lenght(Angle, Hypotenuse_Len_2);
            Adjacent_Len_1 = AdjacentSide_Lenght(Opposite_Len_1, Hypotenuse_Len_1);
            Adjacent_Len_2 = AdjacentSide_Lenght(Opposite_Len_2, Hypotenuse_Len_2);


            for (int i = 0; i <= 360; i++)
            {
                //System.Threading.Thread.Sleep(100);

                Angle = i;

                if (Angle >= 0 && Angle <= 90) { Quadrant = 1; }
                if (Angle > 90 && Angle <= 180) { Quadrant = 2; }
                if (Angle > 180 && Angle <= 270) { Quadrant = 3; }
                if (Angle > 270 && Angle <= 360) { Quadrant = 4; }


                Hypotenuse_Len_1 = YRadius;
                Hypotenuse_Len_2 = XRadius;
                Opposite_Len_1 = OppositeSide_Lenght(Angle, Hypotenuse_Len_1);
                Opposite_Len_2 = OppositeSide_Lenght(Angle, Hypotenuse_Len_2);
                Adjacent_Len_1 = AdjacentSide_Lenght(Opposite_Len_1, Hypotenuse_Len_1);
                Adjacent_Len_2 = AdjacentSide_Lenght(Opposite_Len_2, Hypotenuse_Len_2);


                if (Quadrant == 1)
                {
                    PlotX = CentrePointX + ((int)Adjacent_Len_1 + (int)Adjacent_Len_2);
                    PlotY = CentrePointY - (int)Opposite_Len_1;
                }
                if (Quadrant == 2)
                {
                    PlotX = CentrePointX - ((int)Adjacent_Len_1 + (int)Adjacent_Len_2);
                    PlotY = CentrePointY - (int)Opposite_Len_1;
                }
                if (Quadrant == 3)
                {
                    PlotX = CentrePointX - ((int)Adjacent_Len_1 + (int)Adjacent_Len_2);
                    PlotY = CentrePointY + Math.Abs((int)Opposite_Len_1);
                }
                if (Quadrant == 4)
                {
                    PlotX = CentrePointX + ((int)Adjacent_Len_1 + (int)Adjacent_Len_2);
                    PlotY = CentrePointY - (int)Opposite_Len_1;
                }

                if (i >= 1)
                {
                    l.DrawLine(p, PrevX, PrevY, PlotX, PlotY);

                    //Debug.WriteLine("Angle: "+Angle+", Quandrant: "+Quadrant+",    "+ PrevX + ", " + PrevY + "  " + PlotX + ", " + PlotY);
                }

                PrevX = PlotX;
                PrevY = PlotY;

            }

            l.Dispose();

            PlotX = 0;
            PlotY = 0;

            PrevX = 0;
            PrevY = 0;
        }
    }
}