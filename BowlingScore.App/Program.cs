
using BowlingScoreboard;
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
			game.RollBall(1);
			game.RollBall(4);
			game.RollBall(4);
			game.RollBall(5);
			game.RollBall(6);
			game.RollBall(4);
			game.RollBall(5);
			game.RollBall(5);
			game.RollBall(10);
			game.RollBall(0);
			game.RollBall(1);
			game.RollBall(7);
			game.RollBall(3);
			game.RollBall(6);
			game.RollBall(4);
			game.RollBall(10);
			game.RollBall(2);
			game.RollBall(8);
			game.RollBall(6);




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
			Console.ReadLine();
		}
	}
}
