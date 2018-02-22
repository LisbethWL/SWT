using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteGame.Legacy;

namespace Test_Roulette
{
    public interface IRoulette
    {
        void spin();
        Field GetResult();

    }
}
