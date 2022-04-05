using GeometricalCalculator.Helpers.Interfaces;
using System;
using System.Reflection;

namespace GeometricalCalculator.Helpers
{
    internal class BasicMessageHelper : IMessageHelper
    {
        public string WelcomeMessage => $"Welcome to Console Geometrical Calculator v. {Assembly.GetExecutingAssembly().GetName().Version}!";

        public string StopString => "stop";

        public void DisplayWelcomeMessage()
        {
            Console.WriteLine(WelcomeMessage);
        }
    }
}
