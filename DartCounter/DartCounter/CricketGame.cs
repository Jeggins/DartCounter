using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartCounter
{
    class CricketGame
    {
        public int PlayerAmount { get; set; }
        public int StartPoints { get; set; }
        public int ActivePlayer { get; set; }
        public List<PlayerCricket> players;

        public CricketGame(int playerAmount, int startPoints, string[] names)
        {
            this.PlayerAmount = playerAmount;
            this.StartPoints = startPoints;
            this.ActivePlayer = 0;
            players = new List<PlayerCricket>();
            for (int i = 0; i < playerAmount; i++)
            {
                PlayerCricket p = new PlayerCricket(names[i], startPoints);
                players.Add(p);
            }
        }

        public void HandleThrow(int score, int zone, bool isDouble, int ring)
        {
        }


        public void NextPlayer()
        {
        }
    }
}
