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
        public Abend abend { get; set; }

        //passed variables
        public Spieler spieler { get; set; }
        public Spieler geber { get; set; }

        public int id { get; set; }
        public int abendId { get; set; }

        public Spieltyp spieltyp { get; set; }
        public Farbe farbe { get; set; }
        public Spielstaerke spielstaerke { get; set; }
        public Ansage ansage { get; set; }

        public bool bock { get; set; }
        public bool re { get; set; }
        public bool kontra { get; set; }
        public bool hand { get; set; }
        public bool ouvert { get; set; }

        public int punkte { get; set; }
        public int spielNummer { get; set; }

        //other variables
        public DateTime datetime { get; set; }

        public bool gewonnen { get; set; }

        public int spielwert { get; set; }

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