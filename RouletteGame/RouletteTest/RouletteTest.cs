using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RouletteGame.Legacy;

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
}
