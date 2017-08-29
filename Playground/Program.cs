using System;
using System.Collections;
using System.Collections.Generic;
using SkatLib;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Playground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Initializer.SeedData();
            var _context = new SkatContext();
            List<Spiel> spiele = _context.spiele
                                 .Include(s => s.regeln)
                                    .ThenInclude(r => r.bockRamsch)
                                 .Include(s => s.spieler)
                                 .Include(s => s.geber)
                                 .ToList();
            Console.WriteLine(spiele[0].geber.name);
            Console.WriteLine(spiele[0].regeln.bockRamsch.KontraGewonnen);
            Console.WriteLine("Hello World!");
            List<Abend> abende  = _context.abende
                                 .Include(a => a.regeln)
                                 .Include(a => a.spiele)
                                 .Include(a => a.spieler)
                                 .ToList();
            Console.WriteLine(abende[0].regeln.eingepassterRamsch);

            Abend abend = abende[0];
            Console.WriteLine(abend.spiele.Count);
            abend.addSpiel(spiele[0]);
            Console.WriteLine(abend.spiele.Count);
            Console.WriteLine(String.Join<int>(",",abend.spielStand));
            abend.calculateSpielstand();
            Console.WriteLine(String.Join<int>(",",abend.spielStand));

        }
    }
}
