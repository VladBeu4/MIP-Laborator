using System.Collections.Generic;

namespace BusinessLogic
{
    public class Classroom : ISortable
    {
        public List<Student> Studenti { get; set; }
        public int An { get; set; }

        public void Sort()
        {
            Studenti.Sort();
        }
    }
}
