using System;
namespace Domain.Modules.Hero
{
    public class Hero
    {
        public int Id { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public HeroType Type { get; set; }
        public bool IsDead { get; set; }


        public Hero(int iD, HeroType type)
        {
            var health = 100;
            switch (type)
            {
                case HeroType.Archer:
                    health = 100;
                    break;
                case HeroType.Horseman:
                    health = 150;
                    break;
                case HeroType.Swordsman:
                    health = 120;
                    break;
                default:
                    break;
            }

            Id = iD;
            Health = health;
            Type = type;
            MaxHealth = health;
        }


        /// <summary>
        /// The event that should occur when an attacker attacks.
        /// </summary>
        /// <param name="attacker">May it's IsDead param be changed.</param>
        public void GetAttacked(Hero attacker)
        {
            Random random = new Random();
            var chance = random.Next(0, 100);

            switch (attacker.Type)
            {
                case HeroType.Archer:
                    switch (Type)
                    {
                        case HeroType.Horseman:
                            if (chance < 40)
                            {
                                IsDead = true;
                            }
                            break;
                        case HeroType.Swordsman:
                            IsDead = true;
                            break;
                        case HeroType.Archer:
                            IsDead = true;
                            break;
                    }
                    break;
                case HeroType.Swordsman:
                    switch (Type)
                    {
                        case HeroType.Horseman:
                            break;
                        case HeroType.Swordsman:
                            IsDead = true;
                            break;
                        case HeroType.Archer:
                            IsDead = true;
                            break;
                    }
                    break;
                case HeroType.Horseman:
                    switch (Type)
                    {
                        case HeroType.Horseman:
                            IsDead = true;
                            break;
                        case HeroType.Swordsman:
                            attacker.IsDead = true;
                            break;
                        case HeroType.Archer:
                            IsDead = true;
                            break;
                    }
                    break;
                default:
                    break;
            }

        }

        public void Participated()
        {
            if (IsDead) { return; }

            Health /= 2;
            if (Health < MaxHealth / 4)
            {
                IsDead = true;
            }

        }
    }
}

