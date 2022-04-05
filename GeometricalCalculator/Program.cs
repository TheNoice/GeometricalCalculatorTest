using GeometricalCalculator.Helpers;
using GeometricalCalculator.Helpers.Interfaces;

namespace GeometricalCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();

            IMessageHelper messageHelper = new BasicMessageHelper();

            app.Run(messageHelper);
        }
    }
}
