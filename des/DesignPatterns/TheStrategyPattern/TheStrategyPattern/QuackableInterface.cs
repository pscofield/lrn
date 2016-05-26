using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStrategyPattern
{
    /// <summary>
    /// This interface needs to be implemented by all quacking behaviors.
    /// </summary>
    interface IQuackableInterface
    {
        /// <summary>
        /// Makes the sound.
        /// </summary>
        /// <param name="numberOfTimes">Number of times the duck makes the sound.</param>
        void MakeSound(int numberOfTimes);
    }

    /// <summary>
    /// This class makes no quack sound.
    /// </summary>
    class NoQuackSound : IQuackableInterface
    {
        void FnNoQuackSound (int numberOfTimes)
        {
            Console.WriteLine(">>> No sound.");
        }
        public void MakeSound(int numberOfTimes)
        {
            FnNoQuackSound(numberOfTimes);
        }
    }

    class SqueakSound : IQuackableInterface
    {
        /// <summary>
        /// This private function actually makes the squeak sound. To conform with the example on page 12.
        /// </summary>
        /// <param name="numberOfTimes"></param>
        void FnSqueakSound(int numberOfTimes)
        {
            Console.WriteLine(">>> Squeak.");
        }
        /// <summary>
        /// This function exists to implement the members of the parent interface.
        /// </summary>
        /// <param name="numberOfTimes"></param>
        public void MakeSound(int numberOfTimes)
        {
            FnSqueakSound(numberOfTimes);
        }
    }

    class QuackSound : IQuackableInterface
    {
        void FnQuackSound(int numberOfTimes)
        {
            Console.WriteLine(">>> Quack.");
        }
        public void MakeSound(int numberOfTimes)
        {
            FnQuackSound(numberOfTimes);
        }
    }
}
