namespace BusinessLogic
{
    public abstract class Persoana
    {
        private static int numarUnic;

        public Identitate Identitate { get; set; }

        public int ID { get; set; }

        static Persoana()
        {
            numarUnic = 1000;
        }

        public Persoana(string firstName, string lastName, int age)
        {
            Identitate = new Identitate()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age
            };

            ID = numarUnic++;
        }

        public virtual string GetIdentityAsString()
        {
            return Identitate.FirstName + " " +
                Identitate.LastName +
                " ID " + ID +
                " Age " + Identitate.Age;
        }

        public abstract string GetSpecifics();
    }
}
