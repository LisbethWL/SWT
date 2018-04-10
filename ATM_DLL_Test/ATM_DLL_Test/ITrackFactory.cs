namespace ATM_DLL_Test
{
    public interface ITrackFactory
    {
        ITrack MakeTrack(string trackType, string rawData);
    }
}