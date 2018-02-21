using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_Roulette;

namespace THE_TEST
{
    class test_Roulette : IRoulette
    {
        private Field _result = new Field(5, Field.Red);

        public Field GetResult()
        {
            return _result;
        }

        public void spin()
        {
            //skal sættes til noget, jeg kan regne med...
            //jeg kan ikke teste på tilfældigt
            // test med: 0, 5 og 32
          
            if(_result.Number == 5)
            {
                _result = new Field(31, Field.Black);

            }

            if (_result.Number == 31)
            {
                _result = new Field(0, Field.Green);
            }

            if (_result.Number == 0)
            {
                _result = new Field(5, Field.Red);
            }

        }
    }
}

//var n = (uint)new Random().Next(0, 37);
//_result = _fields[(int)n];