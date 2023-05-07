using System;
using Domain.Modules.Hero;
using MediatR;

namespace DevoraLime_Olivers.Domain.Modules.Arena.Queries
{
	public class GetHeroes
	{
		public class Query: IRequest<List<Hero>>
		{
            /// <summary>
            /// Number of heroes to generate
            /// </summary>
            public int HeroCount { get; set; }
            public Query(int heroCount)
            {
                HeroCount = heroCount;
            }
        }
        public class Handler : IRequestHandler<Query, List<Hero>>
        {
            public Task<List<Hero>> Handle(Query request, CancellationToken cancellationToken)
            {
                var rand = new Random();
                var heroes = new List<Hero>();

                while(heroes.Count < request.HeroCount)
                {
                    GenerateHeroe();
                }

                void GenerateHeroe()
                {
                    var generatorRandom = rand.Next(0, 3);
                    if (generatorRandom == 0)
                    {
                        heroes.Add(new Hero(heroes.Count + 1, HeroType.Archer));
                    }
                    else if (generatorRandom == 1)
                    {
                        heroes.Add(new Hero(heroes.Count + 1, HeroType.Horseman));
                    }
                    else
                    {
                        heroes.Add(new Hero(heroes.Count + 1, HeroType.Swordsman));
                    }
                }
                

                return Task.FromResult(heroes);
            }
        }
    }
}

