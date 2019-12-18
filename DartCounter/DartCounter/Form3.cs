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
    public partial class Form3 : Form
    {
        public string PlayerName { get; set; }
        Statistic statistics;

        /// <summary>
        /// Konstruktor der Klasse Form3 (Spieler erstellen)
        /// </summary>
        /// <param name="statistics">Liste der gespeicherten Spieler</param>
        public Form3(Statistic statistics)
        {
            InitializeComponent();
            this.statistics = statistics;
        }

        /// <summary>
        /// Bestätigt dass ein Spieler erstellt wurde und gibt den eingegebenen Namen zurück
        /// </summary>
        private void button_OK_Click(object sender, EventArgs e)
        {
            bool exists = false;
            for (int i = 0; i < statistics.player.Count; i++)
            {
                if (statistics.player[i].Name == textBox_Name.Text)
                {
                    exists = true;
                }
            }
            if (exists)
            {
                MessageBox.Show("Ein Spieler mit dem gleichen Namen ist bereits enthalten. Bitte anderen Namen wählen!", "Anderen Namen wählen!");
                textBox_Name.Text = "";
            }
            else if (textBox_Name.Text.Length > 30)
            {
                MessageBox.Show("Der Name ist zu lang. Bitte einen kürzeren Namen wählen!", "Name zu lang!");
                textBox_Name.Text = "";
            }
            else if (textBox_Name.Text.Length < 3)
            {
                MessageBox.Show("Der Name muss mindestens 3 Zeichen enthalten", "Gültigen Namen eingeben!");
                textBox_Name.Text = "";
            }
            else
            {
                this.PlayerName = textBox_Name.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Bricht die Aktion ab
        /// </summary>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
