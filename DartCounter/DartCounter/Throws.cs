using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartCounter
{
    public class Throws
    {
        public int Points { get; set; }
        public int Zone { get; set; }
        public bool IsDouble { get; set; }
        public bool PossibleFinishDart { get; set; }
        public bool WasInning { get; set; }
        public int Ring { get; set; }

        /// <summary>
        /// Konstruktor der Klasse Throws
        /// </summary>
        /// <param name="points">Punktzahl</param>
        /// <param name="isDouble">Wurde ein Double-Feld getroffen?</param>
        /// <param name="possibleFinishDart">Konnte mit dem Dart gefinished werden?</param>
        /// <param name="ring">Welches Feld wurde getroffen?</param>
        public Throws(int points, int zone, bool isDouble, bool possibleFinishDart, int ring)
        {
            this.Points = points;
            this.Zone = zone;
            this.IsDouble = isDouble;
            this.PossibleFinishDart = possibleFinishDart;
            this.Ring = ring;
        }

        /// <summary>
        /// Konstruktor der Klasse Throws
        /// </summary>
        /// <param name="points">Punktzahl</param>
        /// <param name="isDouble">Wurde ein Double-Feld getroffen?</param>
        /// <param name="possibleFinishDart">Konnte mit dem Dart gefinished werden?</param>
        /// <param name="ring">Welches Feld wurde getroffen?</param>
        public Throws(int points, int zone, bool wasInning, int ring)
        {
            this.Points = points;
            this.Zone = zone;
            this.WasInning = wasInning;
            this.Ring = ring;
        }
    }
}
