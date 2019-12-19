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
        public bool Closed20 { get; set; }
        public bool Closed19 { get; set; }
        public bool Closed18 { get; set; }
        public bool Closed17 { get; set; }
        public bool Closed16 { get; set; }
        public bool Closed15 { get; set; }
        public bool ClosedBull { get; set; }
        public List<PlayerCricket> players;
        public string Winner { get; set; }

        public CricketGame(int playerAmount, int startPoints, string[] names)
        {
            this.PlayerAmount = playerAmount;
            this.StartPoints = startPoints;
            this.ActivePlayer = 0;
            Closed20 = false;
            Closed19 = false;
            Closed18 = false;
            Closed17 = false;
            Closed16 = false;
            Closed15 = false;
            ClosedBull = false;

            players = new List<PlayerCricket>();
            for (int i = 0; i < playerAmount; i++)
            {
                PlayerCricket p = new PlayerCricket(names[i], startPoints);
                players.Add(p);
            }
        }

        public void HandleThrow(int score, int zone, int ring)
        {
            int inning = ring;
            CheckForClosedFields();
            if (ring == 4)
            {
                inning = 1;
            }
            if (ring == 5)
            {
                inning = 2;
            }
            if (zone >= 15)
            {
                if (ZoneIsClosed(zone))
                {
                    players[ActivePlayer].AddThrow(0, zone, inning, ring);
                }
                else
                {
                    if (players[ActivePlayer].getZoneInning(zone) < inning)
                    {
                        int multiplier = inning - players[ActivePlayer].getZoneInning(zone);
                        players[ActivePlayer].AddThrow(zone * multiplier, zone, players[ActivePlayer].getZoneInning(zone), ring);
                    }
                    else
                    {
                        players[ActivePlayer].AddThrow(0, zone, inning, ring);
                    }
                }
            }
            else
            {
                players[ActivePlayer].AddThrow(0, zone, 0, ring);
            }
            players[ActivePlayer].CalculateThrow();
            players[ActivePlayer].HandleThrows(1);
            players[ActivePlayer].Undo = true;
        }

        public void CheckForClosedFields()
        {
            Closed15 = true;
            Closed16 = true;
            Closed17 = true;
            Closed18 = true;
            Closed19 = true;
            Closed20 = true;
            ClosedBull = true;

            for (int i = 0; i <= PlayerAmount - 1; i++)
            {
                if (ActivePlayer == i)
                {
                    continue;
                }
                if (players[i].CheckIfClosed(15) == false)
                {
                    Closed15 = false;
                }
                if (players[i].CheckIfClosed(16) == false)
                {
                    Closed16 = false;
                }
                if (players[i].CheckIfClosed(17) == false)
                {
                    Closed17 = false;
                }
                if (players[i].CheckIfClosed(18) == false)
                {
                    Closed18 = false;
                }
                if (players[i].CheckIfClosed(19) == false)
                {
                    Closed19 = false;
                }
                if (players[i].CheckIfClosed(20) == false)
                {
                    Closed20 = false;
                }
                if (players[i].CheckIfClosed(25) == false)
                {
                    ClosedBull = false;
                }
            }
        }

        public bool ZoneIsClosed(int zone)
        {
            switch (zone)
            {
                case 15:
                    return Closed15;
                case 16:
                    return Closed16;
                case 17:
                    return Closed17;
                case 18:
                    return Closed18;
                case 19:
                    return Closed19;
                case 20:
                    return Closed20;
                case 25:
                    return ClosedBull;
            }
            return false;
        }

        /// <summary>
        /// Prüft ob jemand gewonnen hat
        /// </summary>
        /// <returns></returns>
        public bool CheckForWin()
        {
            int maxValue = players.Max(x => x.Points);
            List<PlayerCricket> maxPoints = new List<PlayerCricket>();
            foreach (PlayerCricket player in players)
            {
                if (player.Points == maxValue && player.CheckIfAllClosed())
                {
                    maxPoints.Add(player);
                }
            }
            if (maxPoints.Count == 1)
            {
                Winner = maxPoints[0].Name;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Mach den die aktuelle Aufnahme Rückgängig
        /// </summary>
        public void Undo()
        {
            
            if (players[ActivePlayer].ThrowsLeft == 3)
            {
                RemovePoints(3);
                players[ActivePlayer].RemoveThrow(3);
                players[ActivePlayer].ResetThrows();
            }
            else
            {
                RemovePoints();
                players[ActivePlayer].RemoveThrow(3 - players[ActivePlayer].ThrowsLeft);
                players[ActivePlayer].ResetThrows();
            }
        }

        /// <summary>
        /// Fügt die Punkte der Würfe, die in dieser Aufnahme schon gemacht wurden, wieder hinzu
        /// </summary>
        public void RemovePoints()
        {
            for (int i = 0; i < 3 - players[ActivePlayer].ThrowsLeft; i++)
            {
                players[ActivePlayer].Points -= players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Points;
                if (players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning > 0)
                {
                    switch (players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Zone)
                    {
                        case 15:
                            players[ActivePlayer].Fifteen += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 16:
                            players[ActivePlayer].Sixteen += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 17:
                            players[ActivePlayer].Seventeen += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 18:
                            players[ActivePlayer].Eighteen += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 19:
                            players[ActivePlayer].Nineteen += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 20:
                            players[ActivePlayer].Twenty += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 25:
                            players[ActivePlayer].Bull += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Fügt die Punkte so vieler Würfen, die im Parameter übergeben wird, wieder hinzu
        /// </summary>
        /// <param name="amount">Anzahl der zu löschenden Würfe</param>
        public void RemovePoints(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                players[ActivePlayer].Points -= players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Points;
                if (players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning > 0)
                {
                    switch (players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Zone)
                    {
                        case 15:
                            players[ActivePlayer].Fifteen += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 16:
                            players[ActivePlayer].Sixteen += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 17:
                            players[ActivePlayer].Seventeen += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 18:
                            players[ActivePlayer].Eighteen += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 19:
                            players[ActivePlayer].Nineteen += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 20:
                            players[ActivePlayer].Twenty += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                        case 25:
                            players[ActivePlayer].Bull += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Inning;
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Spiel wechselt zum nächsten Spieler
        /// </summary>
        public void NextPlayer()
        {
            if (ActivePlayer < (PlayerAmount - 1))
            {
                ActivePlayer++;
                players[ActivePlayer].ResetThrows();
            }
            else
            {
                ActivePlayer = 0;
                players[ActivePlayer].ResetThrows();
            }
        }
    }
}
