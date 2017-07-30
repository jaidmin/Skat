using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SkatLib;

namespace Api
{
    public class Initializer
    {
        public static void SeedData()
        {
            var spieler = new List<Spieler>();
            var spieler1 = new Spieler("Jan");
            var spieler2 = new Spieler("Magnus");
            var spieler3 = new Spieler("Johannes");

            spieler.Add(spieler1);
            spieler.Add(spieler2);
            spieler.Add(spieler3);


            AbendRegeln regeln = new AbendRegeln
            {
                bockRamsch = new BockRamsch
                {
                    KontraGewonnen = true,
                    KontraVerloren = true,
                    SchneiderGewonnen = true,
                    SchneiderVerloren = true,
                    Spaltarsch = true
                },
                eingepassterRamsch = true,
                grandHandBeiRamsch = false,
                grandwert = Grandwerte.ACHTZEHN,
                kontraErlaubt = true,
                kontraNurBeiReizen = true,
                reErlaubt = true,
                schneiderAb = SchneiderAb.DREISSIG,
                zaehlweise = Zaehlweise.KLASSISCH


            };
            var abend = new Abend(spieler, regeln);





            var spiel = new Spiel(abend, abend.id, 0, spieler1, spieler2, Spieltyp.FARBE, Farbe.HERZ, Spielstaerke.M1, Ansage.KEINE, false, true, true, false, false, 59);



            using (var skatContext = new SkatContext())
            {
                skatContext.abende.Add(abend);
                skatContext.spiele.Add(spiel);
                skatContext.spieler.Add(spieler1);
                skatContext.spieler.Add(spieler2);
                skatContext.spieler.Add(spieler3);
                skatContext.SaveChanges();
            }
        }



        public static void DbTest()
        {

            using (var skatContext = new SkatContext())
            {
                var _abende = skatContext.abende.ToList();
                var _spiele = skatContext.spiele.ToList();
                var _spieler = skatContext.spieler.ToList();
                Console.WriteLine($"Die Datenbank enthält momentan {_abende.Count} Abende");
                Console.WriteLine($"ID des ersten Abends ist: {_abende[0].id}");
                Console.WriteLine($"Die Datenbank enthält momentan {_spiele.Count} Spiele");
                Console.WriteLine($"ID des ersten Spiele ist: {_spiele[0].id}");
                Console.WriteLine($"Die Datenbank enthält momentan {_spieler.Count} Spieler");
                Console.WriteLine($"Name des ersten Spieler ist: {_spieler[0].name}");

            }
        }
    }
}
}
