namespace DesignPatterns.ObservablePattern
{
    // Observer
    public interface IObserver
    {
        string Name { get; }

        void Notify(Investment investment);
    }
}
