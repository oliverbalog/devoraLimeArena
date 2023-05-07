using Domain.Modules.Hero;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace DevoraLime_Ollivers.Domain.Modules.Hero
{
    public static class HeroTypeLocale
    {
        public static readonly ILookup<HeroType, string> HeroTypeLocaleLookup = new Dictionary<HeroType, string>()
        {
            {HeroType.Archer,"Íjász" },
            {HeroType.Swordsman,"Kardos" },
            {HeroType.Horseman,"Lovas" }
        }.ToLookup(x => x.Key, x => x.Value);
    }
}
