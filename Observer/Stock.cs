using System.Collections.Generic;

namespace ConsoleApplication1
{
    public abstract class Stock 
    {
        private double _price;
        private readonly string _symbol;
        private readonly List<IInvestor> _investors = new List<IInvestor>();

        public Stock(string symbol, double price)
        {
            _symbol = symbol;
            _price = price;
        }

        public void AttachInvestor(IInvestor investor)
        {
            _investors.Add(investor);
        }

        public void Notify()
        {
            foreach (var investor in _investors)
            {
                investor.Update(_symbol, _price);
            }
        }

        public double Price
        {
            set
            {
                if (_price != value)
                {
                    _price = value;
                    Notify();
                }
            }
            get { return _price; }
        }

        public string Symbol
        {
            get { return _symbol; }
        }
    }
}