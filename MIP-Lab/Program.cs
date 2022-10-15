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
                new Student("Ion", "Popescu", 23) { Nota = Calificativ.Insuficient },
                new Student("Andrei", "Popa", 28) { Nota = Calificativ.Bine },
                new Student("Maria", "Smith", 25) { Nota = Calificativ.Excelent }
            };

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
