using GeometricalCalcCoreLib.Enums;
using GeometricalCalcCoreLib.ExtraServices;
using GeometricalCalcCoreLib.Figures.Abstractions;
using GeometricalCalculator.Helpers.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace GeometricalCalculator.Services
{
    internal class BasicFigureInfoCollector
    {
        public Figure2D CollectInfoViaConsole(IMessageHelper messageHelper)
        {
            bool infoCollected = false;
            short figureTypeId = 1;

            do
            {
                Console.WriteLine("Avaliable figure type (Name - ID):");
                foreach (var figureType in Enum.GetValues(typeof(AvaliableFiguresEnum)).Cast<AvaliableFiguresEnum>())
                {
                    Console.WriteLine($"{figureType} - {(short)figureType}");
                }

                Console.WriteLine();
                Console.WriteLine("Enter figure type Id:");
                var input = Console.ReadLine().Trim().ToLower();

                if (input == messageHelper.StopString)
                    Environment.Exit(10);

                if (Int16.TryParse(input, out figureTypeId))
                    infoCollected = true;

            } while (!infoCollected);

            FigureInitializingService figureInitializingService = new();
            Figure2D figure = figureInitializingService.Initialize2DFigure((AvaliableFiguresEnum)figureTypeId);

            infoCollected = false;

            do
            {
                Console.WriteLine(figure.ShowRequirements());

                foreach (var propertyInfo in figure.GetType()
                                .GetProperties(
                                        BindingFlags.Public
                                        | BindingFlags.Instance))
                {
                    bool propertyIsSet = false;
                    do
                    {
                        Console.WriteLine($"Enter value for {propertyInfo.Name}:");
                        var input = Console.ReadLine().Trim().ToLower();

                        if (input == messageHelper.StopString)
                            Environment.Exit(10);

                        if (Double.TryParse(input, out double value)) //Double, т.к. все значения в фигурах данного типа
                        {
                            
                            propertyIsSet = figureInitializingService.SetFigurePropertyValue(ref figure, propertyInfo, value);
                        }
                    } while (!propertyIsSet);
                }
                infoCollected = true;
            } while (!infoCollected);

            return figure;
        }
    }
}
