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
        public int Eightteen { get; set; }
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
            this.Eightteen = 3;
            this.Seventeen = 3;
            this.Sixteen = 3;
            this.Fifteen = 3;
            this.Bull = 3;
            throws = new List<Throws>();
        }

        /// <summary>
        /// Berechnet die Punkte
        /// </summary>
        public void setPoints()
        {
            this.Points = Points + throws.Last().Points;
        }

        /// <summary>
        /// Fügt ein Wurf der Liste hinzu
        /// </summary>
        /// <param name="points">Punkte des Wurfs</param>
        /// <param name="isDouble">Wurde ein Double-Feld getroffen?</param>
        /// <param name="ring">Welches Feld wurde getroffen</param>
        public void AddThrow(int points, int zone, bool isDouble, int ring)
        {
            Throws t = new Throws(points, zone, isDouble, false, ring);
            throws.Add(t);
        }

        public void checkForInning()
        {

        }

        /// <summary>
        /// Prüft ob ein Spieler gewonnen hat
        /// </summary>
        /// <returns>Gewonnen oder nicht</returns>
        public bool Win()
        {
            return false;
        }
    }
}
