﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Bet
{
    class FakeBet : IBet
    {
        public string GetPlayerName()
        {
            throw new NotImplementedException();
        }

        public uint GetAmount()
        {
            throw new NotImplementedException();
        }

        public uint WonAmount()
        {
            throw new NotImplementedException();
        }
    }
}