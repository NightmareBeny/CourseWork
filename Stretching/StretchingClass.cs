using static System.Math;

namespace Stretching
{
    public class StretchingClass
    {
        public double Diametre { get; set; }
        public double Distance { get; set; }
        public double Mass { get; set; }

        public StretchingClass(double d, double s, double m)
        {
            Diametre = d * 0.001;
            Distance = s; Mass = m;
        }

        public double Stretch()
        {
            return Round((Distance * Pow((Mass * 9.81) / (2 * PI * Pow(Diametre, 2) * 2 * Pow(10, 11)), 1 / 3f)) * 100, 2);
        }
    }
}
