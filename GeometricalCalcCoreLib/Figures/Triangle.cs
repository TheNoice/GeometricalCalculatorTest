using GeometricalCalcCoreLib.Figures.Abstractions;
using GeometricalCalcCoreLib.Utils;
using System;

namespace GeometricalCalcCoreLib.Figures
{
    internal class Triangle : Figure2D
    {
        public double Leg_AB { get; internal set; }
        public double Leg_BC { get; internal set; }
        public double? Hypotenuse_AC { get; internal set; }
        public double? Angle_b { get; internal set; }

        public Triangle()
        {
            Requirements.Add(nameof(Leg_AB), $"{Leg_AB.GetType().Name}. {BasicRequirements}");
            Requirements.Add(nameof(Leg_BC), $"{Leg_BC.GetType().Name}. {BasicRequirements}");
            Requirements.Add($"{nameof(Hypotenuse_AC)} or {nameof(Angle_b)}" , $"Double. {BasicRequirements}");
        }

        public override double GetSquare()
        {
            if (Hypotenuse_AC > 0)
                return GetSquareByThreeSides();
            else if (Angle_b == 90.0)
                return GetSquareByLegsAndAngleBetween();
            else
                throw new GeometricalCalculationException("Not enough parameters to count figure square.");
        }

        private double GetSquareByThreeSides()
        {
            if (Angle_b == 90.0)
                return (GetP() - Leg_AB) * (GetP() - Leg_BC);
            else
                return Math.Sqrt(GetP() * (GetP() - Leg_AB) * (GetP() - Leg_BC) * (GetP() - Hypotenuse_AC!.Value));

            double GetP()
            {
                return (Leg_AB + Leg_BC + Hypotenuse_AC!.Value) / 2.0;
            }
        }

        private double GetSquareByLegsAndAngleBetween()
        {
            return Leg_AB * Leg_BC / 2;
        }

        public override string ToString()
        {
            if (Angle_b == 90.0)
                return "Right-Angled Triangle";
            else
                return "Triangle";
        }
    }
}
