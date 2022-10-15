namespace BusinessLogic
{
    public class Student
    {
        public const string UNIVERSITATE = "ULBS";

        private static int numarUnic;

        private Identitate identitate { get; set; }

        public Calificativ Nota { get; set; }

        public int ID { get; set; }

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

        static Student()
        {
            numarUnic = 1000;
        }

        public Student(string firstName, string lastName, int age)
        {
            identitate = new Identitate()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };

            ID = numarUnic++;
        }

        public override string ToString()
        {
            return "Studentul " + identitate.FirstName + " " + identitate.LastName + " ID: " + ID + " are calificativul " + Nota + " cu nota " + (int)Nota + ".";
        }
    }
}
