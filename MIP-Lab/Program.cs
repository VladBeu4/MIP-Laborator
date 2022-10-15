using System;
using BusinessLogic;

namespace MIP_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");

            var studenti = new Student[3]
            {
                new Student() { FirstName = "Ion", LastName = "Popescu", Age = 23, Nota = Calificativ.Insuficient },
                new Student() { FirstName = "Andrei", LastName = "Popa", Age = 28, Nota = Calificativ.Bine },
                new Student() { FirstName = "Maria", LastName = "Smith", Age = 25, Nota = Calificativ.Excelent },
            };

            for (int i = 0; i < 3; i++)
            {
                switch (studenti[i].Nota)
                {
                    case Calificativ.Insuficient:
                    case Calificativ.Suficient:
                        studenti[i].Bursa = false;
                        break;
                    case Calificativ.Bine:
                    case Calificativ.FoarteBine:
                    case Calificativ.Excelent:
                        studenti[i].Bursa = true;
                        break;
                }
            }
            Console.WriteLine("Studentii cu bursa:");

            for (int i = 0; i < 3; i++)
            {
                if (studenti[i].Bursa.Value)
                {
                    Console.WriteLine(studenti[i]);
                }
            }

            Console.WriteLine("Studentii fara bursa:");
            for (int i = 0; i < 3; i++)
            {
                if (!studenti[i].Bursa.Value)
                {
                    Console.WriteLine(studenti[i]);
                }
            }

            Console.ReadKey();
        }
    }
}
