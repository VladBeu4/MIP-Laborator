﻿using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic;

namespace MIP_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello world!");

            var studenti = new List<Student>()
            {
                new Student("Ion", "Popescu", 23) { Nota = Calificativ.Insuficient },
                new Student("Andrei", "Popa", 28) { Nota = Calificativ.Excelent },
                new Student("Maria", "Smith", 25) { Nota = Calificativ.Bine }
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

            var classroom = new Classroom()
            {
                Studenti = studenti,
                An = 3
            };

            classroom.Sort();

            Console.WriteLine("Studentii in ordinea notei:");
            for (var i = 0; i < classroom.Studenti.Count(); i++)
            {
                Console.WriteLine(classroom.Studenti[i]);
            }

            Console.ReadKey();
        }
    }
}
