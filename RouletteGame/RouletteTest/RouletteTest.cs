using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RouletteGame.Legacy;
using Test_Roulette;

namespace RouletteTest
{
    [TestFixture]
    public class RouletteTest
    {
        [Test]
        public void CanEvenWin()
        {
            Field field = new Field(2, 0);
            var game = new RouletteGame.Legacy.RouletteGame(new FakeRoulette(field));
            game.OpenBets();
            Bet bet = new EvenOddBet("Fake Player", 100, true);
            game.PlaceBet(bet);
            game.CloseBets();
            game.SpinRoulette();
            game.PayUp();
            Assert.That(game.FakePayUp(bet).Equals(bet.WonAmount(field)));
        }
        [Test]
        public void CanOddWin()
        {
            Field field = new Field(1, 0);
            var game = new RouletteGame.Legacy.RouletteGame(new FakeRoulette(field));
            game.OpenBets();
            Bet bet = new EvenOddBet("Fake Player", 100, false);
            game.PlaceBet(bet);
            game.CloseBets();
            game.SpinRoulette();
            game.PayUp();
            Assert.That(game.FakePayUp(bet).Equals(bet.WonAmount(field)));
        }
        [Test]
        public void CanAllFieldWin()
        {
            for (uint i = 0; i < 37; i++)
            {
                Field field = new Field(i, 0);
                var game = new RouletteGame.Legacy.RouletteGame(new FakeRoulette(field));
                game.OpenBets();
                Bet bet = new FieldBet("Fake Player", 100, i);
                game.PlaceBet(bet);
                game.CloseBets();
                game.SpinRoulette();
                game.PayUp();
                Assert.That(game.FakePayUp(bet).Equals(bet.WonAmount(field)));
            }
        }
        [Test]
        public void CanRedWin()
        {
            Field field = new Field(1, 0);
            var game = new RouletteGame.Legacy.RouletteGame(new FakeRoulette(field));
            game.OpenBets();
            Bet bet = new ColorBet("Fake Player", 100, 0);
            game.PlaceBet(bet);
            game.CloseBets();
            game.SpinRoulette();
            game.PayUp();
            Assert.That(game.FakePayUp(bet).Equals(bet.WonAmount(field)));
        }
        [Test]
        public void CanBlackWin()
        {
            Field field = new Field(1, 1);
            var game = new RouletteGame.Legacy.RouletteGame(new FakeRoulette(field));
            game.OpenBets();
            Bet bet = new ColorBet("Fake Player", 100, 1);
            game.PlaceBet(bet);
            game.CloseBets();
            game.SpinRoulette();
            game.PayUp();
            Assert.That(game.FakePayUp(bet).Equals(bet.WonAmount(field)));
        }

    }

    public class FakeRoulette : RouletteGame.Legacy.Roulette
    {
        private readonly RouletteGame.Legacy.Field _result;

        public FakeRoulette(Field result)
        {
            _result = result;
        }

        public override RouletteGame.Legacy.Field GetResult()
        {
            return _result;
        }
    }

    
    class FieldeTest
    {
        [Test]
        public void ThrowsExceptionIfField37()
        {
            const uint bad_input = 37;
            TestDelegate testDelegate = () => new Field(bad_input, 0);
            var ex = Assert.Throws<FieldException>(testDelegate);
        }

        [Test]
        public void DoesNetThrowIfField36()
        {
            const uint good_input = 36;
            TestDelegate testDelegate = () => new Field(good_input, 1);
            Assert.DoesNotThrow(testDelegate);
        }

        //[Test]
        //public void ThrowIfFieldGreenAndNot0()
        //{
        //    const uint bad_input = 1;
        //    TestDelegate testDelegate = () => new Field(bad_input, 2);
        //    var ex = Assert.Throws<FieldException>(testDelegate);
        //}



    }
    class Roulette : IRoulette
    {

        private readonly List<Field> _fields;
        private Field _result;

        public Roulette()
        {
            _fields = new List<Field>
            {
                new Field(0, Field.Green),
                new Field(1, Field.Red),
                new Field(2, Field.Black),
                new Field(3, Field.Red),
                new Field(4, Field.Black),
                new Field(5, Field.Red),
                new Field(6, Field.Black),
                new Field(7, Field.Red),
                new Field(8, Field.Black),
                new Field(9, Field.Red),
                new Field(10, Field.Black),
                new Field(11, Field.Black),
                new Field(12, Field.Red),
                new Field(13, Field.Black),
                new Field(14, Field.Red),
                new Field(15, Field.Black),
                new Field(16, Field.Red),
                new Field(17, Field.Black),
                new Field(18, Field.Red),
                new Field(19, Field.Red),
                new Field(20, Field.Black),
                new Field(21, Field.Red),
                new Field(22, Field.Black),
                new Field(23, Field.Red),
                new Field(24, Field.Black),
                new Field(25, Field.Red),
                new Field(26, Field.Black),
                new Field(27, Field.Red),
                new Field(28, Field.Black),
                new Field(29, Field.Black),
                new Field(30, Field.Red),
                new Field(31, Field.Black),
                new Field(32, Field.Red),
                new Field(33, Field.Black),
                new Field(34, Field.Red),
                new Field(35, Field.Black),
                new Field(36, Field.Red)
            };

            _result = _fields[0];
        }

        public Field GetResult()
        {
            return _result;
        }

        public void spin()
        {
            var n = (uint)new Random().Next(0, 37);
            _result = _fields[(int)n];
        }

        
    }


}

