namespace Observer
{
    public interface IInvestor
    {
        void Update(string stockSymbol, double price);
    }
}