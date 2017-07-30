using System;

namespace SkatLib
{

    public class Spieler
    {
        public int id { get; set; }
        public String name { get; set; }


        public Spieler(string name)
        {
            this.name = name;
        }

        private Spieler()
        {
            
        }
    }
}