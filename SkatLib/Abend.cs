using System;
using System.Collections.Generic;
namespace SkatLib
{
    public class Abend
    {
        public int id { get; set; }
        public List<Spieler> spieler;
        public List<Spiel> spiele;
        public DateTime datetime;
        public AbendRegeln abendRegeln;
        public List<int> spielStand;
        
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