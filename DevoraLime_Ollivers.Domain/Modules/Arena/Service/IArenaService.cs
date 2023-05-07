using System;
using Domain.Modules.Hero;

namespace DevoraLime_Olivers.Domain.Modules.Arena
{
	public interface IArenaService
	{
		void StartBattle(List<Hero> heroes);
		/// <summary>
		/// Generates the given N number of heroes as result.
		/// </summary>
		/// <param name="heroCount">The given number of how much heroes you desire.</param>
		/// <returns></returns>
		Task<List<Hero>> GetHeroes(int heroCount);
	}
}

