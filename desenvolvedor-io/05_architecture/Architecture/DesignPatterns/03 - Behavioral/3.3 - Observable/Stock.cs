namespace DesignPatterns.ObservablePattern
{
    // Concrete Subject
    public class Stock : Investment
    {
        public Stock(string symbol, decimal price) : base(symbol, price) { }
    }
}
