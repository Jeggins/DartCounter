using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartCounter
{
    public class PlayerSave
    {
        public string Name { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesPlayedSingle { get; set; }
        public int Wins { get; set; }
        public int WinsSingle { get; set; }
        public int Looses { get; set; }
        public int LoosesSingle { get; set; }
        public double Average { get; set; }
        public double AverageSingleOut { get; set; }
        public int ThrownDarts { get; set; }
        public int PointsScored { get; set; }
        public double AverageNeededDartsToFinishDoubleOut { get; set; }
        public double AverageNeededDartsToFinishSingleOut { get; set; }
        public double AverageDoubleOutRate { get; set; }
        public int OneHundredEighty { get; set; }
        public int Checkout100 { get; set; }
        public int HighestFinish { get; set; }
        public int BestLegDarts { get; set; }
        public int BestLegDartsSingle { get; set; }
        public int DoubleBull { get; set; }
        public int SingleBull { get; set; }
        public int Triple { get; set; }
        public int Double { get; set; }
        public int Single { get; set; }
        public int Misses { get; set; }
        public List<double> DoubleOutRate;
        public List<int> NeededDartsToFinishDoubleOut;
        public List<int> NeededDartsToFinishSingleOut;
        public List<double> averages;
        public List<double> averagesSingleOut;

        /// <summary>
        /// Standartkonstruktor der Klasse PlayerSave
        /// </summary>
        public PlayerSave()
        {

        }

        /// <summary>
        /// Konstruktor der Klasse PlayerSave
        /// </summary>
        /// <param name="name">Name des Spielers</param>
        public PlayerSave(string name)
        {
            this.Name = name;
            this.GamesPlayed = 0;
            this.GamesPlayedSingle = 0;
            this.Wins = 0;
            this.WinsSingle = 0;
            this.Looses = 0;
            this.LoosesSingle = 0;
            this.Average = 0;
            this.AverageSingleOut = 0;
            this.ThrownDarts = 0;
            this.PointsScored = 0;
            this.AverageNeededDartsToFinishDoubleOut = 0;
            this.AverageNeededDartsToFinishSingleOut = 0;
            this.AverageDoubleOutRate = 0;
            this.OneHundredEighty = 0;
            this.Checkout100 = 0;
            this.HighestFinish = 0;
            this.BestLegDarts = 0;
            this.BestLegDartsSingle = 0;
            this.DoubleBull = 0;
            this.SingleBull = 0;
            this.Triple = 0;
            this.Double = 0;
            this.Misses = 0;
            this.DoubleOutRate = new List<double>();
            this.NeededDartsToFinishDoubleOut = new List<int>();
            this.NeededDartsToFinishSingleOut = new List<int>();
            this.averages = new List<double>();
            this.averagesSingleOut = new List<double>();
        }

        /// <summary>
        /// Gibt Namen eines gespeicherten Spielers zurück
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
