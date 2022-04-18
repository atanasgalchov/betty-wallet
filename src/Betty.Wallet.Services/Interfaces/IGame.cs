using Betty.Wallet.Services.Common;
using Betty.Wallet.Services.Games;

namespace Betty.Wallet.Services.Interfaces
{
	public interface IGame
	{
		GameResult PlaceBet(decimal amount);
	}
}
