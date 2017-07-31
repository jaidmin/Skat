using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkatLib
{
    public class Abend
    {
        public int id { get; set; }
        public List<Spieler> spieler { get; set; }
        public List<Spiel> spiele { get; set; }
        public DateTime datetime { get; set; }
        public AbendRegeln abendRegeln { get; set; }
        public List<int> spielStand { get; set; }
        
        public Abend(List<Spieler> spieler, AbendRegeln abendRegeln)
        {
            this.datetime = System.DateTime.Now;
            this.spieler = spieler;
            this.spiele = new List<Spiel>();
            this.abendRegeln = abendRegeln;
            this.spielStand = new List<int>{0,0,0};
        
        }

        private Abend()
        {
            
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