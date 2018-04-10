using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_DLL_Test
{
    public class Track : ITrack
    {
        public Track(string rawdata)
        {
            ConvertRawData(rawdata);
        }
        public string Tag { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Altitude { get; set; }
        public DateTime Timestamp { get; set; }

        public void ConvertRawData(string data)
        {
            string[] datas = data.Split(';');

            Tag = datas[0];
            XCoordinate = int.Parse(datas[1]);
            YCoordinate = int.Parse(datas[2]);
            Altitude = int.Parse(datas[3]);
            Timestamp = DateTime.Parse(datas[4]);
        }
    }
}
