using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURAK
{
    class Coloda
    {
        public List<Card> ColodaCard { get; private set; }
        public Mast Kozir { get; private set; }

        public Coloda()
        {
            ColodaCard = new List<Card>(36);
            for (int i=0; i<4; i++)
                for (int j =0; j<9; j++)
                    ColodaCard.Add( new Card ((Mast)i, (Rank)j));
            TusuiColoda();
        }

        void TusuiColoda()
        {
            var colodaTusovana = new Card[36];
            var rnd = new Random();
            for (int i=0; i<36; i++)
            {
                var index = rnd.Next(0, 36);
                while (colodaTusovana[index] != null)
                    index = (index+1)%36;
                colodaTusovana[index] = ColodaCard[i];
            }
            ColodaCard = colodaTusovana.ToList();
            Kozir = (Mast)rnd.Next(0, 4);
        }
    }
}
