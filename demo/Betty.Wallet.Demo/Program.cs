using Betty.Wallet.Demo;
using Betty.Wallet.Services.Common;
using Betty.Wallet.Services.Games;
using Betty.Wallet.Services.Interfaces;
using Betty.Wallet.Services.Services;

IGameConfiguration config = new GameConfiguration() 
{
	MinBet = 1,
	MaxBet = 10,
	DoubleBetChancePercent = 40,
	RandomMultiplyBetChancePercent = 10,
	RandomBetMinMultiplier = 2,
	RandomBetMaxMultiplier = 10,
};

IGameService gameService = new GameService(new SimpleSlotGame(config));
Startup startup = new Startup(gameService);
startup.Start();
