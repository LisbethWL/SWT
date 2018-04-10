using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

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

        public void ConvertRawData(string rawdata)
        {
            var data = rawdata.Split(';');
            if(data.Length<5)
                throw new ArgumentException();
            if (IsNullOrEmpty(data[0]))
                throw new ArgumentNullException();
            
            Tag = data[0];
            XCoordinate = int.Parse(data[1]);
            YCoordinate = int.Parse(data[2]);
            Altitude = int.Parse(data[3]);
            if (!DateTime.TryParseExact(data[4], "yyyyMMddhhmmssfff", null, DateTimeStyles.None, out var stamp))
            {
                throw new FormatException();
            }
             Timestamp = stamp;
        }

        public override string ToString()
        {
            return Tag + "X: " + XCoordinate + " " + "Y: " + YCoordinate + " " + "Altitude: " + Altitude + " " + "Timestamp: " +
                   Timestamp;
        }
    }
}
