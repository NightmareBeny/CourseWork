using static System.Math;

namespace Tension
{
    public class TensionClass
    {
        public double Force { get; private set; }
        public double Mass { get; private set; }
        public double Acceleration{ get; private set; }
        public TensionClass(double force, double mass)
        {
            Force = force; Mass = mass; Acceleration=force/mass;
        }
        public double T()
        {
            return Round(Force + Mass * 9.81, 3);
        }
    }
}
