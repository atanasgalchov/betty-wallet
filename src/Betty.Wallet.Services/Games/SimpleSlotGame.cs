using Betty.Wallet.Services.Common;
using Betty.Wallet.Services.Enums;
using Betty.Wallet.Services.Interfaces;

namespace Betty.Wallet.Services.Games
{
	public class SimpleSlotGame : IGame
	{
		private int minBet;
		private int maxBet;
		private int doubleBetChancePercent;
		private int randomMultiplyBetChancePercent;
		private int randomBetMinMultiplier;
		private int randomBetMaxMultiplier;

		public SimpleSlotGame(IGameConfiguration configuration)
		{

			if(configuration == null)
				throw new ArgumentNullException(nameof(configuration));

			minBet = configuration.MinBet;
			maxBet = configuration.MaxBet;			
			doubleBetChancePercent = configuration.DoubleBetChancePercent;
			randomMultiplyBetChancePercent = configuration.RandomMultiplyBetChancePercent;
			randomBetMaxMultiplier = configuration.RandomBetMaxMultiplier;
			randomBetMinMultiplier = configuration.RandomBetMinMultiplier;
		}

		public GameResult PlaceBet(decimal amount)
		{
			if(amount < minBet || amount > maxBet)
				throw new Exception($"The bet must be bigger than or equal {minBet} and less than or equal {maxBet}");

			var rand = new Random();
			int result = rand.Next(1,101);
			if (result <= randomMultiplyBetChancePercent)
			{
				int multiplier = rand.Next(randomBetMinMultiplier, randomBetMaxMultiplier + 1);
				return new GameResult { ResultStatus = GameResultStatuses.Win, Profit = amount * multiplier };
			}
			else if (result <= doubleBetChancePercent + randomMultiplyBetChancePercent)
			{
				return new GameResult { ResultStatus = GameResultStatuses.Win, Profit = amount * 2 };
			}
			else 
			{
				return new GameResult { ResultStatus = GameResultStatuses.Lose, Profit = 0 };
			}			
		}
	}
}
