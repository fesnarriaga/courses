namespace SOLID
{
    public class WithdrawStockAccount : WithdrawSolution
    {
        public override string Withdraw(decimal value, string account)
        {
            // Do something

            return GetTransactionNumber();
        }
    }
}
