using System;
using Domain.Modules.Hero;
using MediatR;

namespace DevoraLime_Olivers.Domain.Modules.Arena.Commands
{
	public class StartArena
	{
		public class Command: IRequest
		{
            public List<Hero> Heroes { get; set; }
            public Command(List<Hero> heroes)
            {
                Heroes = heroes;
            }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly IArenaService _arenaService;
            public Handler(IArenaService arenaService)
            {
                _arenaService = arenaService;
            }
            public Task Handle(Command request, CancellationToken cancellationToken)
            {
                _arenaService.StartBattle(request.Heroes);

                return Unit.Task;
            }
        }
    }
}

