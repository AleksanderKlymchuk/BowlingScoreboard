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
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			game.RallBall(0);
			broker.Frames[9].TotalScore.Should().Be(0);
		}
		[Test]
		public void PerfectGameTest()
		{
			var broker = new ScoreBroker();
			var game = new BowlingGame(broker);
			game.RallBall(10);
			game.RallBall(10);
			game.RallBall(10);
			game.RallBall(10);
			game.RallBall(10);
			game.RallBall(10);
			game.RallBall(10);
			game.RallBall(10);
			game.RallBall(10);
			game.RallBall(10);
			game.RallBall(10);
			game.RallBall(10);
			
			broker.Frames[9].TotalScore.Should().Be(300);
		}
	}
}