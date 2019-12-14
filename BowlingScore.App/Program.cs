
using BowlingScoreboard;
using BowlingScoreboard.Commands;
using BowlingScoreboard.Queries;
using ConsoleTables;
using System;

namespace BowlingScore.App
{
	class Program
	{
		static void Main(string[] args)
		{
			var broker = new ScoreBroker();
			var game = new BowlingGame(broker);
			broker.Command(new RollballCommand(game, 1));
			broker.Command(new RollballCommand(game, 4));
			broker.Command(new RollballCommand(game, 4));
			broker.Command(new RollballCommand(game, 5));
			broker.Command(new RollballCommand(game, 6));
			broker.Command(new RollballCommand(game, 4));
			broker.Command(new RollballCommand(game, 5));
			broker.Command(new RollballCommand(game, 5));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 1));
			broker.Command(new RollballCommand(game, 7));
			broker.Command(new RollballCommand(game, 3));
			broker.Command(new RollballCommand(game, 6));
			broker.Command(new RollballCommand(game, 4));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 2));
			broker.Command(new RollballCommand(game, 8));
			broker.Command(new RollballCommand(game, 6));
		

			var table = new ConsoleTable("FrameNumber", "RollNumber", "KnockedDownPins", "TotalScore", "Note");
			foreach (var frame in broker.Frames)
			{

				table.AddRow(frame.Number, 1, frame.Roll1.KnockedDownPins, "", frame.StrikeNote);

				if (frame.Number == 10)
				{
					table.AddRow(frame.Number, 2, frame.Roll2?.KnockedDownPins, "", frame.SpareNote);
					table.AddRow(frame.Number, 3, frame.Roll3?.KnockedDownPins, frame.TotalScore, "");
				}
				else
				{
					table.AddRow(frame.Number, 2, frame.Roll2?.KnockedDownPins, frame.TotalScore, frame.SpareNote);
				}

			}
			table.Write();
			var f = broker.Query<Frame>(new FrameQuery() { Target = game });
			Console.WriteLine($"The total score is:{f.TotalScore}");
			Console.ReadLine();
		}
	}
}
