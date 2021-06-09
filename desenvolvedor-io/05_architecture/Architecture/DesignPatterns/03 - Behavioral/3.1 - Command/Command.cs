namespace DesignPatterns.Command
{
    public abstract class Command
    {
        public abstract void Commit();
        public abstract void Rollback();
    }
}
