using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_DLL_Test;
using NSubstitute;
using NSubstitute.Exceptions;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TransponderReceiver;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class TrackIdentificationIntegrationTest
    {
        ITransponderReceiver _receiver;
        
        [SetUp]
        public void Setup()
        {
            _receiver = Substitute.For<ITransponderReceiver>();
        }

        [TestCase("ATR423;39045;12932;14000;20180410114803952", 10)]
        [TestCase("ATR423;39045;12932;14000;20180410114803952", 1)]
        [TestCase("ATR423;39045;12932;14000;20180410114803952", 5)]
        [TestCase("ATR423;39045;12932;14000;20180410114803952", 30)]
        public void TestTrackCreatingFakeDLL(string arg, int times)
        {
            var data = new List<string>();
            for(int i = 0; i<times; i++)
                data.Add(arg);

            var transData = new RawTransponderDataEventArgs(data);

            var trackidentifier = new TrackIdentification(_receiver);

            try
            {
                _receiver.TransponderDataReady += Raise.EventWith(new object(),transData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Assert.AreEqual(times, trackidentifier.Tracks.Count);
        }
    }
}
