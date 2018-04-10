namespace ATM_DLL_Test
{
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
}