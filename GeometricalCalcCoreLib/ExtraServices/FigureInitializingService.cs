using GeometricalCalcCoreLib.Enums;
using GeometricalCalcCoreLib.Figures;
using GeometricalCalcCoreLib.Figures.Abstractions;
using GeometricalCalcCoreLib.Utils;
using System.Reflection;

namespace GeometricalCalcCoreLib.ExtraServices
{
    public class FigureInitializingService
    {
        public Figure2D Initialize2DFigure(AvaliableFiguresEnum figureType)
        {
            switch (figureType)
            {
                case AvaliableFiguresEnum.Circle:
                    return new Circle();
                case AvaliableFiguresEnum.Triangle:
                    return new Triangle();
                default:
                    throw new FigureCreationException("Unknown Figure Type ID. Cannot create a 2D figure.");
            }
        }

        public bool SetFigurePropertyValue(ref Figure2D figure, PropertyInfo propertyInfo, double value)
        {
            if (value > 0.0)
            {
                propertyInfo.SetValue(figure, value);
                return true;
            }
            else
                return false;
        }
    }
}
