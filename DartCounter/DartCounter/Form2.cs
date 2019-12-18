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
    public partial class Form2 : Form
    {
        Form1 f1;
        Game g;

        /// <summary>
        /// Konstruktor der Klasse Form2 (Spielfenster)
        /// </summary>
        /// <param name="player">Spielername</param>
        /// <param name="startPoints">Startpunkte</param>
        /// <param name="doubleOut">Spielmodus</param>
        /// <param name="player1">Name des 1.Spielers</param>
        /// <param name="f1">Form1 (Objekt)</param>
        public Form2(int player, int startPoints, bool doubleOut, string player1, Form1 f1)
        {
            InitializeComponent();
            label_Player1Name.Text = player1;
            this.f1 = f1;
            string[] names = new string[1] {player1};
            g = new Game(player, startPoints, doubleOut, names);
            UpdateScreen(false);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Konstruktor der Klasse Form2 (Spielfenster)
        /// </summary>
        /// <param name="player">Spielername</param>
        /// <param name="startPoints">Startpunkte</param>
        /// <param name="doubleOut">Spielmodus</param>
        /// <param name="player1">Name des 1.Spielers</param>
        /// <param name="player2">Name des 2.Spielers</param>
        /// <param name="f1">Form1 (Objekt)</param>
        public Form2(int player, int startPoints, bool doubleOut, string player1, string player2, Form1 f1)
        {
            InitializeComponent();
            panel_Player2.Visible = true;
            label_Player1Name.Text = player1;
            label_Player2Name.Text = player2;
            this.f1 = f1;
            string[] names = new string[2] {player1, player2};
            g = new Game(player, startPoints, doubleOut, names);
            for (int i = 0; i < player; i++)
            {
                UpdateScreen(false);
                g.NextPlayer();
            }
            UpdateScreen(false);
        }

        /// <summary>
        /// Konstruktor der Klasse Form2 (Spielfenster)
        /// </summary>
        /// <param name="player">Spielername</param>
        /// <param name="startPoints">Startpunkte</param>
        /// <param name="doubleOut">Spielmodus</param>
        /// <param name="player1">Name des 1.Spielers</param>
        /// <param name="player2">Name des 2.Spielers</param>
        /// <param name="player3">Name des 3.Spielers</param>
        /// <param name="f1">Form1 (Objekt)</param>
        public Form2(int player, int startPoints, bool doubleOut, string player1, string player2, string player3, Form1 f1)
        {
            InitializeComponent();
            panel_Player2.Visible = true;
            panel_Player3.Visible = true;
            label_Player1Name.Text = player1;
            label_Player2Name.Text = player2;
            label_Player3Name.Text = player3;
            this.f1 = f1;
            string[] names = new string[3] {player1, player2, player3};
            g = new Game(player, startPoints, doubleOut, names);
            for (int i = 0; i < player; i++)
            {
                UpdateScreen(false);
                g.NextPlayer();
            }
            UpdateScreen(false);
        }

        /// <summary>
        /// Konstruktor der Klasse Form2 (Spielfenster)
        /// </summary>
        /// <param name="player">Spielername</param>
        /// <param name="startPoints">Startpunkte</param>
        /// <param name="doubleOut">Spielmodus</param>
        /// <param name="player1">Name des 1.Spielers</param>
        /// <param name="player2">Name des 2.Spielers</param>
        /// <param name="player3">Name des 3.Spielers</param>
        /// <param name="player4">Name des 4.Spielers</param>
        /// <param name="f1">Form1 (Objekt)</param>
        public Form2(int player, int startPoints, bool doubleOut, string player1, string player2, string player3, string player4, Form1 f1)
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
            string[] names = new string[4] {player1, player2, player3, player4};
            g = new Game(player, startPoints, doubleOut, names);
            for (int i = 0; i < player; i++)
            {
                UpdateScreen(false);
                g.NextPlayer();
            }
            UpdateScreen(false);
        }

        /// <summary>
        /// Enumeration der möglichen Feldertypen die getroffen werden können
        /// </summary>
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

            int Score = GetScore(posX, posY);
            if (GetRing(posX, posY) == enumRingType.DoubleBull)
            {
                g.HandleThrow(Score, true, 5);
            }
            else if (GetRing(posX, posY) == enumRingType.SingleBull)
            {
                g.HandleThrow(Score, false, 4);
            }
            else if (GetRing(posX, posY) == enumRingType.Triple)
            {
                g.HandleThrow(Score, false, 3);
            }
            else if (GetRing(posX, posY) == enumRingType.Double)
            {
                g.HandleThrow(Score, true, 2);
            }
            else if (GetRing(posX, posY) == enumRingType.Single)
            {
                g.HandleThrow(Score, false, 1);
            }
            else
            {
                g.HandleThrow(Score, false, 0);
            }
            bool win = g.players[g.ActivePlayer].Win();
            if (win)
            {
                g.WriteStatistics(f1.statistics);
                f1.statistics.SerializeCollection();
            }
            UpdateScreen(win);
            if (g.players[g.ActivePlayer].ThrowsLeft == 0)
            {
                g.NextPlayer();
            }
            UpdateScreen(false);
        }

        /// <summary>
        /// Macht den aktuellen Wurf (komplette Aufnahme) rückgängig
        /// </summary>
        private void button_Player1Undo_Click(object sender, EventArgs e)
        {
            g.players[0].Undo = false;
            g.ActivePlayer = 0;
            g.Undo();
            UpdateScreen(false);
        }

        /// <summary>
        /// Macht den aktuellen Wurf (komplette Aufnahme) rückgängig
        /// </summary>
        private void button_Player2Undo_Click(object sender, EventArgs e)
        {
            g.players[1].Undo = false;
            g.ActivePlayer = 1;
            g.Undo();
            UpdateScreen(false);
        }

        /// <summary>
        /// Macht den aktuellen Wurf (komplette Aufnahme) rückgängig
        /// </summary>
        private void button_Player3Undo_Click(object sender, EventArgs e)
        {
            g.players[2].Undo = false;
            g.ActivePlayer = 2;
            g.Undo();
            UpdateScreen(false);
        }

        /// <summary>
        /// Macht den aktuellen Wurf (komplette Aufnahme) rückgängig
        /// </summary>
        private void button_Player4Undo_Click(object sender, EventArgs e)
        {
            g.players[3].Undo = false;
            g.ActivePlayer = 3;
            g.Undo();
            UpdateScreen(false);
        }

        /// <summary>
        /// Aktualisiert die Spieloberfläche
        /// </summary>
        /// <param name="win"></param>
        private void UpdateScreen(bool win)
        {
            switch(g.ActivePlayer)
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
                    button_Player1Undo.Visible = g.players[0].Undo;
                    label_Player1Name.Text = g.players[0].Name;
                    label_Player1Points.Text = g.players[0].Points.ToString();
                    label_Player1LastThrow.Text = g.players[0].LastThrow;
                    label_Player1Average.Text = g.players[0].Average.ToString();
                    label_Player1DartsThrown.Text = g.players[0].throws.Count.ToString();
                    if (g.players[0].Points <= 170)
                    {
                        label_Player1CheckoutText.Visible = true;
                        label_Player1Checkout.Visible = true;
                        label_Player1Checkout.Text = g.GetCheckout();
                    }
                    else
                    {
                        label_Player1CheckoutText.Visible = false;
                        label_Player1Checkout.Visible = false;
                    }
                    if (g.players[0].ThrowsLeft == 3)
                    {
                        pictureBox_p1d1.Visible = true;
                        pictureBox_p1d2.Visible = true;
                        pictureBox_p1d3.Visible = true;
                    }
                    else if (g.players[0].ThrowsLeft == 2)
                    {
                        pictureBox_p1d1.Visible = true;
                        pictureBox_p1d2.Visible = true;
                        pictureBox_p1d3.Visible = false;
                        for (int i = 0; i < g.PlayerAmount; i++)
                        {
                            if (i != g.ActivePlayer)
                            {
                                g.players[i].Undo = false;
                            }
                        }
                        button_Player2Undo.Visible = false;
                        button_Player3Undo.Visible = false;
                        button_Player4Undo.Visible = false;
                    }
                    else if (g.players[0].ThrowsLeft == 1)
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
                    if (win)
                    {
                        label_Player1Win.Visible = true;
                        MessageBox.Show(string.Format("{0} hat gewonnen!", g.players[0].Name));
                        this.Close();
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
                    button_Player2Undo.Visible = g.players[1].Undo;
                    label_Player2Name.Text = g.players[1].Name;
                    label_Player2Points.Text = g.players[1].Points.ToString();
                    label_Player2LastThrow.Text = g.players[1].LastThrow;
                    label_Player2Average.Text = g.players[1].Average.ToString();
                    label_Player2DartsThrown.Text = g.players[1].throws.Count.ToString();
                    if (g.players[1].Points <= 170)
                    {
                        label_Player2CheckoutText.Visible = true;
                        label_Player2Checkout.Visible = true;
                        label_Player2Checkout.Text = g.GetCheckout();
                    }
                    else
                    {
                        label_Player2CheckoutText.Visible = false;
                        label_Player2Checkout.Visible = false;
                    }
                    if (g.players[1].ThrowsLeft == 3)
                    {
                        pictureBox_p2d1.Visible = true;
                        pictureBox_p2d2.Visible = true;
                        pictureBox_p2d3.Visible = true;
                    }
                    else if (g.players[1].ThrowsLeft == 2)
                    {
                        pictureBox_p2d1.Visible = true;
                        pictureBox_p2d2.Visible = true;
                        pictureBox_p2d3.Visible = false;
                        for (int i = 0; i < g.PlayerAmount; i++)
                        {
                            if (i != g.ActivePlayer)
                            {
                                g.players[i].Undo = false;
                            }
                        }
                        button_Player1Undo.Visible = false;
                        button_Player3Undo.Visible = false;
                        button_Player4Undo.Visible = false;
                    }
                    else if (g.players[1].ThrowsLeft == 1)
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
                    if (win)
                    {
                        label_Player2Win.Visible = true;
                        MessageBox.Show(string.Format("{0} hat gewonnen!", g.players[1].Name));
                        this.Close();
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
                    button_Player3Undo.Visible = g.players[2].Undo;
                    label_Player3Name.Text = g.players[2].Name;
                    label_Player3Points.Text = g.players[2].Points.ToString();
                    label_Player3LastThrow.Text = g.players[2].LastThrow;
                    label_Player3Average.Text = g.players[2].Average.ToString();
                    label_Player3DartsThrown.Text = g.players[2].throws.Count.ToString();
                    if (g.players[2].Points <= 170)
                    {
                        label_Player3CheckoutText.Visible = true;
                        label_Player3Checkout.Visible = true;
                        label_Player3Checkout.Text = g.GetCheckout();
                    }
                    else
                    {
                        label_Player3CheckoutText.Visible = false;
                        label_Player3Checkout.Visible = false;
                    }
                    if (g.players[2].ThrowsLeft == 3)
                    {
                        pictureBox_p3d1.Visible = true;
                        pictureBox_p3d2.Visible = true;
                        pictureBox_p3d3.Visible = true;
                    }
                    else if (g.players[2].ThrowsLeft == 2)
                    {
                        pictureBox_p3d1.Visible = true;
                        pictureBox_p3d2.Visible = true;
                        pictureBox_p3d3.Visible = false;
                        for (int i = 0; i < g.PlayerAmount; i++)
                        {
                            if (i != g.ActivePlayer)
                            {
                                g.players[i].Undo = false;
                            }
                        }
                        button_Player1Undo.Visible = false;
                        button_Player2Undo.Visible = false;
                        button_Player4Undo.Visible = false;
                    }
                    else if (g.players[2].ThrowsLeft == 1)
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
                    if (win)
                    {
                        label_Player3Win.Visible = true;
                        MessageBox.Show(string.Format("{0} hat gewonnen!", g.players[2].Name));
                        this.Close();
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
                    button_Player4Undo.Visible = g.players[3].Undo;
                    label_Player4Name.Text = g.players[3].Name;
                    label_Player4Points.Text = g.players[3].Points.ToString();
                    label_Player4LastThrow.Text = g.players[3].LastThrow;
                    label_Player4Average.Text = g.players[3].Average.ToString();
                    label_Player4DartsThrown.Text = g.players[3].throws.Count.ToString();
                    if (g.players[3].Points <= 170)
                    {
                        label_Player4CheckoutText.Visible = true;
                        label_Player4Checkout.Visible = true;
                        label_Player4Checkout.Text = g.GetCheckout();
                    }
                    else
                    {
                        label_Player4CheckoutText.Visible = false;
                        label_Player4Checkout.Visible = false;
                    }
                    if (g.players[3].ThrowsLeft == 3)
                    {
                        pictureBox_p4d1.Visible = true;
                        pictureBox_p4d2.Visible = true;
                        pictureBox_p4d3.Visible = true;
                    }
                    else if (g.players[3].ThrowsLeft == 2)
                    {
                        pictureBox_p4d1.Visible = true;
                        pictureBox_p4d2.Visible = true;
                        pictureBox_p4d3.Visible = false;
                        for (int i = 0; i < g.PlayerAmount; i++)
                        {
                            if (i != g.ActivePlayer)
                            {
                                g.players[i].Undo = false;
                            }
                        }
                        button_Player1Undo.Visible = false;
                        button_Player2Undo.Visible = false;
                        button_Player3Undo.Visible = false;
                    }
                    else if (g.players[3].ThrowsLeft == 1)
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
                    if (win)
                    {
                        label_Player4Win.Visible = true;
                        MessageBox.Show(string.Format("{0} hat gewonnen!", g.players[3].Name));
                        this.Close();
                    }
                    break;
            }
        }

        /// <summary>
        /// Berechnet die geworfene Punktzahl des aktuellen Wurfes anhand der getroffenen Zahl und dem getroffenen Feld.
        /// </summary>
        /// <param name="posX">X-Position der Maus</param>
        /// <param name="posY">Y-Position der Maus</param>
        /// <returns></returns>
        private int GetScore(int posX, int posY)
        {
            int score = 0;

            double winkelInRad = Math.Atan2(posY, posX);
            double winkelInGrad = winkelInRad * 180 / Math.PI;
            int winkel = (int)winkelInGrad;
            if (winkel < 0)
            {
                winkel = 180 + (winkel + 180);
            }
            int points = GetPoints(winkel);
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
        private int GetPoints(int winkel)
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
        /// Ruft das Hauptmenü wieder auf wenn das aktuelle Spiel beendet wurde
        /// </summary>
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Show();
        }
    }
}
