using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DartCounter
{
    public partial class Form5 : Form
    {
        Statistic statistics;

        /// <summary>
        /// Konstruktor der Klasse Form5 (Statistik-Fenster)
        /// </summary>
        /// <param name="statistics">Liste der gespeicherten Spieler</param>
        public Form5(Statistic statistics)
        {
            InitializeComponent();
            this.statistics = statistics;
            FillComboBoxes();
            FillHighscoore();
        }

        /// <summary>
        /// Füllt die beiden ComboBoxen mit den Spielern
        /// </summary>
        private void FillComboBoxes()
        {
            foreach (PlayerSave p in statistics.player)
            {
                comboBox_P1.Items.Add(p);
                comboBox_P2.Items.Add(p);
            }
        }

        /// <summary>
        /// Listet die aktuellen Highscores auf
        /// </summary>
        private void FillHighscoore()
        {
            int i = 1;
            foreach (PlayerSave p in statistics.GetWinDoubleOutHighscore())
            {
                label_WinsDo.Text += string.Format("{0}. {1} ({2})\n", i, p.Name, p.Wins);
                i++;
            }
            i = 1;
            foreach (PlayerSave p in statistics.GetWinSingleOutHighscore())
            {
                label_WinsSo.Text += string.Format("{0}. {1} ({2})\n", i, p.Name, p.WinsSingle);
                i++;
            }
            i = 1;
            foreach (PlayerSave p in statistics.GetAverageHighscore())
            {
                label_Average.Text += string.Format("{0}. {1} ({2})\n", i, p.Name, p.Average);
                i++;
            }
            i = 1;
            foreach (PlayerSave p in statistics.GetAverageSingleOutHighscore())
            {
                label_AverageSO.Text += string.Format("{0}. {1} ({2})\n", i, p.Name, p.AverageSingleOut);
                i++;
            }
            i = 1;
            foreach (PlayerSave p in statistics.GetHighestFinishHighscore())
            {
                label_HighestFinish.Text += string.Format("{0}. {1} ({2})\n", i, p.Name, p.HighestFinish);
                i++;
            }
            i = 1;
            foreach (PlayerSave p in statistics.GetCheckout100Highscore())
            {
                label_Checkout100.Text += string.Format("{0}. {1} ({2})\n", i, p.Name, p.Checkout100);
                i++;
            }
            i = 1;
            foreach (PlayerSave p in statistics.GetDoubleOutRateHighscore())
            {
                label_DoubleOutRate.Text += string.Format("{0}. {1} ({2})\n", i, p.Name, p.AverageDoubleOutRate);
                i++;
            }
            i = 1;
            foreach (PlayerSave p in statistics.Get180Highscore())
            {
                label_108.Text += string.Format("{0}. {1} ({2})\n", i, p.Name, p.OneHundredEighty);
                i++;
            }
        }

        /// <summary>
        /// Füllt die linke Spalte mit den Daten des ausgewählten Spielers
        /// </summary>
        private void comboBox_P1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlayerSave p = null;
            foreach (PlayerSave t in statistics.player)
            {
                if (t.Name == comboBox_P1.Text)
                {
                    p = t;
                }
            }
            label_P1DoGames.Text = p.GamesPlayed.ToString();
            label_P1DoWin.Text = p.Wins.ToString();
            label_P1DoLoose.Text = p.Looses.ToString();
            label_P13DAverage.Text = p.Average.ToString();
            label_P1DoBestNeedetDarts.Text = p.BestLegDarts.ToString();
            label_P1DoAverageNeedetDarts.Text = p.AverageNeededDartsToFinishDoubleOut.ToString();
            if (p.AverageDoubleOutRate != 0)
            {
                label_P1DoubleOutRate.Text = p.AverageDoubleOutRate.ToString() + " %";
            }
            else
            {
                label_P1DoubleOutRate.Text = "0 %";
            }
            label_P1SoGames.Text = p.GamesPlayedSingle.ToString();
            label_P1SoWin.Text = p.WinsSingle.ToString();
            label_P1SoLoose.Text = p.LoosesSingle.ToString();
            label_P13DAverageSO.Text = p.AverageSingleOut.ToString();
            label_P1SoBestNeedetDarts.Text = p.BestLegDartsSingle.ToString();
            label_P1SoAverageNeedetDarts.Text = p.AverageNeededDartsToFinishSingleOut.ToString();
            label_P1DartsThrown.Text = p.ThrownDarts.ToString();
            label_P1PointsHit.Text = p.PointsScored.ToString();
            label_P1OneHundredEighty.Text = p.OneHundredEighty.ToString();
            label_P1Checkout100.Text = p.Checkout100.ToString();
            label_P1HighestFinish.Text = p.HighestFinish.ToString();
            label_P1DoubleBull.Text = p.DoubleBull.ToString();
            label_P1SingleBull.Text = p.SingleBull.ToString();
            label_P1Triple.Text = p.Triple.ToString();
            label_P1Double.Text = p.Double.ToString();
            label_P1Single.Text = p.Single.ToString();
            label_P1Miss.Text = p.Misses.ToString();
        }

        /// <summary>
        /// Füllt die rechte Spalte mit den Daten des ausgewählten Spielers
        /// </summary>
        private void comboBox_P2_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlayerSave p = null;
            foreach (PlayerSave t in statistics.player)
            {
                if (t.Name == comboBox_P2.Text)
                {
                    p = t;
                }
            }
            label_P2DoGames.Text = p.GamesPlayed.ToString();
            label_P2DoWin.Text = p.Wins.ToString();
            label_P2DoLoose.Text = p.Looses.ToString();
            label_P23DAverage.Text = p.Average.ToString();
            label_P2DoBestNeedetDarts.Text = p.BestLegDarts.ToString();
            label_P2DoAverageNeedetDarts.Text = p.AverageNeededDartsToFinishDoubleOut.ToString();
            if (p.AverageDoubleOutRate != 0)
            {
                label_P2DoubleOutRate.Text = p.AverageDoubleOutRate.ToString() + " %";
            }
            else
            {
                label_P2DoubleOutRate.Text = "0 %";
            }
            label_P2SoGames.Text = p.GamesPlayedSingle.ToString();
            label_P2SoWin.Text = p.WinsSingle.ToString();
            label_P2SoLoose.Text = p.LoosesSingle.ToString();
            label_P23DAverageSO.Text = p.AverageSingleOut.ToString();
            label_P2SoBestNeedetDarts.Text = p.BestLegDartsSingle.ToString();
            label_P2SoAverageNeedetDarts.Text = p.AverageNeededDartsToFinishSingleOut.ToString();
            label_P2DartsThrown.Text = p.ThrownDarts.ToString();
            label_P2PointsHit.Text = p.PointsScored.ToString();
            label_P2OneHundredEighty.Text = p.OneHundredEighty.ToString();
            label_P2Checkout100.Text = p.Checkout100.ToString();
            label_P2HighestFinish.Text = p.HighestFinish.ToString();
            label_P2DoubleBull.Text = p.DoubleBull.ToString();
            label_P2SingleBull.Text = p.SingleBull.ToString();
            label_P2Triple.Text = p.Triple.ToString();
            label_P2Double.Text = p.Double.ToString();
            label_P2Single.Text = p.Single.ToString();
            label_P2Miss.Text = p.Misses.ToString();
        }
    }
}
