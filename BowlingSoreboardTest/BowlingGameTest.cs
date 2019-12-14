using BowlingScoreboard;
using FluentAssertions;
using NUnit.Framework;


namespace BowlingSoreboardTest
{
	public class BowlingGameTest
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void GameTest()
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
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			game.RollBall(0);
			broker.Frames[9].TotalScore.Should().Be(0);
		}
		[Test]
		public void PerfectGameTest()
		{
			var broker = new ScoreBroker();
			var game = new BowlingGame(broker);
			game.RollBall(10);
			game.RollBall(10);
			game.RollBall(10);
			game.RollBall(10);
			game.RollBall(10);
			game.RollBall(10);
			game.RollBall(10);
			game.RollBall(10);
			game.RollBall(10);
			game.RollBall(10);
			game.RollBall(10);
			game.RollBall(10);
			
			broker.Frames[9].TotalScore.Should().Be(300);
		}
	}
}