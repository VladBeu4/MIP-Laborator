namespace BusinessLogic
{
    public class Persoana
    {
        private static int numarUnic;

        protected Identitate identitate { get; set; }

        public int ID { get; set; }

        static Persoana()
        {
            numarUnic = 1000;
        }

        public Persoana(string firstName, string lastName, int age)
        {
            identitate = new Identitate()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };

            ID = numarUnic++;
        }
    }
}
