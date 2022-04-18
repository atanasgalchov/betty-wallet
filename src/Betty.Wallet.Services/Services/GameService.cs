using Betty.Wallet.Services.Common;
using Betty.Wallet.Services.Interfaces;

namespace Betty.Wallet.Services.Services
{
	public class GameService : IGameService
	{
		private IGame game;
		public GameService(IGame game)
		{
			this.game = game;
		}
		public IGame Game => game;

		public GameResult PlaceBet(decimal amount)
		{
			return game.PlaceBet(amount);
		}
	}
}
