namespace DesignPatterns.Composite
{
    public interface IMessage
    {
        string Name { get; set; }

        void ShowMessages(int hyphens);
    }
}
