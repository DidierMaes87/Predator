using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pra.Safari.Core.Interfaces;
using Pra.Safari.Core.Enums;

namespace Pra.Safari.Core.Entities
{
    class Bear : Mammal, IPredator
    {
        public Bear(Sex sex) : base(sex) { }
        public Bear() : base()
        {
            Health = 250;
        }

        public void Attack(IPrey prey)
        {

            int preyDamage = random.Next(0, 15);
            prey.Health -= preyDamage;

            int ownDamage = random.Next(0, 20);
            Health -= ownDamage;
        }
    }
}
