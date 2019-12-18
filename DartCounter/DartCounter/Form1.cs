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
    public partial class Form1 : Form
    {
        int player = 1;
        int startPoints;
        bool doubleOut;
        Form2 f;
        Cricket c;
        public Statistic statistics;

        /// <summary>
        /// Konstruktor der Klasse Form1 (Hauptmenü)
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            startPoints = 501;
            doubleOut = true;
            statistics = new Statistic();
            for (int i = 0; i < statistics.player.Count; i++)
            {
                comboBox_Player1.Items.Add(statistics.player[i]);
                comboBox_Player2.Items.Add(statistics.player[i]);
                comboBox_Player3.Items.Add(statistics.player[i]);
                comboBox_Player4.Items.Add(statistics.player[i]);
            }
        }

        /// <summary>
        /// Startet das Spiel mit den aktuellen Einstellungen
        /// </summary>
        private void button_GamesStart_Click(object sender, EventArgs e)
        {
            startPoints = Convert.ToInt32(button_StartPoints.Text);
            if (button_Gamemode.Text == "Double - Out")
            {
                doubleOut = true;
            }
            else if (button_Gamemode.Text == "Single - Out")
            {
                doubleOut = false;
            }
            switch (player)
            {
                case 1:
                    if (string.IsNullOrWhiteSpace(comboBox_Player1.Text))
                    {
                        MessageBox.Show("Bitte einen Spieler auswählen!");
                    }
                    else
                    {
                        f = new Form2(player, startPoints, doubleOut, comboBox_Player1.Text, this);
                        f.Show();
                        this.Hide();
                    }
                    break;
                case 2:
                    if (string.IsNullOrWhiteSpace(comboBox_Player1.Text) ||
                        string.IsNullOrWhiteSpace(comboBox_Player2.Text))
                    {
                        MessageBox.Show("Bitte alle Spieler auswählen!");
                    }
                    else if (comboBox_Player1.Text == comboBox_Player2.Text)
                    {
                        MessageBox.Show("Bitte jeden Spieler nur einmal auswählen");
                    }
                    else
                    {
                        if (button_Gamemode.Text != "Cricket")
                        {
                            f = new Form2(player, startPoints, doubleOut, comboBox_Player1.Text, comboBox_Player2.Text, this);
                            f.Show();
                        }
                        else
                        {
                            c = new Cricket(player, startPoints, comboBox_Player1.Text, comboBox_Player2.Text, this);
                            c.Show();
                        }
                        this.Hide();
                    }
                    break;
                case 3:
                    if (string.IsNullOrWhiteSpace(comboBox_Player1.Text) ||
                        string.IsNullOrWhiteSpace(comboBox_Player2.Text) ||
                        string.IsNullOrWhiteSpace(comboBox_Player3.Text))
                    {
                        MessageBox.Show("Bitte alle Spieler auswählen!");
                    }
                    else if (comboBox_Player1.Text == comboBox_Player2.Text || comboBox_Player1.Text == comboBox_Player3.Text || comboBox_Player2.Text == comboBox_Player3.Text)
                    {
                        MessageBox.Show("Bitte jeden Spieler nur einmal auswählen");
                    }
                    else
                    {
                        if (button_Gamemode.Text != "Cricket")
                        {
                            f = new Form2(player, startPoints, doubleOut, comboBox_Player1.Text, comboBox_Player2.Text, comboBox_Player3.Text, this);
                            f.Show();
                        }
                        else
                        {
                            c = new Cricket(player, startPoints, comboBox_Player1.Text, comboBox_Player2.Text, comboBox_Player3.Text, this);
                            c.Show();
                        }
                        this.Hide();
                    }
                    break;
                case 4:
                    if (string.IsNullOrWhiteSpace(comboBox_Player1.Text) ||
                        string.IsNullOrWhiteSpace(comboBox_Player2.Text) ||
                        string.IsNullOrWhiteSpace(comboBox_Player3.Text) ||
                        string.IsNullOrWhiteSpace(comboBox_Player4.Text))
                    {
                        MessageBox.Show("Bitte alle Spieler auswählen!");
                    }
                    else if (comboBox_Player1.Text == comboBox_Player2.Text || comboBox_Player1.Text == comboBox_Player3.Text || comboBox_Player1.Text == comboBox_Player4.Text
                        || comboBox_Player2.Text == comboBox_Player3.Text || comboBox_Player2.Text == comboBox_Player4.Text || comboBox_Player3.Text == comboBox_Player4.Text)
                    {
                        MessageBox.Show("Bitte jeden Spieler nur einmal auswählen");
                    }
                    else
                    {
                        if (button_Gamemode.Text != "Cricket")
                        {
                            f = new Form2(player, startPoints, doubleOut, comboBox_Player1.Text, comboBox_Player2.Text, comboBox_Player3.Text, comboBox_Player4.Text, this);
                            f.Show();
                        }
                        else
                        {
                            c = new Cricket(player, startPoints, comboBox_Player1.Text, comboBox_Player2.Text, comboBox_Player3.Text, comboBox_Player4.Text, this);
                            c.Show();
                        }
                        this.Hide();
                    }
                    break;
                default: MessageBox.Show("Fehler beim erstellen des Spiels. Bitte Spiel neustarten."); break;
            }
        }

        /// <summary>
        /// Ändert die Spieleranzahl
        /// </summary>
        private void button_Player_Click(object sender, EventArgs e)
        {
            switch (player)
            {
                case 1: button_Player.Text = "2 Spieler"; label_Player2.Visible = true; comboBox_Player2.Visible = true; button_RotatePlayer.Visible = true; player = 2; break;
                case 2: button_Player.Text = "3 Spieler"; label_Player3.Visible = true; comboBox_Player3.Visible = true; button_RotatePlayer.Visible = true; player = 3; break;
                case 3: button_Player.Text = "4 Spieler"; label_Player4.Visible = true; comboBox_Player4.Visible = true; button_RotatePlayer.Visible = true; player = 4; break;
                case 4:
                    if (button_Gamemode.Text == "Cricket")
                    {
                        button_Player.Text = "2 Spieler";
                        label_Player3.Visible = false; comboBox_Player3.Visible = false;
                        label_Player4.Visible = false; comboBox_Player4.Visible = false;
                        player = 2;
                        break;
                    }
                    else
                    {
                        button_Player.Text = "1 Spieler";
                        label_Player2.Visible = false; comboBox_Player2.Visible = false;
                        label_Player3.Visible = false; comboBox_Player3.Visible = false;
                        label_Player4.Visible = false; comboBox_Player4.Visible = false;
                        button_RotatePlayer.Visible = false;
                        player = 1;
                        break;
                    }
                default: MessageBox.Show("Fehler in der Spieleranzahl! Bitte Spiel neustarten"); break;
            }
        }

        /// <summary>
        /// Ändert die Startpunktzahl
        /// </summary>
        private void button_StartPoints_Click(object sender, EventArgs e)
        {
            if (startPoints == 501)
            {
                button_StartPoints.Text = "301";
                startPoints = 301;
            }
            else
            {
                button_StartPoints.Text = "501";
                startPoints = 501;
            }
        }

        /// <summary>
        /// Ändert den Spielmodus zwischen Double-Out und Single-Out
        /// </summary>
        private void button_Gamemode_Click(object sender, EventArgs e)
        {
            if (button_Gamemode.Text == "Double - Out")
            {
                button_Gamemode.Text = "Single - Out";
                doubleOut = false;
            }
            else if(button_Gamemode.Text == "Single - Out")
            {
                button_Gamemode.Text = "Cricket";
                startPoints = 0;
                button_StartPoints.Text = "0";
                button_StartPoints.Enabled = false;
                doubleOut = false;
                if (button_Player.Text == "1 Spieler")
                {
                    button_Player.Text = "2 Spieler";
                    label_Player2.Visible = true;
                    comboBox_Player2.Visible = true;
                    button_RotatePlayer.Visible = true;
                    player = 2;
                }
            }
            else
            {
                button_Gamemode.Text = "Double - Out";
                startPoints = 501;
                button_StartPoints.Text = "501";
                button_StartPoints.Enabled = true;
                doubleOut = true;
            }
        }

        /// <summary>
        /// Rotiert die Spieler bei 2 Spielern oder mehr
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_RotatePlayer_Click(object sender, EventArgs e)
        {
            string p1 = comboBox_Player1.Text;
            switch (player)
            {
                case 2:
                    comboBox_Player1.SelectedItem = comboBox_Player2.SelectedItem;
                    foreach (PlayerSave p in statistics.player)
                    {
                        if (p.Name == p1)
                        {
                            comboBox_Player2.SelectedItem = p;
                        }
                    }
                    break;
                case 3:
                    comboBox_Player1.SelectedItem = comboBox_Player3.SelectedItem;
                    comboBox_Player3.SelectedItem = comboBox_Player2.SelectedItem;
                    foreach (PlayerSave p in statistics.player)
                    {
                        if (p.Name == p1)
                        {
                            comboBox_Player2.SelectedItem = p;
                        }
                    }
                    break;
                case 4:
                    comboBox_Player1.SelectedItem = comboBox_Player4.SelectedItem;
                    comboBox_Player4.SelectedItem = comboBox_Player3.SelectedItem;
                    comboBox_Player3.SelectedItem = comboBox_Player2.SelectedItem;
                    foreach (PlayerSave p in statistics.player)
                    {
                        if (p.Name == p1)
                        {
                            comboBox_Player2.SelectedItem = p;
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Fehler beim rotieren der Spieler. Bitte Spiel neustarten.");
                    break;
            }
        }

        /// <summary>
        /// Legt einen neuen Spieler an
        /// </summary>
        private void button_CreatePlayer_Click(object sender, EventArgs e)
        {
            using (Form3 newPlayer = new Form3(statistics))
            {
                var result = newPlayer.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string name = newPlayer.PlayerName;
                    PlayerSave p = new PlayerSave(name);
                    statistics.player.Add(p);
                    comboBox_Player1.Items.Add(p);
                    comboBox_Player2.Items.Add(p);
                    comboBox_Player3.Items.Add(p);
                    comboBox_Player4.Items.Add(p);
                }
            }
        }

        /// <summary>
        /// Löscht einen vorhandenen Spieler
        /// </summary>
        private void button_DeletePlayer_Click(object sender, EventArgs e)
        {
            using (Form4 delPlayer = new Form4(statistics))
            {
                var result = delPlayer.ShowDialog();
                if (result == DialogResult.OK)
                {
                    for (int i = 0; i < statistics.player.Count; i++)
                    {
                        if (statistics.player[i].Name == delPlayer.PlayerName)
                        {
                            statistics.player.RemoveAt(i);
                        }
                    }
                    for (int i = 0; i < comboBox_Player1.Items.Count; i++)
                    {
                        if (comboBox_Player1.Items[i].ToString() == delPlayer.PlayerName)
                        {
                            comboBox_Player1.Items.RemoveAt(i);
                            comboBox_Player2.Items.RemoveAt(i);
                            comboBox_Player3.Items.RemoveAt(i);
                            comboBox_Player4.Items.RemoveAt(i);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Öffnet das Statistikfenster
        /// </summary>
        private void button_Statistics_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5(statistics);
            f.Show();
        }



        /// <summary>
        /// Speichert die Statistiken aller Spieler wenn das Spiel beendet wird
        /// </summary>
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            statistics.SerializeCollection();
        }

        
    }
}
