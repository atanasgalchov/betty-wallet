using Betty.Wallet.Services.Interfaces;

namespace Betty.Wallet.Services.Common
{
	public class GameConfiguration : IGameConfiguration
	{
		public int MinBet { get; set; }
		public int MaxBet { get; set; }
		public int RandomMultiplyBetChancePercent { get; set; }
		public int DoubleBetChancePercent { get; set; }
		public int RandomBetMinMultiplier { get; set; }
		public int RandomBetMaxMultiplier { get; set; }
	}
}
