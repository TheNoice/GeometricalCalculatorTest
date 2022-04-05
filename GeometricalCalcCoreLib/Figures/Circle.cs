using GeometricalCalcCoreLib.Figures.Abstractions;
using System;

namespace GeometricalCalcCoreLib.Figures
{
    internal class Circle : Figure2D
    {

        public double Radius { get; internal set; }

        public Circle()
        {
            Requirements.Add(nameof(Radius), $"{Radius.GetType().Name}. {BasicRequirements}");
        }

        public override double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override string ToString()
        {
            return "Circle";
        }
    }
}
