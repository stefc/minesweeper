using System;

namespace minesweeper.contracts
{
	public interface IDateProvider
	{
		DateTime Now { get; }
	}
}
