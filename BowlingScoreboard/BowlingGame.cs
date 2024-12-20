﻿using BowlingScoreboard.Commands;
using BowlingScoreboard.Queries;
using System;
using System.Linq;

namespace BowlingScoreboard
{
	public class BowlingGame
	{
		private readonly ScoreBroker _scoreBroker;
		private Frame CurrentFrame;
		private readonly int MaxFrameNumber = 10;
		public BowlingGame(ScoreBroker scoreBroker)
		{
			_scoreBroker = scoreBroker;

			_scoreBroker.Commands += ScoreBrokerOnCommands;
			_scoreBroker.Queries += ScoreBrokerOnQueries;
		}

		private void ScoreBrokerOnQueries(object sender, Query query)
		{
			if (sender != null && query is FrameQuery frame && frame.Target == this)
			{
				query.Result = CurrentFrame;
			}

		}

		private void ScoreBrokerOnCommands(object sender, Command e)
		{
			if (sender != null && e is RollballCommand rollballCommand && rollballCommand.Target == this)
			{
				RollBall(rollballCommand.KnockedDownPins);
			}

		}

		private void RollBall(int knockedDownPins)
		{
			if (GameComplete())
			{
				return;
			}
			int totalScore = (CurrentFrame?.TotalScore ?? 0) + knockedDownPins;
			if (CurrentFrame == null || CurrentFrame.IsClosed())
			{
				int number = (CurrentFrame?.Number ?? 0) + 1;
				CurrentFrame = new Frame(number);
			}
			CurrentFrame.SetRoll(knockedDownPins);
			CurrentFrame.UpdateTotalScore(totalScore);
			SetLastFrameBonus();
			ApplyFrame();
		}
		private bool GameComplete()
		{
			if (CurrentFrame != null && CurrentFrame.Number == MaxFrameNumber && CurrentFrame.IsClosed())
			{
				return true;
			}

			return false;
		}
		private void SetLastFrameBonus()
		{
			if (_scoreBroker.Frames.Count() == 0)
			{
				return;
			}
			if (CurrentFrame.Number == MaxFrameNumber && CurrentFrame.Roll3 != null)
			{
				return;
			}
			var last = _scoreBroker.Frames.Last();

			if (last.Strike && CurrentFrame.Strike && CurrentFrame.LastRoll == CurrentFrame.Roll1)
			{
				int extraScore = CurrentFrame.Number == MaxFrameNumber ? 10 : 20;
				last.UpdateTotalScore(last.TotalScore + 20);
				CurrentFrame.UpdateTotalScore(CurrentFrame.TotalScore + extraScore);
			}
			else if (last.Strike && CurrentFrame.LastRoll != CurrentFrame.Roll3 || (last.Spare && CurrentFrame.LastRoll != CurrentFrame.Roll2))
			{
				last.UpdateTotalScore(last.TotalScore + CurrentFrame.LastRoll.KnockedDownPins);
				CurrentFrame.UpdateTotalScore(CurrentFrame.TotalScore + CurrentFrame.LastRoll.KnockedDownPins);
			}

		}
		private void ApplyFrame()
		{
			if (CurrentFrame.IsClosed())
			{
				_scoreBroker.Frames.Add(CurrentFrame);
			}
		}
	}
}
