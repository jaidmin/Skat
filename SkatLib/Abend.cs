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
       
    }
}