using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_DLL_Test
{
    public interface ITrack
    {
        string Tag { get; set; }
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
        int Altitude { get; set; }
        DateTime Timestamp { get; set; }
        void ConvertRawData(string data);
    }
}
