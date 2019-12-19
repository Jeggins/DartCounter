using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartCounter
{
    class PlayerCricket
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public string LastThrow { get; set; }
        public int ThrowsLeft { get; set; }
        public bool Undo { get; set; }
        public int Twenty { get; set; }
        public int Nineteen { get; set; }
        public int Eighteen { get; set; }
        public int Seventeen { get; set; }
        public int Sixteen { get; set; }
        public int Fifteen { get; set; }
        public int Bull { get; set; }

        public List<Throws> throws;

        public PlayerCricket(string name, int startPoints)
        {
            this.Name = name;
            this.Points = startPoints;
            this.ThrowsLeft = 3;
            this.Twenty = 3;
            this.Nineteen = 3;
            this.Eighteen = 3;
            this.Seventeen = 3;
            this.Sixteen = 3;
            this.Fifteen = 3;
            this.Bull = 3;
            throws = new List<Throws>();
        }

        /// <summary>
        /// Berechnet die Punkte
        /// </summary>
        public void CalculateThrow()
        {
            this.Points = Points + throws.Last().Points;
            if (throws.Last().Inning > 0)
            {
                switch (throws.Last().Zone)
                {
                    case 15:
                        Fifteen -= throws.Last().Inning;
                        break;
                    case 16:
                        Sixteen -= throws.Last().Inning;
                        break;
                    case 17:
                        Seventeen -= throws.Last().Inning;
                        break;
                    case 18:
                        Eighteen -= throws.Last().Inning;
                        break;
                    case 19:
                        Nineteen -= throws.Last().Inning;
                        break;
                    case 20:
                        Twenty -= throws.Last().Inning;
                        break;
                    case 25:
                        Bull -= throws.Last().Inning;
                        break;
                }
            }
        }

        /// <summary>
        /// gibt den aktuellen Wert des Innings einer bestimmten Zone zurück
        /// </summary>
        /// <returns></returns>
        public int getZoneInning(int zone)
        {
            switch (zone)
            {
                case 15:
                    return Fifteen;
                case 16:
                    return Sixteen;
                case 17:
                    return Seventeen;
                case 18:
                    return Eighteen;
                case 19:
                    return Nineteen;
                case 20:
                    return Twenty;
                case 25:
                    return Bull;
            }
            return 0;
        }

        /// <summary>
        /// Check if throw was Inning
        /// </summary>
        public bool CheckForInning(int zone)
        {
            switch (zone)
            {
                case 15:
                    return (Fifteen > 0) ? true : false;
                case 16:
                    return (Sixteen > 0) ? true : false;
                case 17:
                    return (Seventeen > 0) ? true : false;
                case 18:
                    return (Eighteen > 0) ? true : false;
                case 19:
                    return (Nineteen > 0) ? true : false;
                case 20:
                    return (Twenty > 0) ? true : false;
                case 25:
                    return (Bull > 0) ? true : false;
            }
            return false;
        }

        /// <summary>
        /// Prüft ob die Zone schon geschlossen ist
        /// </summary>
        /// <param name="zone"></param>
        /// <returns></returns>
        public bool CheckIfClosed(int zone)
        {
            switch(zone)
            {
                case 15:
                    return (Fifteen <= 0) ? true : false;
                case 16:
                    return (Sixteen <= 0) ? true : false;
                case 17:
                    return (Seventeen <= 0) ? true : false;
                case 18:
                    return (Eighteen <= 0) ? true : false;
                case 19:
                    return (Nineteen <= 0) ? true : false;
                case 20:
                    return (Twenty <= 0) ? true : false;
                case 25:
                    return (Bull <= 0) ? true : false;
            }
            return false;
        }

        /// <summary>
        /// Fügt ein Wurf der Liste hinzu
        /// </summary>
        /// <param name="points">Punkte des Wurfs</param>
        /// <param name="isDouble">Wurde ein Double-Feld getroffen?</param>
        /// <param name="ring">Welches Feld wurde getroffen</param>
        public void AddThrow(int points, int zone, int inning, int ring)
        {
            Throws t = new Throws(points, zone, inning, ring);
            throws.Add(t);
        }

        /// <summary>
        /// Löscht die Anzahl an Würfen aus der Liste die im Parameter übergeben werden
        /// </summary>
        /// <param name="amount">Anzahl der zu löschenden Würfe</param>
        public void RemoveThrow(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                throws.Remove(throws.Last());
            }
        }

        /// <summary>
        /// Setzt die Punkte der letzten X Würfe auf 0 (bei Überworfen)
        /// </summary>
        /// <param name="amount">anzahl der Würfe</param>
        public void SetThrowsToZero(int amount)
        {
            if (throws.Count >= amount)
            {
                for (int i = 0; i < amount; i++)
                {
                    throws[throws.Count - 1 - i].Points = 0;
                }
            }
        }

        /// <summary>
        /// Zählt die Würfe die vom jeweiligen Spieler schon geworfen wurden
        /// </summary>
        /// <param name="amount">Anzahl der Würfe</param>
        public void HandleThrows(int amount)
        {
            this.ThrowsLeft = ThrowsLeft - amount;
        }

        /// <summary>
        /// Setzt die Würfe eines Spielers wieder auf drei zurück
        /// </summary>
        public void ResetThrows()
        {
            this.ThrowsLeft = 3;
        }

        /// <summary>
        /// Prüft ob ein Spieler gewonnen hat
        /// </summary>
        /// <returns>Gewonnen oder nicht</returns>
        public bool CheckIfAllClosed()
        {
            bool result = true;

            if (!CheckIfClosed(15))
            {
                result = false;
            }
            if (!CheckIfClosed(16))
            {
                result = false;
            }
            if (!CheckIfClosed(17))
            {
                result = false;
            }
            if (!CheckIfClosed(18))
            {
                result = false;
            }
            if (!CheckIfClosed(19))
            {
                result = false;
            }
            if (!CheckIfClosed(20))
            {
                result = false;
            }
            if (!CheckIfClosed(25))
            {
                result = false;
            }

            return result;
        }
    }
}
