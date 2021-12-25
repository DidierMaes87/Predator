using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pra.Safari.Core.Enums;
using Pra.Safari.Core.Interfaces;

namespace Pra.Safari.Core.Entities
{
    class Mouse : Mammal, IPrey
    {
        public Mouse(Sex sex, int health = 100) : base(sex, health) { }
        public Mouse() : base() { }
        
        public IEnumerable<IPrey> Mate(IPrey partner)
        {
            if(partner.GetType() != typeof(Mouse))
            {
                throw new ArgumentException("Kan niet voortplanten. Kies dier van dezelfde soort");
            }
            else if (Sex == partner.Sex)
            {
                throw new ArgumentException("Kan niet voortplanten. Enkel mannetjes gekoppeld aan vrouwtjes kunnen zich voortplanten");
            }

            int avgHealth = (Health + partner.Health) / 2;
            int offspringNumber = avgHealth / 10;
            int maleOffspring = offspringNumber / 2;

            List<Mouse> offspring = new List<Mouse>();
            for(int i = 0; i < offspringNumber; ++i)
            {
                Sex newSex = (i < maleOffspring) ? Sex.Female : Sex.Male;
                offspring.Add(new Mouse(newSex, avgHealth));

            }

            return offspring;

        }
    }
}
