using GeometricalCalculator.Helpers.Interfaces;
using GeometricalCalculator.Services;
using System;
using System.Reflection;

namespace GeometricalCalculator
{
    internal class Application
    {
        public void Run(IMessageHelper messageHelper)
        {
            messageHelper.DisplayWelcomeMessage();

            bool isRunning = true;
            while (isRunning)
            {
                try
                {
                    BasicFigureInfoCollector infoCollector = new();
                    var figure = infoCollector.CollectInfoViaConsole(messageHelper);

                    Console.WriteLine();
                    Console.WriteLine($"Got figure: {figure}.");

                    foreach (var propertyInfo in figure.GetType()
                                .GetProperties(
                                        BindingFlags.Public
                                        | BindingFlags.Instance))
                    {
                        Console.WriteLine($"{propertyInfo.Name} - {propertyInfo.GetValue(figure)?.ToString()}" );
                    }
                    Console.WriteLine($"Square - {figure.GetSquare()}");


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine($"\nCreate another figure or type in \"{messageHelper.StopString}\" to exit the program.\n");
            }
        }
    }
}
