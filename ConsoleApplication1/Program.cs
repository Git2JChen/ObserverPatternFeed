using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ibm = new IBM("GBP", 12);
            ibm.AttachInvestor(new Investor("broker1"));
            ibm.AttachInvestor(new Investor("broker2"));

            ibm.Price = 20;
            ibm.Price = 100;
            ibm.Price = 100;

            Console.ReadKey();
        }
    }

    public abstract class Stock 
    {
        private double _price;
        private string _symbol;
        private List<IInvestor> _investors = new List<IInvestor>();

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
    
    public class IBM : Stock
    {
        public IBM(string symbol, double price) :base(symbol, price)
        {
        }
    }
    
    public interface IInvestor
    {
        void Update(string stockSymbol, double price);
    }

    public class Investor : IInvestor
    {
        private string _name;
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
