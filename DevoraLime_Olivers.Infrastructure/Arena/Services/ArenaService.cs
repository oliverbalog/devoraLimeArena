using System;
using DevoraLime_Olivers.Domain.Modules.Arena;
using DevoraLime_Olivers.Domain.Modules.Arena.Queries;
using Domain.Modules.Hero;
using MediatR;

namespace DevoraLime_Olivers.Infrastructure.ArenaService
{
	public class ArenaService: IArenaService
	{
        private readonly IMediator _mediator;
		public ArenaService(IMediator mediator)
		{
            _mediator = mediator;
		}

        public async Task<List<Hero>> GetHeroes(int heroCount)
        {
            var heroes = await _mediator.Send(new GetHeroes.Query(heroCount));

            return heroes;
        }

        public void StartBattle(List<Hero> heroes)
        {
            throw new NotImplementedException();
        }
    }
}

