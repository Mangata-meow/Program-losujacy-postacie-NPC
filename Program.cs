using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program_losujący_postacie_NPC
{
    public interface INPC
    {
        void Przedstaw_sie();
    }

    public class Wojownik : INPC //Stworzenie klasy wojownik
    {
        public void Przedstaw_sie()
        {
            Console.WriteLine("Jestem Wojownikiem, walczę mieczem.");
        }
    }
    public class Mag : INPC //Stworzenie klasy mag
    {
        public void Przedstaw_sie()
        {
            Console.WriteLine("Jestem Magiem, władającym magią żywiołów.");
        }
    }
    public class Zlodziej : INPC //Stworzenie klasy złodziej
    {
        public void Przedstaw_sie()
        {
            Console.WriteLine("Jestem Złodziejem, nie mam atrybutów.");
        }
    }
    public interface IFabrykaNPC
    {
        INPC Create_NPC(); //Zwraca nową postać
    }
    public class Fabryka_Wojownika : IFabrykaNPC //Tworzenie wojownika
    {
        public INPC Create_NPC()
        {
            return new Wojownik();
        }
    }
    public class Fabryka_Maga : IFabrykaNPC //Tworzenie maga
    {
        public INPC Create_NPC()
        {
            return new Mag();
        }
    }
    public class Fabryka_Zlodzieja : IFabrykaNPC //Tworzenie złodzieja
    {
        public INPC Create_NPC()
        {
            return new Zlodziej();
        }
    }
    class Program
    {
        static void Main()
        {
            Random random = new Random(); //Losowanie postaci (wojownik/mag/złodziej)
            IFabrykaNPC fabryka;
            int losowa_Postać = random.Next(3);

            switch (losowa_Postać)
            {
                case 0:
                    fabryka = new Fabryka_Wojownika();
                    break;
                case 1:
                    fabryka = new Fabryka_Maga();
                    break;
                default:
                    fabryka = new Fabryka_Zlodzieja();
                    break;
            }
            INPC npc = fabryka.Create_NPC(); //Tworzy losową postać
            npc.Przedstaw_sie(); //Wywołuje losową postać

            Console.ReadKey();
        }
    }
}
