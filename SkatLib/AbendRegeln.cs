namespace SkatLib
{
    public class AbendRegeln
    {
        public SchneiderAb schneiderAb;
        public BockRamsch bockRamsch;
        public bool kontraErlaubt;
        public bool reErlaubt;
        public bool kontraNurBeiReizen;
        public Grandwerte grandwert;
        public bool grandHandBeiRamsch;
        public bool eingepassterRamsch;
        public Zaehlweise zaehlweise;

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
    
    

    public struct BockRamsch
    {
        public bool KontraVerloren;
        public bool KontraGewonnen;
        public bool SchneiderVerloren;
        public bool SchneiderGewonnen;
        public bool Spaltarsch;
        
    }
    
    
}