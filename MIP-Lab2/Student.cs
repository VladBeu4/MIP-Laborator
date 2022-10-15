namespace MIP_Lab2
{
    internal class Student
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public Calificativ Nota { get; set; }
        public bool? Bursa { get; set; }

        public override string ToString()
        {
            return "Studentul " + FirstName + " " + LastName + " are calificativul " + Nota + " cu nota " + (int)Nota + ".";
        }
    }
}
