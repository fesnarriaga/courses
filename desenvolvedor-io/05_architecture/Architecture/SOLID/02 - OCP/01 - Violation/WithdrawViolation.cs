namespace SOLID
{
    public class WithdrawViolation
    {
        public void Withdraw(decimal value, string account, AccountType accountType)
        {
            if (accountType == AccountType.Checking)
            {
                // Do something
            }

            if (accountType == AccountType.Saving)
            {
                // Do something
            }
        }
    }
}
