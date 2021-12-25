using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pra.Safari.Core.Interfaces
{
    public interface IPredator : IMammal
    {
        void Attack(IPrey prey);
        
    }
}
