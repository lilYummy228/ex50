using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex50
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            while (true)
            {
                Console.WriteLine("Зоопарк\n");

                zoo.ShowAllCages();

                Console.Write("Куда бы вы хотели сходить? ");

                zoo.TryFindCage(Console.ReadLine(), out Cage requiredCage);

                requiredCage?.ShowInfo();

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Zoo
    {
        private List<Cage> _cages;

        public Zoo()
        {
            _cages = new List<Cage>
            {
                new Cage("ВОЛЬЕР С ЛЬВАМИ", 4, "САМЦЫ", "РЁВ"),
                new Cage("ВОЛЬЕР СО СЛОНАМИ", 10, "САМКИ И САМЦЫ", "ТРУБЛЕНИЕ"),
                new Cage("ВОЛЬЕР С ОРЛАМИ", 6, "САМКИ", "ЗВОНКИЙ КЛЁКОТ"),
                new Cage("ВОЛЬЕР С ОЛЕНЯМИ", 2,"САМЦЫ", "МЫЧАНИЕ"),
            };
        }

        public void ShowAllCages()
        {
            foreach (Cage cage in _cages)
            {
                Console.WriteLine($"|{cage.Name}|\n");
            }
        }

        public bool TryFindCage(string name, out Cage requiredCage)
        {

            foreach (Cage cage in _cages)
            {
                if (cage.Name == name.ToUpper())
                {
                    requiredCage = cage;
                    return true;
                }
            }

            Console.WriteLine("Такого вольера нет в зоопарке...");
            requiredCage = null;
            return false;
        }
    }

    class Cage
    {
        public Cage(string name, int count, string gender, string voice)
        {
            Name = name;
            Count = count;
            Gender = gender;
            Voice = voice;
        }

        public string Name { get; private set; }
        public int Count { get; private set; }
        public string Gender { get; private set; }
        public string Voice { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"\n{Name}\nКол-во: {Count}\nПол животных: {Gender}\nИздающиеся звуки: {Voice}\n");
        }
    }
}
