using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DartCounter
{
    public class Game
    {
        public int PlayerAmount { get; set; }
        public int StartPoints { get; set; }
        public bool DoubleOut { get; set; }
        public int ActivePlayer { get; set; }
        public List<Player> players;

        /// <summary>
        /// Konstruktor der Klasse Game (Spiellogik)
        /// </summary>
        /// <param name="playerAmount">Spieleranzahl</param>
        /// <param name="startPoints">Startpunnktzahl</param>
        /// <param name="doubleOut">Spielmodus</param>
        /// <param name="names">Array der Spielernamen</param>
        public Game(int playerAmount, int startPoints, bool doubleOut, string[] names)
        {
            this.PlayerAmount = playerAmount;
            this.StartPoints = startPoints;
            this.DoubleOut = doubleOut;
            this.ActivePlayer = 0;
            players = new List<Player>();
            for (int i = 0; i < playerAmount; i++)
            {
                Player p = new Player(names[i], startPoints);
                players.Add(p);
            }
        }

        /// <summary>
        /// Komplette Logik die abgehandelt wird wenn ein Wurf gemacht wird.
        /// </summary>
        /// <param name="score">Geworfene Punktzahl</param>
        /// <param name="isDouble">Wurde ein Doppelfeld getroffen?</param>
        /// <param name="ring">welches Feld wurde getroffen</param>
        public void HandleThrow(int score, int zone, bool isDouble, int ring)
        {
            players[ActivePlayer].AddThrow(score, zone, isDouble, ring);
            players[ActivePlayer].setPoints();
            players[ActivePlayer].HandleThrows(1);
            players[ActivePlayer].Undo = true;
            int b = players[ActivePlayer].IsOverthrown(DoubleOut);
            if (b != 0)
            {
                RemovePoints();
                //Set throws done to 0 points
                players[ActivePlayer].SetThrowsToZero(3 - players[ActivePlayer].ThrowsLeft);
                for (int i = 0; i < 3; i++)
                {
                    players[ActivePlayer].AddThrow(0, zone, false, 0);
                }
                players[ActivePlayer].HandleThrows(players[ActivePlayer].ThrowsLeft);
            }
            players[ActivePlayer].calcAverage();
            players[ActivePlayer].LastThrowToString(b);
        }

        /// <summary>
        /// Spiel wechselt zum nächsten Spieler
        /// </summary>
        public void NextPlayer()
        {
            if (ActivePlayer < (PlayerAmount - 1))
            {
                ActivePlayer++;
                players[ActivePlayer].ResetThrows();
            }
            else
            {
                ActivePlayer = 0;
                players[ActivePlayer].ResetThrows();
            }
        }

        /// <summary>
        /// Fügt die Punkte der Würfe, die in dieser Aufnahme schon gemacht wurden, wieder hinzu
        /// </summary>
        public void RemovePoints()
        {
            for (int i = 0; i < 3 - players[ActivePlayer].ThrowsLeft; i++)
            {
                players[ActivePlayer].Points += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Points;
            }
        }

        /// <summary>
        /// Fügt die Punkte so vieler Würfen, die im Parameter übergeben wird, wieder hinzu
        /// </summary>
        /// <param name="amount">Anzahl der zu löschenden Würfe</param>
        public void RemovePoints(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                players[ActivePlayer].Points += players[ActivePlayer].throws[(players[ActivePlayer].throws.Count - 1 - i)].Points;
            }
        }

        /// <summary>
        /// Ermittelt den ob und mit welcher Wurfkombination man einen Checkout schafft (Ab 170 Punkten Rest)
        /// </summary>
        /// <returns>Checkout</returns>
        public string GetCheckout()
        {
            if (players[ActivePlayer].ThrowsLeft == 3)
            {
                if (players[ActivePlayer].Points == 170) return "T20, T20, DB";
                if (players[ActivePlayer].Points == 167) return "T20, T19, DB";
                if (players[ActivePlayer].Points == 164) return "T20, T18, DB";
                if (players[ActivePlayer].Points == 161) return "T20, T17, DB";
                if (players[ActivePlayer].Points == 160) return "T20, T20, D20";
                if (players[ActivePlayer].Points == 158) return "T20, T20, D19";
                if (players[ActivePlayer].Points == 157) return "T20, T19, D20";
                if (players[ActivePlayer].Points == 156) return "T20, T20, D18";
                if (players[ActivePlayer].Points == 155) return "T20, T19, D19";
                if (players[ActivePlayer].Points == 154) return "T20, T18, D20";
                if (players[ActivePlayer].Points == 153) return "T20, T19, D18";
                if (players[ActivePlayer].Points == 152) return "T20, T20, D16";
                if (players[ActivePlayer].Points == 151) return "T20, T17, D20";
                if (players[ActivePlayer].Points == 150) return "T20, T18, D18";
                if (players[ActivePlayer].Points == 149) return "T20, T19, D16";
                if (players[ActivePlayer].Points == 148) return "T20, T20, D14";
                if (players[ActivePlayer].Points == 147) return "T20, T17, D18";
                if (players[ActivePlayer].Points == 146) return "T20, T18, D16";
                if (players[ActivePlayer].Points == 145) return "T20, T15, D20";
                if (players[ActivePlayer].Points == 144) return "T20, T20, D12";
                if (players[ActivePlayer].Points == 143) return "T20, T17, D16";
                if (players[ActivePlayer].Points == 142) return "T20, T14, D20";
                if (players[ActivePlayer].Points == 141) return "T20, T19, D12";
                if (players[ActivePlayer].Points == 140) return "T20, T20, D10";
                if (players[ActivePlayer].Points == 139) return "T20, T13, D20";
                if (players[ActivePlayer].Points == 138) return "T20, T18, D12";
                if (players[ActivePlayer].Points == 137) return "T20, T15, D16";
                if (players[ActivePlayer].Points == 136) return "T20, T20, D8";
                if (players[ActivePlayer].Points == 135) return "T20, T17, D12";
                if (players[ActivePlayer].Points == 134) return "T20, T14, D16";
                if (players[ActivePlayer].Points == 133) return "T20, T19, D8";
                if (players[ActivePlayer].Points == 132) return "T20, T16, D12";
                if (players[ActivePlayer].Points == 131) return "T20, T13, D16";
                if (players[ActivePlayer].Points == 130) return "T20, T18, D8";
                if (players[ActivePlayer].Points == 129) return "T20, T19, D6";
                if (players[ActivePlayer].Points == 128) return "T20, T16, D10";
                if (players[ActivePlayer].Points == 127) return "T20, T9, D20";
                if (players[ActivePlayer].Points == 126) return "T20, T10, D18";
                if (players[ActivePlayer].Points == 125) return "T20, T11, D16";
                if (players[ActivePlayer].Points == 124) return "T20, T16, D8";
                if (players[ActivePlayer].Points == 123) return "T19, T10, D18";
                if (players[ActivePlayer].Points == 122) return "T20, T10, D16";
                if (players[ActivePlayer].Points == 121) return "T20, T15, D8";
                if (players[ActivePlayer].Points == 120) return "T20, 20, D20";
                if (players[ActivePlayer].Points == 119) return "T20, 19, D20";
                if (players[ActivePlayer].Points == 118) return "T20, 18, D20";
                if (players[ActivePlayer].Points == 117) return "T20, 17, D20";
                if (players[ActivePlayer].Points == 116) return "T20, 16, D20";
                if (players[ActivePlayer].Points == 115) return "T20, 15, D20";
                if (players[ActivePlayer].Points == 114) return "T20, 14, D20";
                if (players[ActivePlayer].Points == 113) return "T20, 13, D20";
                if (players[ActivePlayer].Points == 112) return "T20, 12, D20";
                if (players[ActivePlayer].Points == 111) return "T20, 11, D20";
                if (players[ActivePlayer].Points == 110) return "T20, 10, D20";
                if (players[ActivePlayer].Points == 109) return "T20, 9, D20";
                if (players[ActivePlayer].Points == 108) return "T20, 16, D16";
                if (players[ActivePlayer].Points == 107) return "T20, 7, D20";
                if (players[ActivePlayer].Points == 106) return "T20, 6, D20";
                if (players[ActivePlayer].Points == 105) return "T20, 13, D16";
                if (players[ActivePlayer].Points == 104) return "T20, 12, D16";
                if (players[ActivePlayer].Points == 103) return "T20, 11, D16";
                if (players[ActivePlayer].Points == 102) return "T20, 10, D16";
                if (players[ActivePlayer].Points == 101) return "T20, 9, D16";
                if (players[ActivePlayer].Points == 99) return "T20, 7, D16";
            }
            if (players[ActivePlayer].ThrowsLeft >= 2 && !DoubleOut)
            {
                if (players[ActivePlayer].Points == 120) return "T20, T20";
                if (players[ActivePlayer].Points == 117) return "T20, T19";
                if (players[ActivePlayer].Points == 114) return "T20, T18";
                if (players[ActivePlayer].Points == 111) return "T20, T17";
                if (players[ActivePlayer].Points == 110) return "DB, T20";
                if (players[ActivePlayer].Points == 107) return "DB, T19";
                if (players[ActivePlayer].Points == 104) return "DB, T18";
                if (players[ActivePlayer].Points == 101) return "DB, T17";
                if (players[ActivePlayer].Points == 100) return "T20, D20";
                if (players[ActivePlayer].Points == 98) return "T20, D19";
                if (players[ActivePlayer].Points == 97) return "T19, D20";
                if (players[ActivePlayer].Points == 96) return "T20, D18";
                if (players[ActivePlayer].Points == 95) return "T19, D19";
                if (players[ActivePlayer].Points == 94) return "T18, D20";
                if (players[ActivePlayer].Points == 93) return "T19, D18";
                if (players[ActivePlayer].Points == 92) return "T20, D16";
                if (players[ActivePlayer].Points == 91) return "T17, D20";
                if (players[ActivePlayer].Points == 90) return "T20, D15";
                if (players[ActivePlayer].Points == 89) return "T19, D16";
                if (players[ActivePlayer].Points == 88) return "T20, D14";
                if (players[ActivePlayer].Points == 87) return "T17, D18";
                if (players[ActivePlayer].Points == 86) return "T18, D16";
                if (players[ActivePlayer].Points == 85) return "T15, D20";
                if (players[ActivePlayer].Points == 84) return "T20, D12";
                if (players[ActivePlayer].Points == 83) return "T17, D16";
                if (players[ActivePlayer].Points == 82) return "DB, D16";
                if (players[ActivePlayer].Points == 81) return "T19, D12";
                if (players[ActivePlayer].Points == 80) return "T20, 20";
                if (players[ActivePlayer].Points == 79) return "T20, 19";
                if (players[ActivePlayer].Points == 78) return "T20, 18";
                if (players[ActivePlayer].Points == 77) return "T20, 17";
                if (players[ActivePlayer].Points == 76) return "T20, 16";
                if (players[ActivePlayer].Points == 75) return "T20, 15";
                if (players[ActivePlayer].Points == 74) return "T20, 14";
                if (players[ActivePlayer].Points == 73) return "T20, 13";
                if (players[ActivePlayer].Points == 72) return "T20, 12";
                if (players[ActivePlayer].Points == 71) return "T20, 11";
                if (players[ActivePlayer].Points == 70) return "T20, 10";
                if (players[ActivePlayer].Points == 69) return "T20, 9";
                if (players[ActivePlayer].Points == 68) return "T20, 8";
                if (players[ActivePlayer].Points == 67) return "T20, 7";
                if (players[ActivePlayer].Points == 66) return "T20, 6";
                if (players[ActivePlayer].Points == 65) return "T20, 5";
                if (players[ActivePlayer].Points == 64) return "T20, 4";
                if (players[ActivePlayer].Points == 63) return "T20, 3";
                if (players[ActivePlayer].Points == 62) return "T20, 2";
                if (players[ActivePlayer].Points == 61) return "T20, 1";
                if (players[ActivePlayer].Points == 59) return "T19, 2";
                if (players[ActivePlayer].Points == 58) return "T19, 1";
                if (players[ActivePlayer].Points == 56) return "T12, 20";
                if (players[ActivePlayer].Points == 55) return "T12, 19";
                if (players[ActivePlayer].Points == 53) return "T12, 17";
                if (players[ActivePlayer].Points == 52) return "T12, 16";
                if (players[ActivePlayer].Points == 50) return "T12, 14";
                if (players[ActivePlayer].Points == 49) return "T12, 13";
                if (players[ActivePlayer].Points == 47) return "T12, 11";
                if (players[ActivePlayer].Points == 46) return "T10, 16";
                if (players[ActivePlayer].Points == 44) return "T10, 14";
                if (players[ActivePlayer].Points == 43) return "T10, 13";
                if (players[ActivePlayer].Points == 41) return "T10, 11";
                if (players[ActivePlayer].Points == 39) return "19, 20";
                if (players[ActivePlayer].Points == 37) return "17, 20";
                if (players[ActivePlayer].Points == 35) return "15, 20";
                if (players[ActivePlayer].Points == 33) return "13, 20";
                if (players[ActivePlayer].Points == 31) return "11, 20";
                if (players[ActivePlayer].Points == 29) return "9, 20";
                if (players[ActivePlayer].Points == 27) return "7, 20";
                if (players[ActivePlayer].Points == 25) return "5, 20";
                if (players[ActivePlayer].Points == 23) return "3, 20";
                if (players[ActivePlayer].Points == 21) return "1, 20";
            }
            if (players[ActivePlayer].ThrowsLeft >= 2 && DoubleOut)
            {
                if (players[ActivePlayer].Points == 110) return "T20, DB";
                if (players[ActivePlayer].Points == 107) return "T19, DB";
                if (players[ActivePlayer].Points == 104) return "T18, DB";
                if (players[ActivePlayer].Points == 101) return "T17, DB";
                if (players[ActivePlayer].Points == 100) return "T20, D20";
                if (players[ActivePlayer].Points == 98) return "T20, D19";
                if (players[ActivePlayer].Points == 97) return "T19, D20";
                if (players[ActivePlayer].Points == 96) return "T20, D18";
                if (players[ActivePlayer].Points == 95) return "T19, D19";
                if (players[ActivePlayer].Points == 94) return "T18, D20";
                if (players[ActivePlayer].Points == 93) return "T19, D18";
                if (players[ActivePlayer].Points == 92) return "T20, D16";
                if (players[ActivePlayer].Points == 91) return "T17, D20";
                if (players[ActivePlayer].Points == 90) return "T18, D18";
                if (players[ActivePlayer].Points == 89) return "T19, D16";
                if (players[ActivePlayer].Points == 88) return "T20, D14";
                if (players[ActivePlayer].Points == 87) return "T17, D18";
                if (players[ActivePlayer].Points == 86) return "T18, D16";
                if (players[ActivePlayer].Points == 85) return "T15, D20";
                if (players[ActivePlayer].Points == 84) return "T20, D12";
                if (players[ActivePlayer].Points == 83) return "T17, D16";
                if (players[ActivePlayer].Points == 82) return "T14, D20";
                if (players[ActivePlayer].Points == 81) return "T19, D12";
                if (players[ActivePlayer].Points == 80) return "T20, D10";
                if (players[ActivePlayer].Points == 79) return "T13, D20";
                if (players[ActivePlayer].Points == 78) return "T18, D12";
                if (players[ActivePlayer].Points == 77) return "T15, D16";
                if (players[ActivePlayer].Points == 76) return "T20, D8";
                if (players[ActivePlayer].Points == 75) return "T17, D12";
                if (players[ActivePlayer].Points == 74) return "T14, D16";
                if (players[ActivePlayer].Points == 73) return "T19, D8";
                if (players[ActivePlayer].Points == 72) return "T16, D12";
                if (players[ActivePlayer].Points == 71) return "T13, D16";
                if (players[ActivePlayer].Points == 70) return "T18, D8";
                if (players[ActivePlayer].Points == 69) return "T19, D6";
                if (players[ActivePlayer].Points == 68) return "T16, D10";
                if (players[ActivePlayer].Points == 67) return "T9, D20";
                if (players[ActivePlayer].Points == 66) return "T10, D18";
                if (players[ActivePlayer].Points == 65) return "T11, D16";
                if (players[ActivePlayer].Points == 64) return "T16, D8";
                if (players[ActivePlayer].Points == 63) return "T13, D12";
                if (players[ActivePlayer].Points == 62) return "T10, D16";
                if (players[ActivePlayer].Points == 61) return "T15, D8";
                if (players[ActivePlayer].Points == 60) return "20, D20";
                if (players[ActivePlayer].Points == 59) return "19, D20";
                if (players[ActivePlayer].Points == 58) return "18, D20";
                if (players[ActivePlayer].Points == 57) return "17, D20";
                if (players[ActivePlayer].Points == 56) return "16, D20";
                if (players[ActivePlayer].Points == 55) return "15, D20";
                if (players[ActivePlayer].Points == 54) return "14, D20";
                if (players[ActivePlayer].Points == 53) return "13, D20";
                if (players[ActivePlayer].Points == 52) return "12, D20";
                if (players[ActivePlayer].Points == 51) return "11, D20";
                if (players[ActivePlayer].Points == 50) return "10, D20";
                if (players[ActivePlayer].Points == 49) return "9, D20";
                if (players[ActivePlayer].Points == 48) return "16, D16";
                if (players[ActivePlayer].Points == 47) return "7, D20";
                if (players[ActivePlayer].Points == 46) return "6, D20";
                if (players[ActivePlayer].Points == 45) return "13, D16";
                if (players[ActivePlayer].Points == 44) return "12, D16";
                if (players[ActivePlayer].Points == 43) return "11, D16";
                if (players[ActivePlayer].Points == 42) return "10, D16";
                if (players[ActivePlayer].Points == 41) return "9, D16";
                if (players[ActivePlayer].Points == 39) return "7, D16";
                if (players[ActivePlayer].Points == 37) return "5, D16";
                if (players[ActivePlayer].Points == 35) return "3, D16";
                if (players[ActivePlayer].Points == 33) return "1, D16";
                if (players[ActivePlayer].Points == 31) return "15, D8";
                if (players[ActivePlayer].Points == 29) return "13, D8";
                if (players[ActivePlayer].Points == 27) return "11, D8";
                if (players[ActivePlayer].Points == 25) return "9, D8";
                if (players[ActivePlayer].Points == 23) return "7, D8";
                if (players[ActivePlayer].Points == 21) return "5, D8";
                if (players[ActivePlayer].Points == 19) return "3, D8";
                if (players[ActivePlayer].Points == 17) return "1, D8";
                if (players[ActivePlayer].Points == 15) return "7, D4";
                if (players[ActivePlayer].Points == 13) return "5, D4";
                if (players[ActivePlayer].Points == 11) return "3, D4";
                if (players[ActivePlayer].Points == 9) return "1, D4";
                if (players[ActivePlayer].Points == 7) return "3, D2";
                if (players[ActivePlayer].Points == 5) return "1, D2";
                if (players[ActivePlayer].Points == 3) return "1, D1";
            }
            if (players[ActivePlayer].ThrowsLeft >= 1 && !DoubleOut)
            {
                if (players[ActivePlayer].Points == 60) return "T20";
                if (players[ActivePlayer].Points == 57) return "T19";
                if (players[ActivePlayer].Points == 54) return "T18";
                if (players[ActivePlayer].Points == 51) return "T17";
                if (players[ActivePlayer].Points == 50) return "DB";
                if (players[ActivePlayer].Points == 48) return "T16";
                if (players[ActivePlayer].Points == 45) return "T15";
                if (players[ActivePlayer].Points == 42) return "T14";
                if (players[ActivePlayer].Points == 40) return "D20";
                if (players[ActivePlayer].Points == 39) return "T13";
                if (players[ActivePlayer].Points == 38) return "D19";
                if (players[ActivePlayer].Points == 36) return "D18";
                if (players[ActivePlayer].Points == 34) return "D17";
                if (players[ActivePlayer].Points == 33) return "T11";
                if (players[ActivePlayer].Points == 32) return "D16";
                if (players[ActivePlayer].Points == 30) return "D15";
                if (players[ActivePlayer].Points == 28) return "D14";
                if (players[ActivePlayer].Points == 27) return "T9";
                if (players[ActivePlayer].Points == 26) return "D13";
                if (players[ActivePlayer].Points == 25) return "SB";
                if (players[ActivePlayer].Points == 24) return "D12";
                if (players[ActivePlayer].Points == 22) return "D11";
                if (players[ActivePlayer].Points == 21) return "T7";
                if (players[ActivePlayer].Points == 20) return "20";
                if (players[ActivePlayer].Points == 19) return "19";
                if (players[ActivePlayer].Points == 18) return "18";
                if (players[ActivePlayer].Points == 17) return "17";
                if (players[ActivePlayer].Points == 16) return "16";
                if (players[ActivePlayer].Points == 15) return "15";
                if (players[ActivePlayer].Points == 14) return "14";
                if (players[ActivePlayer].Points == 13) return "13";
                if (players[ActivePlayer].Points == 12) return "12";
                if (players[ActivePlayer].Points == 11) return "11";
                if (players[ActivePlayer].Points == 10) return "10";
                if (players[ActivePlayer].Points == 9) return "9";
                if (players[ActivePlayer].Points == 8) return "8";
                if (players[ActivePlayer].Points == 7) return "7";
                if (players[ActivePlayer].Points == 6) return "6";
                if (players[ActivePlayer].Points == 5) return "5";
                if (players[ActivePlayer].Points == 4) return "4";
                if (players[ActivePlayer].Points == 3) return "3";
                if (players[ActivePlayer].Points == 2) return "2";
                if (players[ActivePlayer].Points == 1) return "1";
            }
            if (players[ActivePlayer].ThrowsLeft >= 1 && DoubleOut)
            {
                if (players[ActivePlayer].Points == 50) return "DB";
                if (players[ActivePlayer].Points == 40) return "D20";
                if (players[ActivePlayer].Points == 38) return "D19";
                if (players[ActivePlayer].Points == 36) return "D18";
                if (players[ActivePlayer].Points == 34) return "D17";
                if (players[ActivePlayer].Points == 32) return "D16";
                if (players[ActivePlayer].Points == 30) return "D15";
                if (players[ActivePlayer].Points == 28) return "D14";
                if (players[ActivePlayer].Points == 26) return "D13";
                if (players[ActivePlayer].Points == 24) return "D12";
                if (players[ActivePlayer].Points == 22) return "D11";
                if (players[ActivePlayer].Points == 20) return "D10";
                if (players[ActivePlayer].Points == 18) return "D9";
                if (players[ActivePlayer].Points == 16) return "D8";
                if (players[ActivePlayer].Points == 14) return "D7";
                if (players[ActivePlayer].Points == 12) return "D6";
                if (players[ActivePlayer].Points == 10) return "D5";
                if (players[ActivePlayer].Points == 8) return "D4";
                if (players[ActivePlayer].Points == 6) return "D3";
                if (players[ActivePlayer].Points == 4) return "D2";
                if (players[ActivePlayer].Points == 2) return "D1";
            }
            return "nicht mehr möglich";
        }

        /// <summary>
        /// Mach den die aktuelle Aufnahme Rückgängig
        /// </summary>
        public void Undo()
        {
            if (players[ActivePlayer].Overthrown)
            {
                if (players[ActivePlayer].ThrowsLeft == 3)
                {
                    players[ActivePlayer].RemoveThrow(3);
                }
                else
                {
                    players[ActivePlayer].RemoveThrow(3 - players[ActivePlayer].ThrowsLeft);
                    players[ActivePlayer].ResetThrows();
                }
            }
            else
            {
                if (players[ActivePlayer].ThrowsLeft == 3)
                {
                    if ((players[ActivePlayer].throws[players[ActivePlayer].throws.Count - 1].Points +
                        players[ActivePlayer].throws[players[ActivePlayer].throws.Count - 2].Points +
                        players[ActivePlayer].throws[players[ActivePlayer].throws.Count - 3].Points) == 180)
                    {
                        players[ActivePlayer].OneHundredEighty--;
                    }
                    RemovePoints(3);
                    players[ActivePlayer].RemoveThrow(3);
                    players[ActivePlayer].ResetThrows();
                }
                else
                {
                    if (players[ActivePlayer].ThrowsLeft == 0)
                    {
                        if ((players[ActivePlayer].throws[players[ActivePlayer].throws.Count - 1].Points +
                        players[ActivePlayer].throws[players[ActivePlayer].throws.Count - 2].Points +
                        players[ActivePlayer].throws[players[ActivePlayer].throws.Count - 3].Points) == 180)
                        {
                            players[ActivePlayer].OneHundredEighty--;
                        }
                    }
                    RemovePoints();
                    players[ActivePlayer].RemoveThrow(3 - players[ActivePlayer].ThrowsLeft);
                    players[ActivePlayer].ResetThrows();
                }
            }
        }

        /// <summary>
        /// Aktualisiert alle Spieler Statistiken
        /// </summary>
        /// <param name="statistics">Liste der gespeicherten Spieler</param>
        public void WriteStatistics(Statistic statistics)
        {
            if (DoubleOut)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    for (int s = 0; s < statistics.player.Count; s++)
                    {
                        if (players[i].Name == statistics.player[s].Name)
                        {
                            statistics.player[s].GamesPlayed++;
                            if (ActivePlayer == i)
                            {
                                if (PlayerAmount > 1)
                                {
                                    statistics.player[s].Wins++;
                                }
                                if (StartPoints == 501)
                                {
                                    statistics.player[s].NeededDartsToFinishDoubleOut.Add(players[i].throws.Count);
                                    // BestLegDarts
                                    if (statistics.player[s].BestLegDarts == 0 || statistics.player[s].BestLegDarts > players[i].throws.Count)
                                    {
                                        statistics.player[s].BestLegDarts = players[i].throws.Count;
                                    }
                                }
                                // DoubleOutRate
                                int count = 0;
                                foreach (Throws t in players[i].throws)
                                {
                                    if (t.PossibleFinishDart)
                                    {
                                        count++;
                                    }
                                }
                                statistics.player[s].DoubleOutRate.Add(Math.Round((1.0 / count) * 100.0, MidpointRounding.AwayFromZero));
                                // Checkout < 100:
                                count = 0;
                                for (int l = 0; l < 3 - players[i].ThrowsLeft; l++)
                                {
                                    count += players[i].throws[(players[i].throws.Count - 1 - l)].Points;
                                }
                                if (count > 100)
                                {
                                    statistics.player[s].Checkout100++;
                                }
                                // Highest Finish:
                                if (count > statistics.player[s].HighestFinish)
                                {
                                    statistics.player[s].HighestFinish = count;
                                }
                            }
                            else
                            {
                                statistics.player[s].Looses++;
                            }
                            statistics.player[s].averages.Add(players[i].Average);
                            statistics.player[s].ThrownDarts += players[i].throws.Count;
                            statistics.player[s].PointsScored += (StartPoints - players[i].Points);
                            if (statistics.player[s].DoubleOutRate.Count > 0)
                            {
                                statistics.player[s].AverageDoubleOutRate = Math.Round((statistics.player[s].DoubleOutRate.Sum() / statistics.player[s].DoubleOutRate.Count()), 2, MidpointRounding.AwayFromZero);
                            }
                            statistics.player[s].OneHundredEighty += players[i].OneHundredEighty;
                            statistics.player[s].Average = Math.Round((statistics.player[s].averages.Sum() / statistics.player[s].averages.Count), 2, MidpointRounding.AwayFromZero);
                            if (statistics.player[s].NeededDartsToFinishDoubleOut.Count > 0)
                            {
                                statistics.player[s].AverageNeededDartsToFinishDoubleOut = Math.Round((double)(statistics.player[s].NeededDartsToFinishDoubleOut.Sum() / statistics.player[s].NeededDartsToFinishDoubleOut.Count), 2, MidpointRounding.AwayFromZero);
                            }
                            foreach (Throws t in players[i].throws)
                            {
                                if (t.Ring == 0)
                                {
                                    statistics.player[s].Misses++;
                                }
                                if (t.Ring == 1)
                                {
                                    statistics.player[s].Single++;
                                }
                                if (t.Ring == 2)
                                {
                                    statistics.player[s].Double++;
                                }
                                if (t.Ring == 3)
                                {
                                    statistics.player[s].Triple++;
                                }
                                if (t.Ring == 4)
                                {
                                    statistics.player[s].SingleBull++;
                                }
                                if (t.Ring == 5)
                                {
                                    statistics.player[s].DoubleBull++;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < players.Count; i++)
                {
                    for (int s = 0; s < statistics.player.Count; s++)
                    {
                        if (players[i].Name == statistics.player[s].Name)
                        {
                            statistics.player[s].GamesPlayedSingle++;
                            if (ActivePlayer == i)
                            {
                                if (PlayerAmount > 1)
                                {
                                    statistics.player[s].WinsSingle++;
                                }
                                if (StartPoints == 501)
                                {
                                    statistics.player[s].NeededDartsToFinishSingleOut.Add(players[i].throws.Count);
                                    // BestLegDartsSingle
                                    if (statistics.player[s].BestLegDartsSingle == 0 || statistics.player[s].BestLegDartsSingle > players[i].throws.Count)
                                    {
                                        statistics.player[s].BestLegDartsSingle = players[i].throws.Count;
                                    }
                                }
                                // Checkout < 100:
                                int count = 0;
                                count = 0;
                                for (int l = 0; l < 3 - players[i].ThrowsLeft; l++)
                                {
                                    count += players[i].throws[(players[i].throws.Count - 1 - l)].Points;
                                }
                                if (count > 100)
                                {
                                    statistics.player[s].Checkout100++;
                                }
                                // Highest Finish:
                                if (count > statistics.player[s].HighestFinish)
                                {
                                    statistics.player[s].HighestFinish = count;
                                }
                            }
                            else
                            {
                                statistics.player[s].LoosesSingle++;
                            }
                            statistics.player[s].averagesSingleOut.Add(players[i].Average);
                            statistics.player[s].ThrownDarts += players[i].throws.Count;
                            statistics.player[s].PointsScored += (StartPoints - players[i].Points);
                            statistics.player[s].OneHundredEighty += players[i].OneHundredEighty;
                            statistics.player[s].AverageSingleOut = Math.Round((statistics.player[s].averagesSingleOut.Sum() / statistics.player[s].averagesSingleOut.Count), 2, MidpointRounding.AwayFromZero);
                            if (statistics.player[s].NeededDartsToFinishSingleOut.Count > 0)
                            {
                                statistics.player[s].AverageNeededDartsToFinishSingleOut = Math.Round((double)(statistics.player[s].NeededDartsToFinishSingleOut.Sum() / statistics.player[s].NeededDartsToFinishSingleOut.Count), 2, MidpointRounding.AwayFromZero);
                            }
                            foreach (Throws t in players[i].throws)
                            {
                                if (t.Ring == 0)
                                {
                                    statistics.player[s].Misses++;
                                }
                                if (t.Ring == 1)
                                {
                                    statistics.player[s].Single++;
                                }
                                if (t.Ring == 2)
                                {
                                    statistics.player[s].Double++;
                                }
                                if (t.Ring == 3)
                                {
                                    statistics.player[s].Triple++;
                                }
                                if (t.Ring == 4)
                                {
                                    statistics.player[s].SingleBull++;
                                }
                                if (t.Ring == 5)
                                {
                                    statistics.player[s].DoubleBull++;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
