using DevoraLime_Olivers.Domain.Modules.Arena;
using DevoraLime_Olivers.Domain.Modules.Arena.Queries;
using MediatR;

namespace DevoraLime_Olivers;

public class App
{

    private readonly IArenaService _arenaService;
    public App(IArenaService arenaService)
    {
        _arenaService = arenaService;
    }

    public async void Run(string[] args)
    {
        var heroes = await _arenaService.GetHeroes(5);
        _arenaService.StartBattle(heroes);
    }
}


