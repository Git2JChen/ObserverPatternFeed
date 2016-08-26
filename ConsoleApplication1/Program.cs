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

        }
    }

    public interface IInvestor
    {
        void Update();
    }

    public abstract class Stock 
    {
        private double _price;
        private string _symbol;
        private List<IInvestor> _investors;

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
                investor.Update();
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

    

}
