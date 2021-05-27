namespace SOLID
{
    public class WithdrawCheckingAccount : WithdrawSolution
    {
        public override string Withdraw(decimal value, string account)
        {
            // Do something

            return GetTransactionNumber();
        }
    }
}
