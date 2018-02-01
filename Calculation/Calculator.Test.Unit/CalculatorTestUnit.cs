using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Test.Unit
{
    public class CalculatorTestUnit
    {
        [TestFixture]
        public class CalculatorTest
        {
            [Test]
            public void Add2And4_Returns6()
            {
                var uut = new Calculator();

                Assert.That(uut.Add(2, 4), Is.EqualTo(6));
            }


        }
    }
}
