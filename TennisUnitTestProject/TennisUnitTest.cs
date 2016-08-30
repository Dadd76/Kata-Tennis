using System;
using NUnit.Framework;
using Tennis;

namespace UnitTestProject1
{
    [TestFixture]
    public class TennisUnitTest
    {
        [TestCase(0, 0, "Love - All")]
        [TestCase(1, 1, "Fifteen - All")]
        [TestCase(2, 2, "Thirty - All")]
        [TestCase(2, 3, "Thirty - Forty")]
        [TestCase(3, 2, "Forty - Thirty")]
        [TestCase(3, 3, "Forty - All")]
        [TestCase(3, 4, "Advantage PlayerB")]
        [TestCase(4, 3, "Advantage PlayerA")]
        [TestCase(4, 5, "Advantage PlayerB")]
        [TestCase(5, 4, "Advantage PlayerA")]
        [TestCase(15, 14, "Advantage PlayerA")]
        [TestCase(6, 4, "Win PlayerA")]
        [TestCase(4, 6, "Win PlayerB")]
        public void CheckSore(int scoreA, int scoreB , string result )
        {
            TennisGame myTennisGame = new TennisGame();
            this.IncrementPlayer(Player.PlayerA, myTennisGame, scoreA);
            this.IncrementPlayer(Player.PlayerB, myTennisGame, scoreB);
            Assert.AreEqual(result, myTennisGame.GameScore.ToString());
        }

        public void IncrementPlayer(Player p , TennisGame tg, int score)
        {
            for (int i = 0; i < score; i++)
                tg.AchievesScore(p);
        }
    }
}
