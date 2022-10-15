namespace BusinessLogic
{
    public class Student
    {
        private Identitate identitate { get; set; }
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

        public Student(string firstName, string lastName, int age)
        {
            identitate = new Identitate()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };
        }

        public override string ToString()
        {
            return "Studentul " + identitate.FirstName + " " + identitate.LastName + " are calificativul " + Nota + " cu nota " + (int)Nota + ".";
        }
    }
}
