using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class Penar : ISortable
    {
        public List<Creion> Creioane { get; set; }

        public void Sort()
        {
            Creioane = Creioane.OrderBy(x => x.Lungime).ToList();
        }
    }
}
