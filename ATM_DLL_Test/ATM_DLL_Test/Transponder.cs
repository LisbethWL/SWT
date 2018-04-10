using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM_DLL_Test
{
    public class Transponder : ITransponderReceiver
    {
        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;
    }
}
