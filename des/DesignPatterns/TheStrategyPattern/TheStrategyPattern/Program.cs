using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStrategyPattern
{
    /// <summary>
    /// The 'main' class of the program.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The entry point to the program.
        /// </summary>
        /// <param name="args">Input cmdline parameters.</param>
        static void Main(string[] args)
        {
            // Create ducks of different types.
            var mallardDuck = new MallardDuck();
            var rubberDuck = new RubberDuck();
            var jetPoweredWoodenDuck = new JetPoweredWoodenDuck();

            // Output their flying characteristics.
            mallardDuck.DuckFly();
            rubberDuck.DuckFly();
            jetPoweredWoodenDuck.DuckFly();

            // Output their quacking characteristics.
            mallardDuck.DuckQuack(1);
            rubberDuck.DuckQuack(1);
            jetPoweredWoodenDuck.DuckQuack(1);

            // Update the characteristics at runtime.
            rubberDuck.DuckFly();
            rubberDuck.SetFlyBehavior(new JetPoweredFly());
            rubberDuck.DuckFly();

            Console.Read();
        }
    }
}
