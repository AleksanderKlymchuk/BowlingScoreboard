using BowlingScoreboard;
using BowlingScoreboard.Commands;
using FluentAssertions;
using NUnit.Framework;


namespace BowlingSoreboardTest
{
	public class BowlingGameTest
	{
		[Test]
		public void GameTest()
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

			broker.Frames[0].TotalScore.Should().Be(5);
			broker.Frames[1].TotalScore.Should().Be(14);
			broker.Frames[2].TotalScore.Should().Be(29);
			broker.Frames[3].TotalScore.Should().Be(49);
			broker.Frames[4].TotalScore.Should().Be(60);
			broker.Frames[5].TotalScore.Should().Be(61);
			broker.Frames[6].TotalScore.Should().Be(77);
			broker.Frames[7].TotalScore.Should().Be(97);
			broker.Frames[8].TotalScore.Should().Be(117);
			broker.Frames[9].TotalScore.Should().Be(133);

		}
		[Test]
		public void GutterGameTest()
		{
			var broker = new ScoreBroker();
			var game = new BowlingGame(broker);
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));
			broker.Command(new RollballCommand(game, 0));

			broker.Frames[9].TotalScore.Should().Be(0);
		}
		[Test]
		public void PerfectGameTest()
		{
			var broker = new ScoreBroker();
			var game = new BowlingGame(broker);
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));
			broker.Command(new RollballCommand(game, 10));

			broker.Frames[9].TotalScore.Should().Be(300);
		}
		[Test]
		public void IsClosedTest()
		{
			var frame = new Frame(1);
			frame.SetRoll(2);
			frame.IsClosed().Should().BeFalse();
		}
	}
}