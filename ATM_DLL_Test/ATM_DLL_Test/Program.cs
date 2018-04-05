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


    public class Transponder : ITransponderReceiver
    {
        public event EventHandler<RawTransponderDataEventArgs> TransponderDataReady;
    }

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

    public class TrackFactory : ITrackFactory
    {
        public ITrack MakeTrack(string trackType, string rawData)
        {
            if (trackType == "NULL")
                return null;
            if (trackType == "standart")
                return new Track(rawData);

            return null;
        }
    }

    public interface ITrack
    {
        string Tag { get; set; }
        int XCoordinate { get; set; }
        int YCoordinate { get; set; }
        int Altitude { get; set; }
        DateTime Timestamp { get; set; }
        void ConvertRawData(string data);
    }

    public interface ITrackFactory
    {
        ITrack MakeTrack(string trackType, string rawData);
    }

    
}
