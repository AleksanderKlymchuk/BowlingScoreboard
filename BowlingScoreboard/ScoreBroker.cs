using BowlingScoreboard.Commands;
using BowlingScoreboard.Queries;
using System;
using System.Collections.Generic;


namespace BowlingScoreboard
{
	public class ScoreBroker
	{
		public List<Frame> Frames { get; } = new List<Frame>();
		public event EventHandler<Command> Commands;
		public event EventHandler<Query> Queries;

		public void Command(Command command)
		{
			Commands?.Invoke(this, command);
		}

		public T Query<T>(Query query)
		{
			Queries?.Invoke(this, query);
			return (T)query.Result;
		}
	}


}
