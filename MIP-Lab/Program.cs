using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BusinessLogic;

namespace MIP_Lab
{
    internal class Program
    {
        private static List<Student> CitireDinFisier_1()
        {
            var lines = File.ReadAllLines("studenti.txt");

            var studenti = new List<Student>();

            for (var i = 0; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');

                var firstName = values[0];
                var lastName = values[1];
                var age = uint.Parse(values[2]);
                var calificativ = (Calificativ)Enum.Parse(typeof(Calificativ), values[3]);

                var student = new Student(firstName, lastName, (int)age)
                {
                    Nota = calificativ
                };

                studenti.Add(student);
            }

            return studenti;
        }

        private static List<Student> CitireDinFisier_2()
        {
            var lines = File.ReadAllLines("studenti.txt");

            return lines.ToList().Select(x =>
            {
                var values = x.Split(',');

                var firstName = values[0];
                var lastName = values[1];
                var age = uint.Parse(values[2]);
                var calificativ = (Calificativ)Enum.Parse(typeof(Calificativ), values[3]);

                var student = new Student(firstName, lastName, (int)age)
                {
                    Nota = calificativ
                };

                return student;
            }).ToList();
        }

        private static List<Student> CitireDinFisier_3()
        {
            var lines = File.ReadAllLines("studenti.txt");

            return lines.ToList().Select(x => Parse(x)).ToList();
        }

        private static Student Parse(string line)
        {
            var values = line.Split(',');

            var firstName = values[0];
            var lastName = values[1];
            var age = uint.Parse(values[2]);
            var calificativ = (Calificativ)Enum.Parse(typeof(Calificativ), values[3]);

            var student = new Student(firstName, lastName, (int)age)
            {
                Nota = calificativ
            };

            return student;
        }

        private static List<Student> CitireDinFisier_4()
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

            return lines.ToList().Select(x => Parse5(x)).ToList();
        }

        private static Student Parse5(string line)
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
                Console.WriteLine("formatex");
            }
            catch (StudentAgeException ex)
            {
                Console.WriteLine("studentagex");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("argex");
            }

            return student;
        }

        public class StudentAgeException : Exception
        {

        }

        private static void Main(string[] args)
        {
            var studenti = CitireDinFisier_4();

            Console.WriteLine("Hello world!");

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
