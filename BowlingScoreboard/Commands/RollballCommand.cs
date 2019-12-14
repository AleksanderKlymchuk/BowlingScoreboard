using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingScoreboard.Commands
{
	public class RollballCommand:Command
	{
		public BowlingGame Target;
		public int KnockedDownPins;
		public RollballCommand(BowlingGame target,int knockedDownPins)
		{
			Target = target;
			KnockedDownPins = knockedDownPins;
		}
	}
}
