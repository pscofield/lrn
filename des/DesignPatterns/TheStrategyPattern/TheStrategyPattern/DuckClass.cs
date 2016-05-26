using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStrategyPattern
{
    class DuckClass
    {
        /// <summary>
        /// Constructor to the base duck class. Maybe it shouldn't be initialized to the standard duck.
        /// </summary>
        protected DuckClass()
        {
            // Default to the normal duck behavior.
            FlyBehavior = new NaturalFly();
            QuackBehavior = new QuackSound();
        }

        /// <summary>
        /// Denotes the flying behavior of the duck. Programmed to an interface/supertype. Not to an implementation.
        /// </summary>
        protected IFlyableInterface FlyBehavior = null;

        protected IQuackableInterface QuackBehavior = null;

        /// <summary>
        /// Generic fly action method for the duck.
        /// </summary>
        public void DuckFly()
        {
            FlyBehavior.FlyAction();
        }

        public void DuckQuack(int numberOfTimes)
        {
            QuackBehavior.MakeSound(numberOfTimes);
        }

        public void DuckSwim()
        {
            Console.WriteLine("Swimming.");
        }

        public void DuckDisplay()
        {
            Console.WriteLine("Duck being displayed.");
        }

        public void SetFlyBehavior(IFlyableInterface newBehavior)
        {
            FlyBehavior = newBehavior;
        }

        public void SetQuackBehavior(IQuackableInterface newBehavior)
        {
            QuackBehavior = newBehavior;
        }
    }

    /// <summary>
    /// Rubber duck extends the base duck class. It does not fly but squeaks.
    /// </summary>
    class RubberDuck : DuckClass
    {
        public RubberDuck()
        {
            FlyBehavior = new NoFly();
            QuackBehavior = new SqueakSound();
        }
    }

    class JetPoweredWoodenDuck : DuckClass
    {
        public JetPoweredWoodenDuck()
        {
            FlyBehavior = new JetPoweredFly();
            QuackBehavior = new NoQuackSound();
        }
    }

    class MallardDuck : DuckClass
    {
        public MallardDuck()
        {
            FlyBehavior = new NaturalFly();
            QuackBehavior = new QuackSound();
        }
    }
}
