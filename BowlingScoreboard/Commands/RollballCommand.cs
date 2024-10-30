namespace BowlingScoreboard.Commands
{
	public class RollballCommand : Command
	{
		public BowlingGame Target { get; }
		public int KnockedDownPins { get; }
		public RollballCommand(BowlingGame target, int knockedDownPins)
		{
			Target = target;
			KnockedDownPins = knockedDownPins;
		}
	}
}
