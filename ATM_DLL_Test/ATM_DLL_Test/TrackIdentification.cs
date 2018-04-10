using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM_DLL_Test
{
    public class TrackIdentification : ITrackIdentification
    {
        public List<ITrack> Tracks { get; private set; }

        public TrackIdentification(ITransponderReceiver receiver)
        {
            receiver.TransponderDataReady += OnTransponderdataReady;
        }

        public void OnTransponderdataReady(object sender, RawTransponderDataEventArgs e)
        {
            Tracks = new List<ITrack>();
            foreach (var data in e.TransponderData)
            {
                Tracks.Add(new Track(data));
                Console.WriteLine(Tracks.Last().ToString());
            }
        }
    }
}
