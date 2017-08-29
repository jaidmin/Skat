using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
namespace SkatLib
{
    public class Abend
    {
        public int id { get; set; }
        public List<Spieler> spieler { get; set; }
        public List<Spiel> spiele { get; set; }
        public DateTime datetime { get; set; }
        public Regeln regeln { get; set; }
        public Zaehlweise zaehlweise { get; set; }
        private string _spielStand;
        [NotMapped]
        public List<int> spielStand
        { 
            get
            {
                List<int> list_int = new List<int>();
                foreach (string number_string in _spielStand.Split(',').ToList())
                {
                    list_int.Add(int.Parse(number_string));
                }
                return list_int;
            }
            set
            {
                _spielStand = String.Join<int>(",", value);
            }
        }

        public Abend(List<Spieler> spieler, Regeln regeln)
        {
            datetime = System.DateTime.Now;
            this.spieler = spieler;
            spiele = new List<Spiel>();
            this.regeln = regeln;
            _spielStand = "0,0,0";
        
        }

        private Abend()
        {
            _spielStand = "0,0,0";
        }


        public void addSpiel(Spiel spiel)
        {
            this.spiele.Add(spiel);
        }

        public Spiel getNextSpiel()
        {
            throw new NotImplementedException();
        }
        // calculate the current spielstand based on the list of games, later the database will be queried
        public void calculateSpielstand()
        {
            List<int> newSpielstand = new List<int> { 0, 0, 0 };
            switch (zaehlweise)
            {
                case Zaehlweise.KLASSISCH:
                    foreach (Spiel spiel in spiele)
                    {
                        var _spieler = spiel.spieler;
                        int _spielerIndex = spieler.IndexOf(_spieler);
                        if (spiel.gewonnen == true)
                        {
                            newSpielstand[_spielerIndex] += spiel.spielwert;
                        }
                        if (spiel.gewonnen == false)
                        {
                            newSpielstand[_spielerIndex] -= 2 * spiel.spielwert;
                        }
                    }
                    break;
                case Zaehlweise.BIERLACHS:
                    foreach (Spiel spiel in spiele)
                    {
                        var _spieler = spiel.spieler;
                        int _spielerIndex = spieler.IndexOf(_spieler);
                        if (spiel.gewonnen == true)
                        {
                            foreach (var verlierer in spieler.Where(s => spieler.IndexOf(s) != _spielerIndex))
                            {
                                int _verliererIndex = spieler.IndexOf(verlierer);
                                newSpielstand[_verliererIndex] -= spiel.spielwert;

                            }
                        }
                        if (spiel.gewonnen == false)
                        {
                            newSpielstand[_spielerIndex] -= 2 * spiel.spielwert;
                        }
                    }break;
                case Zaehlweise.SEEGERFABIAN:
                    // add extra rule for 3/4 players later (30 or 40 points for winners that didnt play)
                    foreach (Spiel spiel in spiele)
                    {
                        var _spieler = spiel.spieler;
                        int _spielerIndex = spieler.IndexOf(_spieler);
                        if (spiel.gewonnen == true)
                        {
                            newSpielstand[_spielerIndex] += (spiel.spielwert + 50);
                        }
                        if (spiel.gewonnen == false)
                        {
                            newSpielstand[_spielerIndex] -= ((2 * spiel.spielwert) + 50);
                            foreach (var gewinner in spieler.Where(s => spieler.IndexOf(s) != _spielerIndex))
                             {
                                 int _gewinnerIndex = spieler.IndexOf(gewinner);
                                 newSpielstand[_gewinnerIndex] += 40;

                             } 
                        }
                    }
 break;
            }
            spielStand = newSpielstand;
        }
       
    }
}