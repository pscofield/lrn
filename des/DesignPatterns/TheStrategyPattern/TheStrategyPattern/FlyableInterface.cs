using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheStrategyPattern
{
    interface IFlyableInterface
    {
        void FlyAction();
    }

    class NoFly : IFlyableInterface
    {
        public void FlyAction()
        {
            Console.WriteLine("--- No fly.");
        }
    }

    class NaturalFly : IFlyableInterface
    {
        public void FlyAction()
        {
            Console.WriteLine("--- Natural flying.");
        }
    }

    class JetPoweredFly : IFlyableInterface
    {
        private void ActualJetPoweredFunction()
        {
            Console.WriteLine("--- Jet powered flying.");
        }
        public void FlyAction()
        {
            ActualJetPoweredFunction();
        }
    }
}
