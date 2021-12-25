using Pra.Safari.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pra.Safari.Core.Interfaces
{
   public interface IMammal
    {
        Sex Sex { get; }

        int Health { get; set; }

        bool IsAlive { get; }
    }
}