using System;
using System.Collections.Generic;
using System.Xml.Linq;

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
                new Animal("ЛЬВИЦА", '♀', "РЁВ"),
                new Animal("СЛОН", '♂', "ТРУБЛЕНИЕ"),
                new Animal("СЛОНИХА", '♀', "ТРУБЛЕНИЕ"),
                new Animal("ОРЕЛ", '♂', "ЗВОНКИЙ КЛЁКОТ"),
                new Animal("ОРЛИЦА", '♀', "ЗВОНКИЙ КЛЁКОТ"),
                new Animal("ОЛЕНЬ", '♂', "МЫЧАНИЕ"),
                new Animal("ОЛЕНИХА", '♀', "МЫЧАНИЕ"),
            };

            _cages = new List<Cage>
            {
                new Cage(FillCage(_animals[0], 2, _animals[1], 2), "ЛЬВЫ"),
                new Cage(FillCage(_animals[2], 1, _animals[3], 1), "СЛОНЫ"),
                new Cage(FillCage(_animals[4], 5, _animals[5], 3), "ОРЛЫ"),
                new Cage(FillCage(_animals[6], 2, _animals[6], 4), "ОЛЕНИ"),
            };
        }

        public List<Animal> FillCage(Animal animalMale, int countMales, Animal animalFemale, int countFemales)
        {
            List<Animal> animalsInCage = new List<Animal>();

            for (int i = 0; i < countMales; i++)
            {
                animalsInCage.Add(animalMale);
            }

            for (int i = 0; i < countFemales; i++)
            {
                animalsInCage.Add(animalFemale);
            }

            return animalsInCage;
        }

        public void ShowAllCages()
        {
            foreach (Cage cage in _cages)
            {
                Console.WriteLine($"|{cage.Name}|\n");
            }
        }

        public bool TryFindCage(out Cage requiredCage)
        {
            Console.Write("Куда бы вы хотели сходить? ");
            string name = Console.ReadLine();

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
        private List<Animal> _animalsInCage = new List<Animal>();

        public Cage(List<Animal> animals, string name)
        {
            _animalsInCage.AddRange(animals);
            Name = name;
        }

        public string Name { get; private set; }

        public void ShowInfo()
        {
            foreach (Animal animal in _animalsInCage)
            {
                Console.WriteLine($"\n{animal.Name}\nПол животного: {animal.Gender}\nИздающиеся звуки: {animal.Voice}\n");
            }
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
