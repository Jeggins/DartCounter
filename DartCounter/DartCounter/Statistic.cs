using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;


namespace DartCounter
{
    public class Statistic
    {
        TextWriter writer;
        XmlSerializer x;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/DartCounter";
        string filename = "statistics.xml";

        public List<PlayerSave> player;

        /// <summary>
        /// Konstruktor der Klasse Statistic
        /// </summary>
        public Statistic()
        {
            if (File.Exists(Path.GetFullPath(path + "/" + filename)))
            {
                DeserializeCollection();
            }
            else
            {
                player = new List<PlayerSave>();
            }
        }

        /// <summary>
        /// Ermittelt die 5 Hochstplazierten in Double-Out Siegen
        /// </summary>
        /// <returns>Liste der 5 Hochstplazierten</returns>
        public List<PlayerSave> GetWinDoubleOutHighscore()
        {
            List<PlayerSave> winDoubleOutHighscore = new List<PlayerSave>();
            winDoubleOutHighscore = (from p in player
                            where p.GamesPlayed >= 10
                            orderby p.Wins descending
                            select p).Take(5).ToList();
            return winDoubleOutHighscore;
        }

        /// <summary>
        /// Ermittelt die 5 Hochstplazierten in Single-Out Siegen
        /// </summary>
        /// <returns>Liste der 5 Hochstplazierten</returns>
        public List<PlayerSave> GetWinSingleOutHighscore()
        {
            List<PlayerSave> winSingleOutHighscore = new List<PlayerSave>();
            winSingleOutHighscore = (from p in player
                            where p.GamesPlayedSingle >= 10
                            orderby p.WinsSingle descending
                            select p).Take(5).ToList();
            return winSingleOutHighscore;
        }

        /// <summary>
        /// Ermittelt die 5 Hochstplazierten im Average
        /// </summary>
        /// <returns>Liste der 5 Hochstplazierten</returns>
        public List<PlayerSave> GetAverageHighscore()
        {
            List<PlayerSave> averageHighscore = new List<PlayerSave>();
            averageHighscore = (from p in player
                            where p.GamesPlayed >= 10
                            orderby p.Average descending
                            select p).Take(5).ToList();
            return averageHighscore;
        }

        /// <summary>
        /// Ermittelt die 5 Hochstplazierten im AverageSingleOut
        /// </summary>
        /// <returns>Liste der 5 Hochstplazierten</returns>
        public List<PlayerSave> GetAverageSingleOutHighscore()
        {
            List<PlayerSave> averageSingleOutHighscore = new List<PlayerSave>();
            averageSingleOutHighscore = (from p in player
                            where p.GamesPlayedSingle >= 10
                            orderby p.AverageSingleOut descending
                            select p).Take(5).ToList();
            return averageSingleOutHighscore;
        }

        /// <summary>
        /// Ermittelt die 5 Hochstplazierten im Hochsten Finish
        /// </summary>
        /// <returns>Liste der 5 Hochstplazierten</returns>
        public List<PlayerSave> GetHighestFinishHighscore()
        {
            List<PlayerSave> highestFinishHighscore = new List<PlayerSave>();
            highestFinishHighscore = (from p in player
                            where p.GamesPlayed >= 10 || p.GamesPlayedSingle >= 10
                            orderby p.HighestFinish descending
                            select p).Take(5).ToList();
            return highestFinishHighscore;
        }

        /// <summary>
        /// Ermittelt die 5 Hochstplazierten Checkouts über 100 Punkten
        /// </summary>
        /// <returns>Liste der 5 Hochstplazierten</returns>
        public List<PlayerSave> GetCheckout100Highscore()
        {
            List<PlayerSave> checkout100Highscore = new List<PlayerSave>();
            checkout100Highscore = (from p in player
                            where p.GamesPlayed >= 10 || p.GamesPlayedSingle >= 10
                            orderby p.Checkout100 descending
                            select p).Take(5).ToList();
            return checkout100Highscore;
        }

        /// <summary>
        /// Ermittelt die 5 Hochstplazierten der Double-Out Rate
        /// </summary>
        /// <returns>Liste der 5 Hochstplazierten</returns>
        public List<PlayerSave> GetDoubleOutRateHighscore()
        {
            List<PlayerSave> DoubleOutRateHighscore = new List<PlayerSave>();
            DoubleOutRateHighscore = (from p in player
                            where p.GamesPlayed >= 10 || p.GamesPlayedSingle >= 10
                            orderby p.AverageDoubleOutRate descending
                            select p).Take(5).ToList();
            return DoubleOutRateHighscore;
        }

        /// <summary>
        /// Ermittelt die 5 Hochstplazierten in den geworfenen 180er Würfen
        /// </summary>
        /// <returns>Liste der 5 Hochstplazierten</returns>
        public List<PlayerSave> Get180Highscore()
        {
            List<PlayerSave> oheHighscore = new List<PlayerSave>();
            oheHighscore = (from p in player
                            where p.GamesPlayed >= 10 || p.GamesPlayedSingle >= 10
                            orderby p.OneHundredEighty descending
                            select p).Take(5).ToList();
            return oheHighscore;
        }

        

        /// <summary>
        /// Speichert die Spieler und schreibt sie in eine XML-Datei
        /// </summary>
        public void SerializeCollection()
        {

            x = new XmlSerializer(player.GetType());
            if (!Directory.Exists(Path.GetFullPath(path)))
            {
                Directory.CreateDirectory(Path.GetFullPath(path));
            }
            writer = new StreamWriter(Path.GetFullPath(path + "/" + filename));
            x.Serialize(writer, player);
            writer.Close();
        }

        /// <summary>
        /// Lädt die gespeicherte XML-Datei und lädt die Spiele wieder in die Liste
        /// </summary>
        private void DeserializeCollection()
        {
            x = new XmlSerializer(typeof(List<PlayerSave>));
            FileStream fs = new FileStream(Path.GetFullPath(path + "/" + filename), FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            player = (List<PlayerSave>)x.Deserialize(reader);
            fs.Close();
        }
    }
}
