using static System.Math;

namespace Tension
{
    public class TensionClass
    {
        public double Force { get; set; }
        public double Mass { get; set; }

        public double T()
        {
            return Round(Force + Mass * 9.81, 3);
        }
    }
}
