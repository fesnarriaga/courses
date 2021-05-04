namespace SOLID
{
    public static class WithdrawCheckingExtension
    {
        public static string WithdrawCheckingAccount(this WithdrawExtension withdrawExtension)
        {
            // Do something

            return withdrawExtension.GetTransactionNumber();
        }
    }
}
