using System;

namespace ConsoleApplication1
{
    public class Investor : IInvestor
    {
        private readonly string _name;
        public Investor(string name)
        {
            _name = name;
        }

        public void Update(string stockSymbol, double price)
        {
            Console.WriteLine("Notified {0} of {1}'s change to {2:C}", _name, stockSymbol, price);
        }
    }
}