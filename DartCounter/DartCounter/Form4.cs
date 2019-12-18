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
    public partial class Form4 : Form
    {
        public string PlayerName { get; set; }
        Statistic statistics;

        /// <summary>
        /// Konstruktor der Klasse Form4 (Spieler löschen)
        /// </summary>
        /// <param name="statistics">Liste der gespeicherten Spieler</param>
        public Form4(Statistic statistics)
        {
            InitializeComponent();
            this.statistics = statistics;
            for (int i = 0; i < statistics.player.Count; i++)
            {
                comboBox1.Items.Add(statistics.player[i]);
            }
        }

        /// <summary>
        /// Löscht nach Bestätigung den ausgewählten Spieler
        /// </summary>
        private void button_Delete_Click(object sender, EventArgs e)
        {
            bool exists = false;
            for (int i = 0; i < statistics.player.Count; i++)
            {
                if (statistics.player[i].Name == comboBox1.Text)
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                MessageBox.Show("Bitte den Spieler auswählen der gelöscht werden soll!", "Spieler auswählen!");
            }
            else
            {
                DialogResult result = MessageBox.Show(string.Format("Spieler \"{0}\" sicher löschen?\nAlle Statistiken von dem Spieler werden unwiederruflich gelöscht!", comboBox1.Text), "Spieler löschen?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    this.PlayerName = comboBox1.Text;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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
