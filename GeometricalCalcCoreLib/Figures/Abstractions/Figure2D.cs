using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeometricalCalcCoreLib.Figures.Abstractions
{
    public abstract class Figure2D
    {
        protected const string BasicRequirements = "More than zero.";
        protected Dictionary<string, string> Requirements { get; } = new Dictionary<string, string>();
        public abstract double GetSquare();
        public string ShowRequirements()
        {
            if (!Requirements.Any())
                return String.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append("List of requirements:\n");

            foreach (var requirement in Requirements)
            {
                sb.Append($"Property: {requirement.Key} - {requirement.Value}\n");
            }
            return sb.ToString();
        }
    }
}
