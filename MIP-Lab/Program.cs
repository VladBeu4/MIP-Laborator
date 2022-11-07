using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BusinessLogic;

namespace MIP_Lab
{
    internal class Program
    {
        private static List<Student> CitireDinFisier()
        {
            string[] lines = null;
            while (lines == null)
            {
                try
                {
                    lines = File.ReadAllLines("studenti.txt");
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine("Fisierul nu exista!");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.GetType().Name);
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();
                }
            }

            return lines
                .ToList()
                .Select(x => Parse(x))
                .Where(x => x != null)
                .ToList();
        }

        private static Student Parse(string line)
        {
            Student student = null;

            try
            {
                var values = line.Split(',');

                var firstName = values[0];
                var lastName = values[1];
                var age = int.Parse(values[2]);

                if (age < 18)
                {
                    throw new StudentAgeException();
                }
                var calificativ = (Calificativ)Enum.Parse(typeof(Calificativ), values[3]);

                student = new Student(firstName, lastName, age)
                {
                    Nota = calificativ
                };
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Could not parse age!");
            }
            catch (StudentAgeException ex)
            {
                Console.WriteLine("Age less than 18!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Could not parse enum!");
            }

            return student;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");

            var studenti = CitireDinFisier();

            Console.WriteLine("Studentii cu bursa:");
            studenti
                .Where(x => x.Bursa.Value)
                .ToList()
                .ForEach(x => Console.WriteLine(x));


            Console.WriteLine("Studentii fara bursa:");
            studenti
                .Where(x => x.Bursa == false)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            Console.WriteLine("Studentii in ordinea numelui:");
            studenti
                .OrderBy(x => x.Identitate.FirstName)
                .ToList()
                .ForEach(x => Console.WriteLine(x));

            var classroom = new Classroom()
            {
                Studenti = studenti,
                An = 3
            };

            var penar = new Penar()
            {
                Creioane = new List<Creion>()
                {
                    new Creion() { Lungime = 3 },
                    new Creion() { Lungime = 2 },
                    new Creion() { Lungime = 10 },
                    new Creion() { Lungime = 7 },
                }
            };

            var sortables = new List<ISortable>()
            {
                classroom,
                penar
            };

            sortables.ForEach(x => x.Sort()); //Sortarea implicita din ISortable

            Console.WriteLine("Studentii in ordinea notei:");
            for (var i = 0; i < classroom.Studenti.Count(); i++)
            {
                Console.WriteLine(classroom.Studenti[i]);
            }

            Console.ReadKey();
        }
    }
}
