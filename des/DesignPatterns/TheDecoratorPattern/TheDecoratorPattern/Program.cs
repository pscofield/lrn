using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDecoratorPattern
{
    static class Program
    {
        internal static void Main(string[] args)
        {
            // Instantiate a computer.
            Computer myComputer = new DellInspironModel();

            // Add the features.
            myComputer = new UsbMouseAccessory(myComputer);
            myComputer = new UsbKeyboardAccessory(myComputer);
            myComputer = new ExternalHddAccessory(myComputer);
            myComputer = new DvdDriveAccessory(myComputer);
            myComputer = new GraphicsCardAccessory(myComputer);

            // Output the results.
            Console.WriteLine("The description for my computer is: {0}.", myComputer.GetDescription());
            Console.WriteLine("The cost for my computer is: {0}.", myComputer.GetCost());

        }
    }

    internal abstract class Computer
    {
        internal string Description = "Unknown computer";
        /// <summary>
        /// Calculates the cost of the assembled computer. Access modifier: protected.
        /// </summary>
        /// <returns>Cost of the computer assembled.</returns>
        internal abstract double GetCost();

        internal virtual string GetDescription()
        {
            return Description;
        }
    }

    internal abstract class ComputerAccessory : Computer
    {
        internal Computer BaseComputer;

        internal override abstract string GetDescription();
    }

    internal static class ConstantCosts
    {
        // Define the cost of the base models.
        internal const double DellStudio = 500;
        internal const double DellInspiron = 400;

        // Define the cost of the accessories.
        internal const double UsbMouse = 10;
        internal const double UsbKeyboard = 15;
        internal const double GraphicsCard = 200;
        internal const double ExternalHdd = 50;
        internal const double DvdDrive = 30;
    }
}
