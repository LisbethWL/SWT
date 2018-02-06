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
            [Test]
            public void Subtract2From4_Returns2()
            {
                var uut = new Calculator();

                Assert.That(uut.Subtract(4, 2), Is.EqualTo(2));
            }
            [Test]
            public void Multiply2With4_Returns8()
            {
                var uut = new Calculator();

                Assert.That(uut.Multiply(2, 4), Is.EqualTo(8));
            }
            [Test]
            public void TwoToThePowerOf4()
            {
                var uut = new Calculator();

                Assert.That(uut.Power(2, 4), Is.EqualTo(16));
            }


        }
    }
}
