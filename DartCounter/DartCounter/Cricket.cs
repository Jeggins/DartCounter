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
    public partial class Cricket : Form
    {
        Form1 f1;
        CricketGame cg;

        string threeDots = "⚫ ⚫ ⚫";
        string twoDots = "⚫ ⚫";
        string oneDot = "⚫";

        bool win = false;
        int winner;

        public Cricket(int player, int startPoints, string player1, string player2, Form1 f1)
        {
            InitializeComponent();
            panel_Player2.Visible = true;
            label_Player1Name.Text = player1;
            label_Player2Name.Text = player2;
            this.f1 = f1;
            string[] names = new string[2] { player1, player2 };
            cg = new CricketGame(player, startPoints, names);
            for (int i = 0; i < player; i++)
            {
                UpdateScreen(false);
                cg.NextPlayer();
            }
            UpdateScreen(false);
        }

        public Cricket(int player, int startPoints, string player1, string player2, string player3, Form1 f1)
        {
            InitializeComponent();
            panel_Player2.Visible = true;
            panel_Player3.Visible = true;
            label_Player1Name.Text = player1;
            label_Player2Name.Text = player2;
            label_Player3Name.Text = player3;
            this.f1 = f1;
            string[] names = new string[3] { player1, player2, player3 };
            cg = new CricketGame(player, startPoints, names);
            for (int i = 0; i < player; i++)
            {
                UpdateScreen(false);
                cg.NextPlayer();
            }
            UpdateScreen(false);
        }

        public Cricket(int player, int startPoints, string player1, string player2, string player3, string player4, Form1 f1)
        {
            InitializeComponent();
            panel_Player2.Visible = true;
            panel_Player3.Visible = true;
            panel_Player4.Visible = true;
            label_Player1Name.Text = player1;
            label_Player2Name.Text = player2;
            label_Player3Name.Text = player3;
            label_Player4Name.Text = player4;
            this.f1 = f1;
            string[] names = new string[4] { player1, player2, player3, player4 };
            cg = new CricketGame(player, startPoints, names);
            for (int i = 0; i < player; i++)
            {
                UpdateScreen(false);
                cg.NextPlayer();
            }
            UpdateScreen(false);
        }

        private enum enumRingType
        {
            None = 0,
            Single,
            Double,
            Triple,
            SingleBull,
            DoubleBull
        }

        /// <summary>
        /// Ermittelt nach Mausklick auf die Dartscheibe das getroffene Feld und die Punktzahl des Wurfs.
        /// Aktualisiert anschließend das GUI
        /// </summary>
        private void pictureBox_Dart_MouseUp(object sender, MouseEventArgs e)
        {
            int posX = (e.X - (pictureBox_Dart.Width / 2));
            int posY = ((pictureBox_Dart.Height / 2) - e.Y);

            int angle = getAngle(posX, posY);
            int zone = GetZone(angle);
            int Score = GetScore(angle, posX, posY);
            if (GetRing(posX, posY) == enumRingType.DoubleBull)
            {
                cg.HandleThrow(Score, 25, 5);
            }
            else if (GetRing(posX, posY) == enumRingType.SingleBull)
            {
                cg.HandleThrow(Score, 25, 4);
            }
            else if (GetRing(posX, posY) == enumRingType.Triple)
            {
                cg.HandleThrow(Score, zone, 3);
            }
            else if (GetRing(posX, posY) == enumRingType.Double)
            {
                cg.HandleThrow(Score, zone, 2);
            }
            else if (GetRing(posX, posY) == enumRingType.Single)
            {
                cg.HandleThrow(Score, zone, 1);
            }
            else
            {
                cg.HandleThrow(Score, 0, 0);
            }

            win = cg.CheckForWin();
            if (win)
            {
                winner = cg.players.FindIndex(x => x.Name == cg.Winner);
            }
            UpdateScreen(win);
            if (cg.players[cg.ActivePlayer].ThrowsLeft == 0)
            {
                cg.NextPlayer();
            }
            UpdateScreen(false);
        }

        /// <summary>
        /// Berechnet den Winkel der geklickten Mausposition in Abhängigkeit zum Mittelpunkt der Dartscheibe
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <returns></returns>
        private int getAngle(int posX, int posY)
        {
            double winkelInRad = Math.Atan2(posY, posX);
            double winkelInGrad = winkelInRad * 180 / Math.PI;
            int winkel = (int)winkelInGrad;
            if (winkel < 0)
            {
                winkel = 180 + (winkel + 180);
            }
            return winkel;
        }

        /// <summary>
        /// Berechnet die geworfene Punktzahl des aktuellen Wurfes anhand der getroffenen Zahl und dem getroffenen Feld.
        /// </summary>
        /// <param name="posX">X-Position der Maus</param>
        /// <param name="posY">Y-Position der Maus</param>
        /// <returns></returns>
        private int GetScore(int angle, int posX, int posY)
        {
            int score = 0;

            
            int points = GetZone(angle);
            enumRingType Ring = GetRing(posX, posY);

            switch (Ring)
            {
                case enumRingType.None:
                    score = 0;
                    break;
                case enumRingType.Single:
                    score = points;
                    break;
                case enumRingType.Double:
                    score = points * 2;
                    break;
                case enumRingType.Triple:
                    score = points * 3;
                    break;
                case enumRingType.SingleBull:
                    score = 25;
                    break;
                case enumRingType.DoubleBull:
                    score = 50;
                    break;
            }
            return score;
        }

        /// <summary>
        /// Berechnet die Zahl die man getroffen hat anhand des Winkels der Mausposition ausgehend vom Mittelpunkt der Dartscheibe
        /// </summary>
        /// <param name="winkel">Winkel der Mausposition ausgehen vom Mittelpunkt der Dartscheibe</param>
        /// <returns></returns>
        private int GetZone(int winkel)
        {
            if (winkel >= 351) return 6;
            if (winkel >= 333) return 10;
            if (winkel >= 315) return 15;
            if (winkel >= 297) return 2;
            if (winkel >= 279) return 17;
            if (winkel >= 261) return 3;
            if (winkel >= 243) return 19;
            if (winkel >= 225) return 7;
            if (winkel >= 207) return 16;
            if (winkel >= 189) return 8;
            if (winkel >= 171) return 11;
            if (winkel >= 153) return 14;
            if (winkel >= 135) return 9;
            if (winkel >= 117) return 12;
            if (winkel >= 99) return 5;
            if (winkel >= 81) return 20;
            if (winkel >= 63) return 1;
            if (winkel >= 45) return 18;
            if (winkel >= 27) return 4;
            if (winkel >= 9) return 13;
            return 6;
        }

        /// <summary>
        /// Berechner das Feld das man getroffen hat anhand der Entfernung des Mauszeigers zum Mittelpunkt der Dartscheibe
        /// </summary>
        /// <param name="posX">X-Position der Maus</param>
        /// <param name="posY">Y-Position der Maus</param>
        /// <returns></returns>
        private enumRingType GetRing(int posX, int posY)
        {
            double doubleLength = Math.Sqrt(posX * posX + posY * posY);
            int length = (int)Math.Floor(doubleLength);
            int imageSize = GetImageSize() / 2;

            if (length > imageSize * 0.74585) return enumRingType.None;
            if (length <= imageSize * 0.02762) return enumRingType.DoubleBull;
            if (length > imageSize * 0.02762 && length <= imageSize * 0.07182) return enumRingType.SingleBull;
            if (length > imageSize * 0.42817 && length <= imageSize * 0.46961) return enumRingType.Triple;
            if (length > imageSize * 0.70441 && length <= imageSize * 0.74585) return enumRingType.Double;
            return enumRingType.Single;
        }

        /// <summary>
        /// Gibt die größe des Dartbildes zurück (kleinerer Wert wird zurück gegeben)
        /// </summary>
        /// <returns>Bildgröße</returns>
        private int GetImageSize()
        {
            if (pictureBox_Dart.Width > pictureBox_Dart.Height)
            {
                return pictureBox_Dart.Height;
            }
            else
            {
                return pictureBox_Dart.Width;
            }
        }

        /// <summary>
        /// Aktualisiert die Spieloberfläche
        /// </summary>
        /// <param name="win"></param>
        private void UpdateScreen(bool win)
        {
            switch (cg.ActivePlayer)
            {
                case 0:
                    panel_Player1.BackColor = Color.GreenYellow;
                    panel_Player2.BackColor = SystemColors.Control;
                    panel_Player3.BackColor = SystemColors.Control;
                    panel_Player4.BackColor = SystemColors.Control;
                    pictureBox_p1d1.Visible = true;
                    pictureBox_p1d2.Visible = true;
                    pictureBox_p1d3.Visible = true;
                    pictureBox_p2d1.Visible = false;
                    pictureBox_p2d2.Visible = false;
                    pictureBox_p2d3.Visible = false;
                    pictureBox_p3d1.Visible = false;
                    pictureBox_p3d2.Visible = false;
                    pictureBox_p3d3.Visible = false;
                    pictureBox_p4d1.Visible = false;
                    pictureBox_p4d2.Visible = false;
                    pictureBox_p4d3.Visible = false;
                    button_Player1Undo.Visible = cg.players[0].Undo;
                    label_Player1Name.Text = cg.players[0].Name;
                    label_Player1Points.Text = cg.players[0].Points.ToString();
                    if (cg.players[0].ThrowsLeft == 3)
                    {
                        pictureBox_p1d1.Visible = true;
                        pictureBox_p1d2.Visible = true;
                        pictureBox_p1d3.Visible = true;
                    }
                    else if (cg.players[0].ThrowsLeft == 2)
                    {
                        pictureBox_p1d1.Visible = true;
                        pictureBox_p1d2.Visible = true;
                        pictureBox_p1d3.Visible = false;
                        for (int i = 0; i < cg.PlayerAmount; i++)
                        {
                            if (i != cg.ActivePlayer)
                            {
                                cg.players[i].Undo = false;
                            }
                        }
                        button_Player2Undo.Visible = false;
                        button_Player3Undo.Visible = false;
                        button_Player4Undo.Visible = false;
                    }
                    else if (cg.players[0].ThrowsLeft == 1)
                    {
                        pictureBox_p1d1.Visible = true;
                        pictureBox_p1d2.Visible = false;
                        pictureBox_p1d3.Visible = false;
                    }
                    else
                    {
                        pictureBox_p1d1.Visible = false;
                        pictureBox_p1d2.Visible = false;
                        pictureBox_p1d3.Visible = false;
                    }

                    //Dots for Innings
                    if (cg.players[0].Fifteen == 3)
                    {
                        label_p1_15_dots.Text = threeDots;
                    }
                    else if (cg.players[0].Fifteen == 2)
                    {
                        label_p1_15_dots.Text = twoDots;
                    }
                    else if (cg.players[0].Fifteen == 1)
                    {
                        label_p1_15_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p1_15_dots.Text = "";
                    }
                    if (cg.players[0].Sixteen == 3)
                    {
                        label_p1_16_dots.Text = threeDots;
                    }
                    else if (cg.players[0].Sixteen == 2)
                    {
                        label_p1_16_dots.Text = twoDots;
                    }
                    else if (cg.players[0].Sixteen == 1)
                    {
                        label_p1_16_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p1_16_dots.Text = "";
                    }
                    if (cg.players[0].Seventeen == 3)
                    {
                        label_p1_17_dots.Text = threeDots;
                    }
                    else if (cg.players[0].Seventeen == 2)
                    {
                        label_p1_17_dots.Text = twoDots;
                    }
                    else if (cg.players[0].Seventeen == 1)
                    {
                        label_p1_17_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p1_17_dots.Text = "";
                    }
                    if (cg.players[0].Eighteen == 3)
                    {
                        label_p1_18_dots.Text = threeDots;
                    }
                    else if (cg.players[0].Eighteen == 2)
                    {
                        label_p1_18_dots.Text = twoDots;
                    }
                    else if (cg.players[0].Eighteen == 1)
                    {
                        label_p1_18_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p1_18_dots.Text = "";
                    }
                    if (cg.players[0].Nineteen == 3)
                    {
                        label_p1_19_dots.Text = threeDots;
                    }
                    else if (cg.players[0].Nineteen == 2)
                    {
                        label_p1_19_dots.Text = twoDots;
                    }
                    else if (cg.players[0].Nineteen == 1)
                    {
                        label_p1_19_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p1_19_dots.Text = "";
                    }
                    if (cg.players[0].Twenty == 3)
                    {
                        label_p1_20_dots.Text = threeDots;
                    }
                    else if (cg.players[0].Twenty == 2)
                    {
                        label_p1_20_dots.Text = twoDots;
                    }
                    else if (cg.players[0].Twenty == 1)
                    {
                        label_p1_20_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p1_20_dots.Text = "";
                    }
                    if (cg.players[0].Bull == 3)
                    {
                        label_p1_bull_dots.Text = threeDots;
                    }
                    else if (cg.players[0].Bull == 2)
                    {
                        label_p1_bull_dots.Text = twoDots;
                    }
                    else if (cg.players[0].Bull == 1)
                    {
                        label_p1_bull_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p1_bull_dots.Text = "";
                    }
                    break;
                case 1:
                    panel_Player1.BackColor = SystemColors.Control;
                    panel_Player2.BackColor = Color.GreenYellow;
                    panel_Player3.BackColor = SystemColors.Control;
                    panel_Player4.BackColor = SystemColors.Control;
                    pictureBox_p1d1.Visible = false;
                    pictureBox_p1d2.Visible = false;
                    pictureBox_p1d3.Visible = false;
                    pictureBox_p2d1.Visible = true;
                    pictureBox_p2d2.Visible = true;
                    pictureBox_p2d3.Visible = true;
                    pictureBox_p3d1.Visible = false;
                    pictureBox_p3d2.Visible = false;
                    pictureBox_p3d3.Visible = false;
                    pictureBox_p4d1.Visible = false;
                    pictureBox_p4d2.Visible = false;
                    pictureBox_p4d3.Visible = false;
                    button_Player2Undo.Visible = cg.players[1].Undo;
                    label_Player2Name.Text = cg.players[1].Name;
                    label_Player2Points.Text = cg.players[1].Points.ToString();
                    if (cg.players[1].ThrowsLeft == 3)
                    {
                        pictureBox_p2d1.Visible = true;
                        pictureBox_p2d2.Visible = true;
                        pictureBox_p2d3.Visible = true;
                    }
                    else if (cg.players[1].ThrowsLeft == 2)
                    {
                        pictureBox_p2d1.Visible = true;
                        pictureBox_p2d2.Visible = true;
                        pictureBox_p2d3.Visible = false;
                        for (int i = 0; i < cg.PlayerAmount; i++)
                        {
                            if (i != cg.ActivePlayer)
                            {
                                cg.players[i].Undo = false;
                            }
                        }
                        button_Player1Undo.Visible = false;
                        button_Player3Undo.Visible = false;
                        button_Player4Undo.Visible = false;
                    }
                    else if (cg.players[1].ThrowsLeft == 1)
                    {
                        pictureBox_p2d1.Visible = true;
                        pictureBox_p2d2.Visible = false;
                        pictureBox_p2d3.Visible = false;
                    }
                    else
                    {
                        pictureBox_p2d1.Visible = false;
                        pictureBox_p2d2.Visible = false;
                        pictureBox_p2d3.Visible = false;
                    }
                    //Dots for Innings
                    if (cg.players[1].Fifteen == 3)
                    {
                        label_p2_15_dots.Text = threeDots;
                    }
                    else if (cg.players[1].Fifteen == 2)
                    {
                        label_p2_15_dots.Text = twoDots;
                    }
                    else if (cg.players[1].Fifteen == 1)
                    {
                        label_p2_15_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p2_15_dots.Text = "";
                    }
                    if (cg.players[1].Sixteen == 3)
                    {
                        label_p2_16_dots.Text = threeDots;
                    }
                    else if (cg.players[1].Sixteen == 2)
                    {
                        label_p2_16_dots.Text = twoDots;
                    }
                    else if (cg.players[1].Sixteen == 1)
                    {
                        label_p2_16_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p2_16_dots.Text = "";
                    }
                    if (cg.players[1].Seventeen == 3)
                    {
                        label_p2_17_dots.Text = threeDots;
                    }
                    else if (cg.players[1].Seventeen == 2)
                    {
                        label_p2_17_dots.Text = twoDots;
                    }
                    else if (cg.players[1].Seventeen == 1)
                    {
                        label_p2_17_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p2_17_dots.Text = "";
                    }
                    if (cg.players[1].Eighteen == 3)
                    {
                        label_p2_18_dots.Text = threeDots;
                    }
                    else if (cg.players[1].Eighteen == 2)
                    {
                        label_p2_18_dots.Text = twoDots;
                    }
                    else if (cg.players[1].Eighteen == 1)
                    {
                        label_p2_18_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p2_18_dots.Text = "";
                    }
                    if (cg.players[1].Nineteen == 3)
                    {
                        label_p2_19_dots.Text = threeDots;
                    }
                    else if (cg.players[1].Nineteen == 2)
                    {
                        label_p2_19_dots.Text = twoDots;
                    }
                    else if (cg.players[1].Nineteen == 1)
                    {
                        label_p2_19_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p2_19_dots.Text = "";
                    }
                    if (cg.players[1].Twenty == 3)
                    {
                        label_p2_20_dots.Text = threeDots;
                    }
                    else if (cg.players[1].Twenty == 2)
                    {
                        label_p2_20_dots.Text = twoDots;
                    }
                    else if (cg.players[1].Twenty == 1)
                    {
                        label_p2_20_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p2_20_dots.Text = "";
                    }
                    if (cg.players[1].Bull == 3)
                    {
                        label_p2_bull_dots.Text = threeDots;
                    }
                    else if (cg.players[1].Bull == 2)
                    {
                        label_p2_bull_dots.Text = twoDots;
                    }
                    else if (cg.players[1].Bull == 1)
                    {
                        label_p2_bull_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p2_bull_dots.Text = "";
                    }
                    break;
                case 2:
                    panel_Player1.BackColor = SystemColors.Control;
                    panel_Player2.BackColor = SystemColors.Control;
                    panel_Player3.BackColor = Color.GreenYellow;
                    panel_Player4.BackColor = SystemColors.Control;
                    pictureBox_p1d1.Visible = false;
                    pictureBox_p1d2.Visible = false;
                    pictureBox_p1d3.Visible = false;
                    pictureBox_p2d1.Visible = false;
                    pictureBox_p2d2.Visible = false;
                    pictureBox_p2d3.Visible = false;
                    pictureBox_p3d1.Visible = true;
                    pictureBox_p3d2.Visible = true;
                    pictureBox_p3d3.Visible = true;
                    pictureBox_p4d1.Visible = false;
                    pictureBox_p4d2.Visible = false;
                    pictureBox_p4d3.Visible = false;
                    button_Player3Undo.Visible = cg.players[2].Undo;
                    label_Player3Name.Text = cg.players[2].Name;
                    label_Player3Points.Text = cg.players[2].Points.ToString();
                    if (cg.players[2].ThrowsLeft == 3)
                    {
                        pictureBox_p3d1.Visible = true;
                        pictureBox_p3d2.Visible = true;
                        pictureBox_p3d3.Visible = true;
                    }
                    else if (cg.players[2].ThrowsLeft == 2)
                    {
                        pictureBox_p3d1.Visible = true;
                        pictureBox_p3d2.Visible = true;
                        pictureBox_p3d3.Visible = false;
                        for (int i = 0; i < cg.PlayerAmount; i++)
                        {
                            if (i != cg.ActivePlayer)
                            {
                                cg.players[i].Undo = false;
                            }
                        }
                        button_Player1Undo.Visible = false;
                        button_Player2Undo.Visible = false;
                        button_Player4Undo.Visible = false;
                    }
                    else if (cg.players[2].ThrowsLeft == 1)
                    {
                        pictureBox_p3d1.Visible = true;
                        pictureBox_p3d2.Visible = false;
                        pictureBox_p3d3.Visible = false;
                    }
                    else
                    {
                        pictureBox_p3d1.Visible = false;
                        pictureBox_p3d2.Visible = false;
                        pictureBox_p3d3.Visible = false;
                    }
                    //Dots for Innings
                    if (cg.players[2].Fifteen == 3)
                    {
                        label_p3_15_dots.Text = threeDots;
                    }
                    else if (cg.players[2].Fifteen == 2)
                    {
                        label_p3_15_dots.Text = twoDots;
                    }
                    else if (cg.players[2].Fifteen == 1)
                    {
                        label_p3_15_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p3_15_dots.Text = "";
                    }
                    if (cg.players[2].Sixteen == 3)
                    {
                        label_p3_16_dots.Text = threeDots;
                    }
                    else if (cg.players[2].Sixteen == 2)
                    {
                        label_p3_16_dots.Text = twoDots;
                    }
                    else if (cg.players[2].Sixteen == 1)
                    {
                        label_p3_16_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p3_16_dots.Text = "";
                    }
                    if (cg.players[2].Seventeen == 3)
                    {
                        label_p3_17_dots.Text = threeDots;
                    }
                    else if (cg.players[2].Seventeen == 2)
                    {
                        label_p3_17_dots.Text = twoDots;
                    }
                    else if (cg.players[2].Seventeen == 1)
                    {
                        label_p3_17_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p3_17_dots.Text = "";
                    }
                    if (cg.players[2].Eighteen == 3)
                    {
                        label_p3_18_dots.Text = threeDots;
                    }
                    else if (cg.players[2].Eighteen == 2)
                    {
                        label_p3_18_dots.Text = twoDots;
                    }
                    else if (cg.players[2].Eighteen == 1)
                    {
                        label_p3_18_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p3_18_dots.Text = "";
                    }
                    if (cg.players[2].Nineteen == 3)
                    {
                        label_p3_19_dots.Text = threeDots;
                    }
                    else if (cg.players[2].Nineteen == 2)
                    {
                        label_p3_19_dots.Text = twoDots;
                    }
                    else if (cg.players[2].Nineteen == 1)
                    {
                        label_p3_19_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p3_19_dots.Text = "";
                    }
                    if (cg.players[2].Twenty == 3)
                    {
                        label_p3_20_dots.Text = threeDots;
                    }
                    else if (cg.players[2].Twenty == 2)
                    {
                        label_p3_20_dots.Text = twoDots;
                    }
                    else if (cg.players[2].Twenty == 1)
                    {
                        label_p3_20_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p3_20_dots.Text = "";
                    }
                    if (cg.players[2].Bull == 3)
                    {
                        label_p3_bull_dots.Text = threeDots;
                    }
                    else if (cg.players[2].Bull == 2)
                    {
                        label_p3_bull_dots.Text = twoDots;
                    }
                    else if (cg.players[2].Bull == 1)
                    {
                        label_p3_bull_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p3_bull_dots.Text = "";
                    }
                    break;
                case 3:
                    panel_Player1.BackColor = SystemColors.Control;
                    panel_Player2.BackColor = SystemColors.Control;
                    panel_Player3.BackColor = SystemColors.Control;
                    panel_Player4.BackColor = Color.GreenYellow;
                    pictureBox_p1d1.Visible = false;
                    pictureBox_p1d2.Visible = false;
                    pictureBox_p1d3.Visible = false;
                    pictureBox_p2d1.Visible = false;
                    pictureBox_p2d2.Visible = false;
                    pictureBox_p2d3.Visible = false;
                    pictureBox_p3d1.Visible = false;
                    pictureBox_p3d2.Visible = false;
                    pictureBox_p3d3.Visible = false;
                    pictureBox_p4d1.Visible = true;
                    pictureBox_p4d2.Visible = true;
                    pictureBox_p4d3.Visible = true;
                    button_Player4Undo.Visible = cg.players[3].Undo;
                    label_Player4Name.Text = cg.players[3].Name;
                    label_Player4Points.Text = cg.players[3].Points.ToString();
                    if (cg.players[3].ThrowsLeft == 3)
                    {
                        pictureBox_p4d1.Visible = true;
                        pictureBox_p4d2.Visible = true;
                        pictureBox_p4d3.Visible = true;
                    }
                    else if (cg.players[3].ThrowsLeft == 2)
                    {
                        pictureBox_p4d1.Visible = true;
                        pictureBox_p4d2.Visible = true;
                        pictureBox_p4d3.Visible = false;
                        for (int i = 0; i < cg.PlayerAmount; i++)
                        {
                            if (i != cg.ActivePlayer)
                            {
                                cg.players[i].Undo = false;
                            }
                        }
                        button_Player1Undo.Visible = false;
                        button_Player2Undo.Visible = false;
                        button_Player3Undo.Visible = false;
                    }
                    else if (cg.players[3].ThrowsLeft == 1)
                    {
                        pictureBox_p4d1.Visible = true;
                        pictureBox_p4d2.Visible = false;
                        pictureBox_p4d3.Visible = false;
                    }
                    else
                    {
                        pictureBox_p4d1.Visible = false;
                        pictureBox_p4d2.Visible = false;
                        pictureBox_p4d3.Visible = false;
                    }
                    //Dots for Innings
                    if (cg.players[3].Fifteen == 3)
                    {
                        label_p4_15_dots.Text = threeDots;
                    }
                    else if (cg.players[3].Fifteen == 2)
                    {
                        label_p4_15_dots.Text = twoDots;
                    }
                    else if (cg.players[3].Fifteen == 1)
                    {
                        label_p4_15_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p4_15_dots.Text = "";
                    }
                    if (cg.players[3].Sixteen == 3)
                    {
                        label_p4_16_dots.Text = threeDots;
                    }
                    else if (cg.players[3].Sixteen == 2)
                    {
                        label_p4_16_dots.Text = twoDots;
                    }
                    else if (cg.players[3].Sixteen == 1)
                    {
                        label_p4_16_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p4_16_dots.Text = "";
                    }
                    if (cg.players[3].Seventeen == 3)
                    {
                        label_p4_17_dots.Text = threeDots;
                    }
                    else if (cg.players[3].Seventeen == 2)
                    {
                        label_p4_17_dots.Text = twoDots;
                    }
                    else if (cg.players[3].Seventeen == 1)
                    {
                        label_p4_17_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p4_17_dots.Text = "";
                    }
                    if (cg.players[3].Eighteen == 3)
                    {
                        label_p4_18_dots.Text = threeDots;
                    }
                    else if (cg.players[3].Eighteen == 2)
                    {
                        label_p4_18_dots.Text = twoDots;
                    }
                    else if (cg.players[3].Eighteen == 1)
                    {
                        label_p4_18_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p4_18_dots.Text = "";
                    }
                    if (cg.players[3].Nineteen == 3)
                    {
                        label_p4_19_dots.Text = threeDots;
                    }
                    else if (cg.players[3].Nineteen == 2)
                    {
                        label_p4_19_dots.Text = twoDots;
                    }
                    else if (cg.players[3].Nineteen == 1)
                    {
                        label_p4_19_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p4_19_dots.Text = "";
                    }
                    if (cg.players[3].Twenty == 3)
                    {
                        label_p4_20_dots.Text = threeDots;
                    }
                    else if (cg.players[3].Twenty == 2)
                    {
                        label_p4_20_dots.Text = twoDots;
                    }
                    else if (cg.players[3].Twenty == 1)
                    {
                        label_p4_20_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p4_20_dots.Text = "";
                    }
                    if (cg.players[3].Bull == 3)
                    {
                        label_p4_bull_dots.Text = threeDots;
                    }
                    else if (cg.players[3].Bull == 2)
                    {
                        label_p4_bull_dots.Text = twoDots;
                    }
                    else if (cg.players[3].Bull == 1)
                    {
                        label_p4_bull_dots.Text = oneDot;
                    }
                    else
                    {
                        label_p4_bull_dots.Text = "";
                    }
                    break;
            }
            //Winning
            if (win)
            {
                switch (winner)
                {
                    case 0:
                        label_Player1Win.Visible = true;
                        MessageBox.Show(string.Format("{0} hat gewonnen!", cg.players[winner].Name));
                        this.Close();
                        break;
                    case 1:
                        label_Player2Win.Visible = true;
                        MessageBox.Show(string.Format("{0} hat gewonnen!", cg.players[winner].Name));
                        this.Close();
                        break;
                    case 2:
                        label_Player3Win.Visible = true;
                        MessageBox.Show(string.Format("{0} hat gewonnen!", cg.players[winner].Name));
                        this.Close();
                        break;
                    case 3:
                        label_Player4Win.Visible = true;
                        MessageBox.Show(string.Format("{0} hat gewonnen!", cg.players[winner].Name));
                        this.Close();
                        break;
                }
            }
        }

        /// <summary>
        /// Macht den aktuellen Wurf (komplette Aufnahme) rückgängig
        /// </summary>
        private void button_Player1Undo_Click(object sender, EventArgs e)
        {
            cg.players[0].Undo = false;
            cg.ActivePlayer = 0;
            cg.Undo();
            UpdateScreen(false);
        }

        /// <summary>
        /// Macht den aktuellen Wurf (komplette Aufnahme) rückgängig
        /// </summary>
        private void button_Player2Undo_Click(object sender, EventArgs e)
        {
            cg.players[1].Undo = false;
            cg.ActivePlayer = 1;
            cg.Undo();
            UpdateScreen(false);
        }

        /// <summary>
        /// Macht den aktuellen Wurf (komplette Aufnahme) rückgängig
        /// </summary>
        private void button_Player3Undo_Click(object sender, EventArgs e)
        {
            cg.players[2].Undo = false;
            cg.ActivePlayer = 2;
            cg.Undo();
            UpdateScreen(false);
        }

        /// <summary>
        /// Macht den aktuellen Wurf (komplette Aufnahme) rückgängig
        /// </summary>
        private void button_Player4Undo_Click(object sender, EventArgs e)
        {
            cg.players[3].Undo = false;
            cg.ActivePlayer = 3;
            cg.Undo();
            UpdateScreen(false);
        }

        /// <summary>
        /// Ruft das Hauptmenü wieder auf wenn das aktuelle Spiel beendet wurde
        /// </summary>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Show();
        }

        private void Cricket_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
