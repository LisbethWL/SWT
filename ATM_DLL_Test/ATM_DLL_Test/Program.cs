﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM_DLL_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = new TrackIdentification(TransponderReceiverFactory.CreateTransponderDataReceiver());
            Console.ReadKey();
        }

        

    }
}
