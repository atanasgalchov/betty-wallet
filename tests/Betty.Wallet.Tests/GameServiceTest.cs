using Betty.Wallet.Services.Common;
using Betty.Wallet.Services.Games;
using Betty.Wallet.Services.Interfaces;
using Betty.Wallet.Services.Services;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace Betty.Wallet.Services.Tests
{
	public class GameServiceTest
	{
		[Fact]
		public void PlaceBet_ShouldReturnsResultInLessThan20ms()
		{
			// Arrange          
			IGameConfiguration config = new GameConfiguration()
			{
				MinBet = 1,
				MaxBet = 1000,
				DoubleBetChancePercent = 40,
				RandomMultiplyBetChancePercent = 10,
				RandomBetMinMultiplier = 2,
				RandomBetMaxMultiplier = 10,
			};
			IGameService gameService = new GameService(new SimpleSlotGame(config));
			Stopwatch stopwatch = Stopwatch.StartNew();

			// Act
			gameService.PlaceBet(100);

			// Assert
			Assert.True(stopwatch.ElapsedMilliseconds < 20);
		}


		[Fact]
		public void PlaceBet_ShouldReturnsOnlyLosseResult_WhenWinChanceIs0()
		{
			// Arrange          
			IGameConfiguration config = new GameConfiguration()
			{
				MinBet = 1,
				MaxBet = 1000,
				DoubleBetChancePercent = 0,
				RandomMultiplyBetChancePercent = 0,
				RandomBetMinMultiplier = 2,
				RandomBetMaxMultiplier = 10,
			};
			IGameService gameService = new GameService(new SimpleSlotGame(config));
			bool allLosse = true;
			
			// Act
			for (int i = 1; i < 100; i++)
			{
				GameResult gameResult = gameService.PlaceBet(100);
				if (gameResult.ResultStatus == Enums.GameResultStatuses.Win) 
				{
					allLosse = false;
				}
			}

			// Assert
			Assert.True(allLosse);
		}

		[Fact]
		public void PlaceBet_ShouldReturnsOnlyWinResult_WhenLoseChanceIs0()
		{
			// Arrange          
			IGameConfiguration config = new GameConfiguration()
			{
				MinBet = 1,
				MaxBet = 1000,
				DoubleBetChancePercent = 50,
				RandomMultiplyBetChancePercent = 50,
				RandomBetMinMultiplier = 2,
				RandomBetMaxMultiplier = 10,
			};
			IGameService gameService = new GameService(new SimpleSlotGame(config));
			bool allWin = true;

			// Act
			for (int i = 1; i < 100; i++)
			{
				GameResult gameResult = gameService.PlaceBet(100);
				if (gameResult.ResultStatus == Enums.GameResultStatuses.Lose)
				{
					allWin = false;
				}
			}

			// Assert
			Assert.True(allWin);
		}
	}
}