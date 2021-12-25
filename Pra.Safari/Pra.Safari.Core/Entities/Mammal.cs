using Pra.Safari.Core.Enums;
using Pra.Safari.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pra.Safari.Core.Entities
{
    public abstract class Mammal : IMammal
    {
        protected readonly Random random = new Random();
        private int health = 100;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value >= 0)
                {
                    health = value;
                }
                else
                {
                    health = 0;
                }
            }
        }
        public bool IsAlive
        {
            get
            {
                return Health > 0;

            }
        }

        public Sex Sex { get; private set; }

        protected Mammal(Sex sex, int health = 100)
        {
            Sex = sex;
            Health = health;

        }

        protected Mammal()
        {
            Health = 100;
            Sex = RandomSex();
        }

        protected Sex RandomSex()
        {
            int number = random.Next(2);
            if (number == 0)
            { 
                return Sex.Female;
            }
            else
            {
                return Sex.Male;
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name} ({Sex.ToString().Substring(0, 1)}) - {Health}";
        }
    }
}

