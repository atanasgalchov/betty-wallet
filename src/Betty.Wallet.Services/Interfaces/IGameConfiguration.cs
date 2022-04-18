namespace Betty.Wallet.Services.Interfaces
{
	public interface IGameConfiguration
	{
		int MinBet { get; set; }
		int MaxBet { get; set; }
		int RandomMultiplyBetChancePercent { get; set; }
		int DoubleBetChancePercent { get; set; }
		int RandomBetMinMultiplier { get; set; }
		int RandomBetMaxMultiplier { get; set; }
	}
}
