﻿using System;

namespace SkatLib
{
    public enum Spieltyp
    {
        FARBE, GRAND, NULL, RAMSCH
    }

    public enum Farbe
    {
        KREUZ = 12, PIK = 11, HERZ = 10, KARO = 9
    }

    public enum Spielstaerke
    {
        M1 = 2, M2 = 3, M3 = 4, M4 = 5, O1 = 2, O2 = 3, O3 = 4, O4 = 5
    }

    public enum Ansage
    {
        KEINE, SCHNEIDER, SCHWARZ
    }

    public class Spiel
    {
        //abend is passed to acces ruleset--> will be changed later, when ruleset is accesible via Database
        public Abend abend;

        //passed variables
        public Spieler spieler;
        public Spieler geber;

        public int id { get; set; }
        public int abendId;

        public Spieltyp spieltyp;
        public Farbe farbe;
        public Spielstaerke spielstaerke;
        public Ansage ansage;

        public bool bock;
        public bool re;
        public bool kontra;
        public bool hand;
        public bool ouvert;

        public int punkte;
        public int spielNummer;

        //other variables
        public DateTime datetime;

        public bool gewonnen;

        public int spielwert;

        private Spiel()
        {
            
        }
        public Spiel(Abend abend, int abendId,  int spielNummer, Spieler spieler, Spieler geber, Spieltyp spieltyp, Farbe farbe, Spielstaerke spielstaerke, Ansage ansage, bool bock, bool re, bool kontra, bool hand, bool ouvert, int punkte)
        {
            //pass parameters to local variables
            this.abendId = abendId;
            this.spielNummer = spielNummer;
            this.spieler = spieler;
            this.geber = geber;
            this.spieltyp = spieltyp;
            this.farbe = farbe;
            this.spielstaerke = spielstaerke;
            this.ansage = ansage;
            this.bock = bock;
            this.re = re;
            this.kontra = kontra;
            this.hand = hand;
            this.ouvert = ouvert;
            this.punkte = punkte;

            //init other variables
            this.datetime = DateTime.Now;
            calculateSpielwert();
            calculateSieger();
        }

        private void calculateSieger()
        {
            if (spieltyp == Spieltyp.FARBE || spieltyp == Spieltyp.GRAND)
            {
                if (punkte > 60)
                {
                    gewonnen = true;
                }
                else
                {
                    gewonnen = false;
                }
            }
        }

        //check which type of game was played and calculate the points based on that
        private void calculateSpielwert()
        {
            switch (spieltyp){
                case Spieltyp.FARBE:
                    spielwert = (int)farbe * (int)spielstaerke;
                    break;
                case Spieltyp.NULL:
                    if (hand && ouvert)
                    {
                        spielwert = 59;
                    }
                    else if(ouvert)
                    {
                        spielwert = 46;
                    }
                    else if(hand)
                    {
                        spielwert = 35;
                    }
                    else 
                    {
                        spielwert = 23;
                    }
                    break;
                case Spieltyp.GRAND:
                    spielwert = (int)abend.abendRegeln.grandwert * (int)spielstaerke;
                    break;
                case Spieltyp.RAMSCH:
                    break;
            }
            
        }

        public Spiel(int abendId, Ansage ansage)
        {
            this.abendId = abendId;

        }
    }
}