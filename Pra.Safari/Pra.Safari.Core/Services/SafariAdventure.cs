using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pra.Safari.Core.Entities;
using Pra.Safari.Core.Enums;
using Pra.Safari.Core.Interfaces;
using Pra.Safari.Core.Services;

namespace Pra.Safari.Core.Services
{
    public class SafariAdventure
    {
        public List<IPredator> Predators { get; }
        public List<IPrey> Prey { get; }

        private readonly Random random = new Random();

        public SafariAdventure()
        {
            Predators = new List<IPredator>();
            Prey = new List<IPrey>();
        }

        public void AddBear()
        {
            Predators.Add(new Bear());
        }


        public void AddFox()
        {
            Predators.Add(new Fox());
        }

        public void AddRabbit()
        {
            Prey.Add(new Rabbit());
        }

        public void AddMouse()
        {
            Prey.Add(new Mouse());
        }

        public void Hunt()
        {
            foreach (IPredator predator in Predators)
            {
                if (Prey.Count == 0) break;

                int randomPrey = random.Next(Prey.Count);
                IPrey selectedPrey = Prey[randomPrey];

                predator.Attack(selectedPrey);

                if (!selectedPrey.IsAlive)
                {
                    Prey.Remove(selectedPrey);
                }
                
            }
            Predators.RemoveAll(fox => !fox.IsAlive);
        }



        public void Breed(IPrey parent1, IPrey parent2)
        {
            
            IEnumerable<IPrey> offspring = parent1.Mate(parent2);
            Prey.AddRange(offspring);
        }

    }
}
