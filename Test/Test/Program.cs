using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            BazaZaVajeEntities context = new BazaZaVajeEntities();

            //Vsi dobavitelji

            var x1 = from a in context.DOBAVITELJ
                     select a;
            foreach(var y in x1)
            {
                Console.WriteLine(y.D_IME+" "+y.D_KONTAKT);
            }
            Console.WriteLine("-------------------------------------------------------------------");
            
            DateTime datum = DateTime.Parse("20.1.2004");
            var x2 = from a in context.PRODUKT
                     where a.P_DATUM < datum
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_ZALOGA, Cena = a.P_CENA };

            foreach(var y in x2){
                Console.WriteLine(y.Opis,y.Zaloga,y.MinZaloga,y.Cena);
            }
           
            Console.WriteLine("-------------------------------------------------------------------");

            DateTime datumDanes = DateTime.Now;
            datumDanes=datumDanes.AddDays(365);
            var x3 = from a in context.PRODUKT
                     where a.P_DATUM < datumDanes
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_ZALOGA, Cena = a.P_CENA, Zapadlost=datumDanes };

            foreach (var y in x3)
            {
                Console.WriteLine(y.Opis, y.Zaloga, y.MinZaloga, y.Cena, y.Zapadlost);
            }


            Console.WriteLine("-------------------------------------------------------------------");

            DateTime datum2 = DateTime.Parse("15.1.2004");
            var x22 = from a in context.PRODUKT
                     where a.P_DATUM > datum2 && a.P_CENA<50
                     select new { Opis = a.P_OPIS, Zaloga = a.P_ZALOGA, MinZaloga = a.P_ZALOGA, Cena = a.P_CENA };

            foreach (var y in x22)
            {
                Console.WriteLine(y.Opis, y.Zaloga, y.MinZaloga, y.Cena);
            }

            Console.WriteLine("-------------------------------------------------------------------");

            var x4 = from a in context.DOBAVITELJ
                     where a.D_KONTAKT.StartsWith("Smith")
                     select a;

            foreach (var y in x4)
            {
                Console.WriteLine(y.D_KONTAKT);
            }

            Console.WriteLine("-------------------------------------------------------------------");

            

            Console.WriteLine("-------------------------------------------------------------------");

            var x5 = (from a in context.PRODUKT
                     select a.D_KODA).Distinct();

            foreach (var y in x5)
            {
                Console.WriteLine(y);
            }

            Console.WriteLine("-------------------------------------------------------------------");

            var x6 = context.DOBAVITELJ.Where(e => !x5.Any(p => p == e.D_KODA));

            foreach (var y in x6)
            {
                Console.WriteLine(y.D_KODA);
            }

            Console.WriteLine("-------------------------------------------------------------------");

            var x7 = context.KUPEC.Sum(e => e.KUP_STANJE);

            Console.WriteLine(x7);

            Console.WriteLine("-------------------------------------------------------------------");
            

            Console.WriteLine("-------------------------------------------------------------------");
            //
            Console.ReadLine();
        }
    }
}
