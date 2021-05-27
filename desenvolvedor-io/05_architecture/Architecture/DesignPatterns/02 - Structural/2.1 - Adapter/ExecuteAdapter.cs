namespace DesignPatterns.Adapter
{
    public class ExecuteAdapter
    {
        public static void Execute()
        {
            var targetLog = new TransactionService(new Logger());
            targetLog.ExecuteTransaction();

            var adapteeLog = new TransactionService(new LogAdapter(new LogNetMasterService()));
            adapteeLog.ExecuteTransaction();
        }
    }
}
