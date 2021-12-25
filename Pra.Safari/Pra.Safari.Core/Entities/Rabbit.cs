using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pra.Safari.Core.Enums;
using Pra.Safari.Core.Interfaces;

namespace Pra.Safari.Core.Entities
{
    class Rabbit : Mammal, IPrey
    {
        public Rabbit (Sex sex, int health = 100) : base(sex, health) { }
        public Rabbit() : base(){ }

        public IEnumerable<IPrey> Mate(IPrey partner)
        {
            if(partner.GetType()!=typeof(Rabbit))
            {
                throw new ArgumentException("Kan niet voortplanten. Kies dier van dezelfde soort");
            }
            else if(Sex == partner.Sex)
            {
                throw new ArgumentException("Kan niet voortplanten. Enkel mannetjes gekoppeld aan vrouwtjes kunnen zich voortplanten");
            }

            List<Rabbit> offspring = new List<Rabbit>();
            int maxHealth = Math.Max(Health, partner.Health);
            int offspringNumber = random.Next(1, 11);

            for (int i = 0; i < offspringNumber; ++i)
            {
                int newHealth = random.Next(1, maxHealth + 1);
                Sex newSex = RandomSex();

                offspring.Add(new Rabbit(newSex, newHealth));
            }

            return offspring;
        }

        

    }

  
}
