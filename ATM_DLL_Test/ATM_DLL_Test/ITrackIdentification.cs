using System;
using System.Collections.Generic;
using TransponderReceiver;

namespace ATM_DLL_Test
{
    public interface ITrackIdentification
    {
        List<ITrack> Tracks { get; }
        void OnTransponderdataReady(object sender, RawTransponderDataEventArgs e);
    }
}