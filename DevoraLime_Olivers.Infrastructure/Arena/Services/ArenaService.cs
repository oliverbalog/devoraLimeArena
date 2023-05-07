using System;
using DevoraLime_Olivers.Domain.Modules.Arena;
using DevoraLime_Olivers.Domain.Modules.Arena.Queries;
using DevoraLime_Ollivers.Domain.Modules.Hero;
using Domain.Modules.Hero;
using MediatR;
using Microsoft.Extensions.Logging;

namespace DevoraLime_Olivers.Infrastructure.ArenaService
{
	public class ArenaService: IArenaService
	{
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
		public ArenaService(IMediator mediator, ILogger<ArenaService> logger)
		{
            _mediator = mediator;
            _logger = logger;
		}

        public async Task<List<Hero>> GetHeroes(int heroCount)
        {
            var heroes = await _mediator.Send(new GetHeroes.Query(heroCount));

            return heroes;
        }

        public void StartBattle(List<Hero> heroes)
        {
            var random = new Random();
            var round = 1;
            
            while(heroes.Count > 1)
            {
                _logger.LogCritical("--------------" + round.ToString() + " kör! ---------------------------");

                var attackerArrIndex = random.Next(0, heroes.Count);
                var defenderArrIndex = random.Next(0, heroes.Count);
                while(defenderArrIndex == attackerArrIndex)
                {
                    defenderArrIndex = random.Next(0, heroes.Count);
                }

                var attacker = heroes[attackerArrIndex];
                var defender = heroes[defenderArrIndex];

                var logStart = $"A(z) {attacker.Id} azonosítójú {HeroTypeLocale.HeroTypeLocaleLookup[attacker.Type].FirstOrDefault()} {attacker.Health} életerővel megtámadta " +
                    $"a(z) {defender.Id} azonosítójú, {defender.Health} életerejű {HeroTypeLocale.HeroTypeLocaleLookup[defender.Type].FirstOrDefault()}t.";
                _logger.Log(LogLevel.Information, logStart);

                defender.GetAttacked(attacker);
                defender.Participated();
                attacker.Participated();

                RestHeroes(attackerArrIndex, defenderArrIndex);


                var logResult = $"A támadás után a támadó ({attacker.Id}) " + (attacker.IsDead ? "meghalt. " : $"életben maradt és {attacker.Health} életereje maradt. ");
                logResult += $"A védekező fél ({defender.Id}) " + (defender.IsDead ? "meghalt. " : $"életben maradt és {attacker.Health} életereje maradt. ");

                _logger.Log(LogLevel.Information, logResult);

                heroes.RemoveAll(x => x.IsDead);
                round++;
                _logger.Log(LogLevel.Information, "------------------------------------");
            }

            if (heroes.Count > 0)
            {
                _logger.Log(LogLevel.Information, $"A csata véget ért és a győztes a(z) {heroes?.FirstOrDefault()?.Id??1} azonosítójú {HeroTypeLocale.HeroTypeLocaleLookup[heroes?.FirstOrDefault()?.Type??HeroType.Swordsman].FirstOrDefault()} {heroes?.FirstOrDefault()?.Health??0} életerővel!");
                return;
            }
            _logger.Log(LogLevel.Information, "A csata véget ért és minden hős meghalt!");



            
            void RestHeroes(int attackerArrIndex, int defenderArrIndex)
            {
                for (int i = 0; i < heroes.Count - 1; i++)
                {
                    var currHero = heroes[i];
                    if (i != attackerArrIndex && i != defenderArrIndex)
                    {
                        if (currHero.Health < currHero.MaxHealth - 10)
                            heroes[i].Health += 10;
                    }
                }
            }
        }
    }
}

