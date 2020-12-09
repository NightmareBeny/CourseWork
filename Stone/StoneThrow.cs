using static System.Math;

namespace StoneThrow
{
    public class Stone
    {
        public double Speed { get; set; }
        public double Time { get; set; }
        private double Y { get; set; }

        //true-камень упал, false-камень не упал
        public bool IsFall()
        {
            Y = Time * Speed - (9.81 * Pow(Time, 2)) / 2;
            if (Y < 0) return true;
            else return false;
        }
        public double Distance()
        {
            return Round(Speed * Time - (9.81 * Pow(Time, 2)) / 2, 3);
        }
        private double Distance(double time)
        {
            return Round(Speed * time - (9.81 * Pow(time, 2)) / 2, 3);
        }
        public double WhatsTime()
        {
            for (double i = 0; i <= Time; i += 0.1)
            {
                if (Distance(i) < 0)
                {
                    return i;
                }
            }
            return Time;
        }
    }
    public class StoneToHorizont
    {
        public double Angle { get; set; }
        public double Speed { get; set; }
        public double Time { get; set; }
        private double Y { get; set; }
        public double Distance(bool F1)
        {
            if (Angle > 90) Angle = 180 - Angle;
            //Если камень, который кинули под углом к горизонту упал
            if (Y < 0)
            {
                Stone stone = new Stone();
                stone.Time = Time; stone.Speed = Speed;
                if (F1)
                {
                    return Speed * Cos(PI * Angle / 180) * stone.WhatsTime();
                }
                else
                {
                    return Sqrt(Pow(stone.Distance(), 2) + Pow(Speed * Cos(PI * Angle / 180) * stone.Time, 2));
                }
            }
            //Если он не упал
            else return Round(Speed * Time * Sqrt(2 * (1 - Sin(PI * Angle / 180))), 3);
        }
        //true-камень упал, false-камень не упал
        public bool IsFall()
        {
            Y = Time * Speed * Sin(PI * Angle / 180) - (9.81 * Pow(Time, 2)) / 2;
            if (Y < 0) return true;
            else return false;
        }
    }

}
