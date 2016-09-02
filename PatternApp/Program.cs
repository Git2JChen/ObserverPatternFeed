using System;
using Observer;

namespace PatternApp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));
            var ibm = new IBM("International Bussness Machine", 12);
            ibm.AttachInvestor(new Investor("Broker1"));
            ibm.AttachInvestor(new Investor("Broker2"));

            ibm.Price = 20;
            ibm.Price = 100;
            ibm.Price = 100;

            Console.ReadKey();
        }
    }
}
