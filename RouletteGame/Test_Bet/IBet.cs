using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Bet
{
    interface IBet
    {
        string GetPlayerName();
        uint GetAmount();
        uint WonAmount();
    }
}
