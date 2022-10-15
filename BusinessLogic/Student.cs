namespace BusinessLogic
{
    public class Student
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
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

        public override string ToString()
        {
            return "Studentul " + FirstName + " " + LastName + " are calificativul " + Nota + " cu nota " + (int)Nota + ".";
        }
    }
}
