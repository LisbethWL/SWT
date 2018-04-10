using System;
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
            var test = TransponderReceiverFactory.CreateTransponderDataReceiver();
            test.TransponderDataReady += OnTransponderdataReady;

            for (;;)
            {
                
            }
        }

        private static void OnTransponderdataReady(object sender, RawTransponderDataEventArgs e)
        {
            foreach (var data in e.TransponderData)
            {
                Console.WriteLine(data);
            }
        }

    }
}
