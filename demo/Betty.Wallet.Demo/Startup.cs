using Betty.Wallet.Services.Enums;
using Betty.Wallet.Services.Common;
using Betty.Wallet.Services.Interfaces;
using Betty.Wallet.Services.Models;

namespace Betty.Wallet.Demo
{
	public class Startup
	{
		private IGameService gameService;
		public Startup(IGameService gameService)
		{
			this.gameService = gameService;
		}

		public void Start() 
		{
			var player = new Player() { Account = new Account() };
			
			bool isPlaying = true;
			while (isPlaying)
			{
				Console.WriteLine("Please submit action:");
				string actionString = Console.ReadLine();

				try
				{
					var tokens = actionString.Split(" ");

					var name = tokens[0];
					decimal amount = 0;

					switch (name)
					{
						case "deposit":
							if (tokens.Length < 2)
							{
								throw new Exception("Invalid action");
							}

							if (!decimal.TryParse(tokens[1], out amount))
							{
								throw new Exception("Invalid amount");
							}

							player.Account.Deposit(amount);
							Console.WriteLine($"Your deposit of ${amount} was successful.Your current balance is ${player.Account.Balance}");

							break;
						case "withdraw":
							if (tokens.Length < 2)
							{
								throw new Exception("Invalid action");
							}

							if (!decimal.TryParse(tokens[1], out amount))
							{
								throw new Exception("Invalid amount");
							}

							player.Account.Withdraw(amount);
							Console.WriteLine($"Your withdrawal of ${amount} was successful. Your current balance is ${player.Account.Balance}");

							break;
						case "bet":
							if (tokens.Length < 2)
							{
								throw new Exception("Invalid action");
							}

							if (!decimal.TryParse(tokens[1], out amount))
							{
								throw new Exception("Invalid amount");
							}

							if (amount > player.Account.Balance) 
							{
								throw new Exception("Insufficient funds");
							}

							GameResult gameResult = this.gameService.PlaceBet(amount);
							player.Account.SetAmount(player.Account.Balance - amount + gameResult.Profit);
							if (gameResult.ResultStatus == GameResultStatuses.Win)
							{
								Console.WriteLine($"Congrats - you won ${gameResult.Profit}!. Your current balance is: ${player.Account.Balance}");
							}
							else if (gameResult.ResultStatus == GameResultStatuses.Lose)
							{

								Console.WriteLine($"No luck this time! Your current balance is: ${player.Account.Balance}");
							}

							break;
						case "exit":
							Console.WriteLine($"Thank you for a playing! Hope to see you again soon.");
							isPlaying = false;
							break;

						default:
							throw new Exception($"Invalid command.");
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}		
		}
	}
}
