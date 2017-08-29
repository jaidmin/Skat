namespace SkatLib
{
    public class Regeln
    {
        public Regeln()
        {

        }
        public int id { get; set; }

        public SchneiderAb schneiderAb { get; set; }
        public BockRamsch bockRamsch { get; set; }
        public bool kontraErlaubt { get; set; } 
        public bool reErlaubt { get; set; } 
        public bool kontraNurBeiReizen { get; set; }
        public Grandwerte grandwert { get; set; }
        public bool grandHandBeiRamsch { get; set; }
        public bool eingepassterRamsch { get; set; }

    }

    public enum SchneiderAb
    {
        DREISSIG=30,
        EINUNDDREISSIG=31
    }
    
    public enum Grandwerte
    {
        ACHTZEHN = 18,
        ZWANZIG=20,
        ZWEIUNDZWANZIG=22,
        VIERUNDZWANZIG=24
    }

    public enum Zaehlweise
    {
        KLASSISCH,
        BIERLACHS,
        SEEGERFABIAN
    }
    
    

    public class BockRamsch
    {
        public BockRamsch()
        {

        }
        public int id { get; set; }
        public bool KontraVerloren { get; set; }
        public bool KontraGewonnen { get; set; }
        public bool SchneiderVerloren { get; set; }
        public bool SchneiderGewonnen { get; set; }
        public bool Spaltarsch { get; set; }
        
    }
    
    
}