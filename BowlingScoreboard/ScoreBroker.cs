using BowlingScoreboard.Commands;
using System;
using System.Collections.Generic;


namespace BowlingScoreboard
{
	public class ScoreBroker
	{
		public readonly List<Frame> Frames = new List<Frame>();
		public event EventHandler<Command> Commands;
		public event EventHandler<Query> Queries;
		
		public void Command(Command command)
		{
			Commands?.Invoke(this,command);
		}
	}

	
}
