using Pra.Safari.Core.Enums;
using Pra.Safari.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pra.Safari.Core.Entities
{
    public class Fox : Mammal, IPredator
    {
 

        public Fox (Sex sex) : base(sex){ }
        public Fox() : base() { }
        public void Attack (IPrey prey) {

            int preyDamage = random.Next(0, Health + 1);
            prey.Health -= preyDamage;

            int ownDamage = random.Next(0, 11);
            Health -= ownDamage;
        
        }

        
    }
}