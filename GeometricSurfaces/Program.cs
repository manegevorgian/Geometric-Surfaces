using System;
using System.Collections.Generic;

namespace GeometricSurfaces
{
    /// <summary>
    /// Geometric Figures Enum List
    /// </summary>
    enum GeometricFigures
    {
        Triangle,
        Square,
        Diagonal,
        Table,
        Ellipse,
        Circle,
        Rectangle,
        Parallelogram,
        Octagon
    }

    class Program
    {
        /// <summary>
        /// The Main method of the program
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the geometric figure:");
            string figure = Console.ReadLine();

            if (TryGetFigureParameters(figure, out string[] parameters))
            {
                Console.WriteLine($"To calculate the surface of a {figure}, you need the following parameters: {string.Join(", ", parameters)}");
                var paramValues = CollectParameters(figure, parameters);

                double surface = CalculateSurface(figure, paramValues);
                Console.WriteLine($"The surface area of the {figure} is {surface}");
            }
            else
            {
                Console.WriteLine("The input does not match any known geometric figure.");
            }

            Console.WriteLine("Press Enter to exit...");
            
            Console.ReadLine();
        }

        /// <summary>
        /// This method returns parameters used for calculating the surface of the figure.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static bool TryGetFigureParameters(string input, out string[] parameters)
        {
            if (Enum.TryParse(input, true, out GeometricFigures figure))
            {
                switch (figure)
                {
                    case GeometricFigures.Triangle:
                        parameters = new[] { "base", "height" };
                        break;
                    case GeometricFigures.Square:
                        parameters = new[] { "side length" };
                        break;
                    case GeometricFigures.Ellipse:
                        parameters = new[] { "major axis", "minor axis" };
                        break;
                    case GeometricFigures.Circle:
                        parameters = new[] { "radius" };
                        break;
                    case GeometricFigures.Rectangle:
                        parameters = new[] { "length", "width" };
                        break;
                    case GeometricFigures.Parallelogram:
                        parameters = new[] { "base", "height" };
                        break;
                    case GeometricFigures.Octagon:
                        parameters = new[] { "side length" };
                        break;
                    default:
                        parameters = new string[] { };
                        break;
                }
                return true;
            }

            parameters = null;
            return false;
        }

        /// <summary>
        /// This method collects the required parameters from the user.
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="parameters"></param>
        public static Dictionary<string, double> CollectParameters(string figure, string[] parameters)
        {
            Dictionary<string, double> paramValues = new Dictionary<string, double>();

            foreach (var param in parameters)
            {
                Console.WriteLine($"Please enter the {param}:");
                double value = double.Parse(Console.ReadLine());
                paramValues[param] = value;
            }

            Console.WriteLine($"You have entered the following parameters for {figure}:");
            foreach (var param in paramValues)
            {
                Console.WriteLine($"{param.Key}: {param.Value}");
            }

            return paramValues;
        }

        /// <summary>
        /// This method calculates the surface area based on the figure and it's parameters.
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="paramValues"></param>
        /// <returns></returns>
        public static double CalculateSurface(string figure, Dictionary<string, double> paramValues)
        {
            Enum.TryParse(figure, true, out GeometricFigures result);

            switch (result)
            {
                case GeometricFigures.Triangle:
                    return 0.5 * paramValues["base"] * paramValues["height"];
                case GeometricFigures.Square:
                    return Math.Pow(paramValues["side length"], 2);
                case GeometricFigures.Ellipse:
                    return Math.PI * paramValues["major axis"] * paramValues["minor axis"];
                case GeometricFigures.Circle:
                    return Math.PI * Math.Pow(paramValues["radius"], 2);
                case GeometricFigures.Rectangle:
                    return paramValues["length"] * paramValues["width"];
                case GeometricFigures.Parallelogram:
                    return paramValues["base"] * paramValues["height"];
                case GeometricFigures.Octagon:
                    double sideLength = paramValues["side length"];
                    return 2 * (1 + Math.Sqrt(2)) * Math.Pow(sideLength, 2);
                default:
                    throw new ArgumentException("Unknown geometric figure.");
            }
        }
    }
}