using System;

namespace BusinessLogic
{
    public class Student : Persoana, IComparable<Student>
    {
        public const string UNIVERSITATE = "ULBS";

        public Calificativ Nota { get; set; }

        public bool? Bursa
        {
            get
            {
                switch (Nota)
                {
                    case Calificativ.Bine:
                    case Calificativ.FoarteBine:
                    case Calificativ.Excelent:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public Student(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }

        public override string GetIdentityAsString()
        {
            return "Studentul " + base.GetIdentityAsString();
        }

        public override string GetSpecifics()
        {
            return "are calificativul " + Nota + " cu nota " + (int)Nota + ".";
        }

        public override string ToString()
        {
            return GetIdentityAsString() + " " + GetSpecifics();
        }

        public int CompareTo(Student other)
        {
            return Nota.CompareTo(other.Nota);
        }
    }
}
