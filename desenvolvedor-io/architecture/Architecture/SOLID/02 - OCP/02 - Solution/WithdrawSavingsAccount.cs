namespace SOLID
{
    public class WithdrawSavingsAccount : WithdrawSolution
    {
        public override string Withdraw(decimal value, string account)
        {
            // Do something

            return GetTransactionNumber();
        }
    }
}
