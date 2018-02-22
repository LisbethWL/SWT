using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Test_Field
{
    [TestFixture]
    class FieldeTest
    {
        [Test]
        public void ThrowsExceptionIfField37()
        {
            const uint bad_input = 37;
            TestDelegate testDelegate = () => new Field(bad_input,0);
            var ex = Assert.Throws<FieldException>(testDelegate);
        }

        [Test]
        public void DoesNetThrowIfField36()
        {
            const uint good_input = 36;
            TestDelegate testDelegate = () => new Field(good_input, 1);
            Assert.DoesNotThrow(testDelegate);
        }

        [Test]
        public void ThrowIfFieldGreenAndNot0()
        {
            const uint bad_input = 1;
            TestDelegate testDelegate = () => new Field(bad_input, 2);
            var ex = Assert.Throws<FieldException>(testDelegate);
        }


        
    }
    static void Main()
    {

    }
    public class Field
    {
        public const uint Red = 0;
        public const uint Black = 1;
        public const uint Green = 2;

        private uint _color;
        private uint _number;

        // Constructor
        public Field(uint number, uint color)
        {
            Number = number;
            Color = color;
        }

        public uint Number
        {
            get { return _number; }
            private set
            {
                if (value <= 36) _number = value;
                else throw new FieldException($"Number {value} not a valid field number");
            }
        }

        public uint Color
        {
            get { return _color; }
            private set
            {
                if (value == Red || value == Black || value == Green) _color = value;
                else
                    throw new FieldException($"Color {value} not a valid color. Must be either Red or Black");
            }
        }

        public bool Even => Number % 2 == 0;

        public override string ToString()
        {
            string colorString;

            switch (Color)
            {
                case Red:
                    colorString = "red";
                    break;
                case Black:
                    colorString = "black";
                    break;
                default:
                    colorString = "green";
                    break;
            }

            return $"[{_number}, {colorString}]";
        }
    }

    public class FieldException : Exception
    {
        public FieldException(string s) : base(s)
        {
        }
    }
}
