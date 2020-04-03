using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURAK
{
    class Table
    {
        public List<Card> AtackCards { get; private set; }

        public List<Card> DefendCards { get; private set; }

        public Table()
        {
            AtackCards = new List<Card>(6);
            DefendCards = new List<Card>(6);
        }
        public void Bita()
        {
            AtackCards.Clear();
            DefendCards.Clear();
        }
    }
}
