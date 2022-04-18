namespace Betty.Wallet.Services.Models
{
	public class Account
	{
		public decimal Balance { get; private set; }

		public void Deposit(decimal amaount)
		{
			if (amaount < 0)
				throw new Exception("Amount must be positive number!");

			Balance += amaount;
		}

		public void Withdraw(decimal amaount)
		{
			if (Balance < amaount)
				throw new Exception("Insufficient founds");

			Balance -= amaount;
		}

		public void SetAmount(decimal amaount)
		{
			if (amaount < 0)
				throw new Exception("Amount must be positive number!");

			Balance = amaount;
		}
	}
}
