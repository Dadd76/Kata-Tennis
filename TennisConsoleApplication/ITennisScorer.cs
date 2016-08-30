using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace Tennis
    {
        public interface ITennisScorer
        {
            void AchievesScore(Player player);
            string GameScore { get; }
        }

        public enum Player
        {
            PlayerA,
            PlayerB
        }

        public enum Score
        {
            Love    = 0,
            Fifteen = 1,
            Thirty  = 2,
            Forty   = 3
        }


    public class TennisGame : ITennisScorer
    {

        public TennisGame()
        {
            this._gameScorePlayerA = 0;
            this._gameScorePlayerB = 0;
        }

        private int _gameScorePlayerA;
        private int _gameScorePlayerB;

        public string GameScore
        {
            get
            {
                var score = string.Empty;

                if (HasWinner())
                {
                   return ( "Win " + (_gameScorePlayerA - _gameScorePlayerB > 1 ? "PlayerA" : "PlayerB") );
                }

                else if (_gameScorePlayerA >= 3 && _gameScorePlayerB >= 3 && _gameScorePlayerA != _gameScorePlayerB)
                {
                    return (getAdvencedScore(score));
                }

                 return ( GetLitteralScore(_gameScorePlayerA).ToString() + " - " + (_gameScorePlayerA == _gameScorePlayerB ? "All" : GetLitteralScore(_gameScorePlayerB).ToString()) );
            }
        }

        private bool HasWinner()
        {
            if ( (_gameScorePlayerA >= 3 || _gameScorePlayerB >= 3) && Math.Abs(_gameScorePlayerA - _gameScorePlayerB)>1)
            {
                return true;
            }
            return false;
       }

        private string getAdvencedScore(string score)
        {
             if (_gameScorePlayerA > _gameScorePlayerB)
            {
                score = "Advantage PlayerA";
            }

            else if ( _gameScorePlayerB > _gameScorePlayerA)
            {
                score = "Advantage PlayerB";
            }

            return score;
        }

        public string GetPlayerScore(Player player)
        {
            return string.Empty;
        }

        private Score GetLitteralScore(int x)
        {
            switch (x)
            {
                case 0:
                    return Score.Love;
                case 1:
                    return Score.Fifteen;
                case 2:
                    return Score.Thirty;
                case 3:
                    return Score.Forty;
                default:
                    return Score.Forty;
            }
        }

        public void AchievesScore(Player player)
        {
            if (player == Player.PlayerA)
            {
                _gameScorePlayerA++;
            }

            else
            {
                _gameScorePlayerB++;
            }  
        }
    }



}

