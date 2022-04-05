namespace GeometricalCalculator.Helpers.Interfaces
{
    internal interface IMessageHelper
    {
        string WelcomeMessage { get; }
        string StopString { get; }

        void DisplayWelcomeMessage();
    }
}
