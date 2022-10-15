using System;

namespace MIP_Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");

            var student = new Student();

            Console.WriteLine("Prenume:");
            student.FirstName = Console.ReadLine();

            Console.WriteLine("Nume:");
            student.LastName = Console.ReadLine();

            Console.WriteLine("Varsta:");
            student.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Calificativ:");
            student.Nota = (Calificativ)Enum.Parse(typeof(Calificativ), Console.ReadLine(), true);

            var studenti = new Student[3]
            {
                new Student() { FirstName = "Ion", LastName = "Popescu", Age = 23, Nota = Calificativ.Insuficient },
                new Student() { FirstName = "Andrei", LastName = "Popa", Age = 28, Nota = Calificativ.Bine },
                student
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
