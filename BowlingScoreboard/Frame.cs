using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingScoreboard
{
	public class Frame
	{
		public int Number { get; }
		public Roll Roll1 { get; private set; }
		public Roll Roll2 { get; private set; }
		public Roll Roll3 { get; private set; }
		public Roll LastRoll => Roll3 ?? Roll2 ?? Roll1;
		public int TotalScore { get;private set; }
		public bool Strike => (Roll1?.KnockedDownPins == 10);
		public bool Spare => Roll1?.KnockedDownPins + Roll2?.KnockedDownPins == 10;
		public string StrikeNote => Strike ? "Strike":"";
		public string SpareNote => Spare ? "Spare":"";

		public Frame(int number)
		{
			Number = number;
		}
		public bool IsClosed()
		{
			if (Number != 10)
			{
				return (LastRoll.Equals(Roll2) || Strike || Spare);
			}
			if (Number == 10 && (LastRoll.Equals(Roll3) || (LastRoll.Equals(Roll2) && (!Strike && !Spare))))
			{
				return true;
			}
			return false;
		}
		public void UpdateTotalScore(int score)
		{
			TotalScore = score;
		}
		public void SetRoll(int knockedDownPins)
		{
			if (Roll1 == null)
			{
				Roll1 = new Roll(knockedDownPins);
			}
			else if (LastRoll.Equals(Roll1))
			{
				Roll2 = new Roll(knockedDownPins);
			}
			else if (LastRoll.Equals(Roll2) && !IsClosed())
			{
				Roll3 = new Roll(knockedDownPins);
			}
		}
	}
	public class Roll
	{
		Guid Id { get; } = Guid.NewGuid();
		public int KnockedDownPins { get; }
		public Roll(int knockedDownPins)
		{
			KnockedDownPins = knockedDownPins;
		}
		
	}
}
