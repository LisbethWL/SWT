using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM_DLL_Test;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class TrackTest
    {
        [TestCase(";39045;12932;14000;20151006213456789")]
        public void ConvertRawDataNullArgument(string arg1)
        {
            Assert.Throws<ArgumentNullException>(() => new Track(arg1));
        }
        [TestCase("ATR423;12932;14000;")]
        [TestCase("ATR423;39045;")]
        [TestCase("ATR423;")]
        [TestCase("ATR423;39045;12932;14000")]
        public void ConvertRawDataArgument(string arg1)
        {
            Assert.Throws<ArgumentException>(() => new Track(arg1));
        }
        [TestCase("ATR423;39BB045;12932;14000;20151006213456789")]
        [TestCase("ATR423;39045;12AA2;14000;20151006213456789")]
        [TestCase("ATR423;39045;12932;14CC0;20151006213456789")]
        [TestCase("ATR423;39045;12932;14000;2011006213456789")]
        [TestCase("ATR423;39045;12932;14000;2015M006213456789")]
        [TestCase("ATR423;39045;12932;14000;2015100D213456789")]
        [TestCase("ATR423;39045;12932;14000;20151006")]
        public void ConvertRawDataFormat(string arg1)
        {
            Assert.Throws<FormatException>(() => new Track(arg1));
        }
        [TestCase("ATR423;39045;12932;14000;20180410114803952")]
        public void ConvertRawDataSuccess(string arg1)
        {
            Assert.DoesNotThrow(() => new Track(arg1));
        }

    }
}
