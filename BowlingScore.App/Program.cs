
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
			game.RallBall(1);
			game.RallBall(4);
			game.RallBall(4);
			game.RallBall(5);
			game.RallBall(6);
			game.RallBall(4);
			game.RallBall(5);
			game.RallBall(5);
			game.RallBall(10);
			game.RallBall(0);
			game.RallBall(1);
			game.RallBall(7);
			game.RallBall(3);
			game.RallBall(6);
			game.RallBall(4);
			game.RallBall(10);
			game.RallBall(2);
			game.RallBall(8);
			game.RallBall(6);




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
