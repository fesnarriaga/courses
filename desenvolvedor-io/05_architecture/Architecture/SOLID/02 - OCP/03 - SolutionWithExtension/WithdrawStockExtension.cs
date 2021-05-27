namespace SOLID
{
    public static class WithdrawStockExtension
    {
        public static string WithdrawStockAccount(this WithdrawExtension withdrawExtension)
        {
            // Do something

            return withdrawExtension.GetTransactionNumber();
        }
    }
}
