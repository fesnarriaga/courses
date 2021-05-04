namespace SOLID
{
    public static class WithdrawSavingsExtension
    {
        public static string WithdrawSavingsAccount(this WithdrawExtension withdrawExtension)
        {
            // Do something

            return withdrawExtension.GetTransactionNumber();
        }
    }
}
