using System;
using System.Collections.Generic;

namespace ex50
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();

            int timeInZoo = 0;
            int workTimeZoo = 6;

            while (timeInZoo < workTimeZoo)
            {
                Console.WriteLine("Зоопарк\n");
                zoo.ShowAllCages(); 
                
                zoo.TryFindCage(out Cage requiredCage);

                if (requiredCage != null)
                {
                    requiredCage.ShowInfo();
                    timeInZoo++;
                }

                if (timeInZoo == workTimeZoo)
                {
                    Console.WriteLine("Зоопарк закрывается...");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Zoo
    {
        private List<Animal> _animals;
        private List<Cage> _cages;

        public Zoo()
        {
            _animals = new List<Animal>
            {
                new Animal("ЛЕВ", '♂', "РЁВ"),
                new Animal("СЛОН", '♀', "ТРУБЛЕНИЕ"),
                new Animal("ОРЕЛ", '♀', "ЗВОНКИЙ КЛЁКОТ"),
                new Animal("ОЛЕНЬ", '♂', "МЫЧАНИЕ")
            };

            _cages = new List<Cage>
            {
                new Cage(_animals[0], 4),
                new Cage(_animals[1], 10),
                new Cage(_animals[2], 6),
                new Cage(_animals[3], 2)
            };
        }

        public void ShowAllCages()
        {
            foreach (Cage cage in _cages)
            {
                Console.WriteLine($"|{cage.Animal.Name}|\n");
            }
        }

        public bool TryFindCage(out Cage requiredCage)
        {
            Console.Write("Куда бы вы хотели сходить? ");
            string name = Console.ReadLine();

            foreach (Cage cage in _cages)
            {
                if (cage.Animal.Name == name.ToUpper())
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
        public Cage(Animal animal, int count)
        {
            Animal = animal;
            Count = count;
        }

        public Animal Animal { get; private set; }
        public int Count { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"\n{Animal.Name}\nКол-во: {Count}\nПол животных: {Animal.Gender}\nИздающиеся звуки: {Animal.Voice}\n");
        }
    }

    class Animal
    {
        public Animal(string name, char gender, string voice)
        {
            Name = name;
            Gender = gender;
            Voice = voice;
        }

        public string Name { get; private set; }
        public char Gender { get; private set; }
        public string Voice { get; private set; }
    }
}
