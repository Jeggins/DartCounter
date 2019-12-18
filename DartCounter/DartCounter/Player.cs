using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartCounter
{
    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }
        public string LastThrow { get; set; }
        public double Average { get; set; }
        public int ThrowsLeft { get; set; }
        public bool Overthrown { get; set; }
        public bool Undo { get; set; }
        public int OneHundredEighty { get; set; }

        public List<Throws> throws;

        /// <summary>
        /// Konstruktor der Klasse Player (Spieler der am aktuellen Spiel teilnimmt)
        /// </summary>
        /// <param name="name">Spielername</param>
        /// <param name="startPoints">Startpunkte</param>
        public Player(string name, int startPoints)
        {
            this.Name = name;
            this.Points = startPoints;
            this.Average = 0.0;
            this.ThrowsLeft = 3;
            this.Overthrown = false;
            this.OneHundredEighty = 0;
            throws = new List<Throws>();
        }

        /// <summary>
        /// Berechnet die Punkte
        /// </summary>
        public void setPoints()
        {
            this.Points = Points - throws.Last().Points;
        }

        /// <summary>
        /// Berechnet den 3-Dart Average
        /// </summary>
        public void calcAverage()
        {
            double d = 0.0;
            foreach (Throws point in throws)
            {
                d += point.Points;
            }
            d = (d / throws.Count) * 3;
            Average = Math.Round(d, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Fügt ein Wurf der Liste hinzu
        /// </summary>
        /// <param name="points">Punkte des Wurfs</param>
        /// <param name="isDouble">Wurde ein Double-Feld getroffen?</param>
        /// <param name="ring">Welches Feld wurde getroffen</param>
        public void AddThrow(int points, int zone, bool isDouble, int ring)
        {
            if (Points == 50 || Points <= 40 && Points % 2 == 0)
            {
                Throws t = new Throws(points, zone, isDouble, true, ring);
                throws.Add(t);
            }
            else
            {
                Throws t = new Throws(points, zone, isDouble, false, ring);
                throws.Add(t);
            }
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
        /// Prüft ob der aktuelle Wurf Überworden ist oder nicht
        /// </summary>
        /// <param name="DoubleOut">Spieleinstellung Double-Out oder Single-Out</param>
        /// <returns>1 = Überworfen, 2 = Kein Double-Out, 0 = korrekter Wurf</returns>
        public int IsOverthrown(bool DoubleOut)
        {
            if (DoubleOut)
            {
                if (Points < 0 || Points == 1)
                {
                    Overthrown = true;
                    return 1;
                }
                if (Points == 0 && !throws.Last().IsDouble)
                {
                    Overthrown = true;
                    return 2;
                }
                else
                {
                    Overthrown = false;
                    return 0;
                }
            }
            else
            {
                if (Points < 0)
                {
                    Overthrown = true;
                    return 1;
                }
                else
                {
                    Overthrown = false;
                    return 0;
                }
            }
        }

        /// <summary>
        /// Stellt den String für den letzten Wurf zusammen
        /// </summary>
        /// <param name="i">Überworfen oder korrekt</param>
        public void LastThrowToString(int i)
        {
            if (i == 0)
            {
                if (ThrowsLeft == 2)
                {
                    LastThrow = throws.Last().Points.ToString();
                }
                if (ThrowsLeft == 1)
                {
                    LastThrow = string.Format("{0}, {1} => {2}", throws[throws.Count - 2].Points,
                        throws.Last().Points, 
                        (throws[throws.Count - 2].Points + throws.Last().Points));
                }
                if (ThrowsLeft == 0)
                {
                    LastThrow = string.Format("{0}, {1}, {2} => {3}", throws[throws.Count - 3].Points,
                        throws[throws.Count - 2].Points,
                        throws.Last().Points,
                        (throws[throws.Count - 3].Points + throws[throws.Count - 2].Points + throws.Last().Points));
                    if ((throws[throws.Count - 3].Points + throws[throws.Count - 2].Points + throws.Last().Points) == 180)
                    {
                        OneHundredEighty++;
                    }
                }
            }
            if (i == 1)
            {
                LastThrow = "Überworfen!";
            }
            if (i == 2)
            {
                LastThrow = "Kein Doppel Out!";
            }
        }

        /// <summary>
        /// Prüft ob ein Spieler gewonnen hat
        /// </summary>
        /// <returns>Gewonnen oder nicht</returns>
        public bool Win()
        {
            if (Points == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
