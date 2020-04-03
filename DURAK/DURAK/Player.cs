using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURAK
{
    class Player
    {
        public List<Card> Ruka { get; private set; }
        public bool Atacker { get; set; }
        public bool Deffender { get; set; }
        public string Name { get; set; }

        public Player()
        {
            Ruka = new List<Card>(6);
        }

        public void PopRuku(Coloda coloda)
        {
            while (Ruka.Count < 6 && coloda.ColodaCard.Count > 0)
            {
                Ruka.Add(coloda.ColodaCard.Last());
                coloda.ColodaCard.RemoveAt(coloda.ColodaCard.Count - 1);
            }
        }

        public bool CanAtack(Card card, Table table)
        {
            if (card.CanAdd(table.AtackCards, table.DefendCards))
            {
                table.AtackCards.Add(card);
                Ruka.Remove(card);
                return true;
            }
            return false;
        }

        public bool CanDeffend(Card card, int index, Mast kozir, Table table)
        {
            if (card.CanKill(table.AtackCards[index], kozir) && table.AtackCards.Count > table.DefendCards.Count)
            {
                table.DefendCards.Add(card);
                Ruka.Remove(card);
                return true;
            }
            return false;
        }

        public void Take(Table table)
        {
            while (table.AtackCards.Count != 0)
            {
                Ruka.Add(table.AtackCards.Last());
                table.AtackCards.RemoveAt(table.AtackCards.Count - 1);
            }
            while (table.DefendCards.Count != 0)
            {
                Ruka.Add(table.DefendCards.Last());
                table.DefendCards.RemoveAt(table.DefendCards.Count - 1);
            }
        }
    }
}
