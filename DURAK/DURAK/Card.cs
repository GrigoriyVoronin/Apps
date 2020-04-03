using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DURAK
{
    class Card
    {
        public Mast Mast { get; private set; }

        public Rank Rank { get; private set; }

        public Card(Mast mast, Rank rank)
        {
            Mast = mast;
            Rank = rank;
        }

        public bool CanKill(Card atackCard, Mast kozir)
        {
            if (atackCard.Mast == Mast && atackCard.Rank < Rank)
                return true;
            if (Mast == kozir)
                return true;
            return false;
        }

        public bool CanAdd(List<Card> cardsAt, List<Card> cardsDef)
        {
            if (cardsAt.Count == 0)
                return true;
            foreach (var card in cardsAt)
                if (card.Rank == Rank)
                    return true;
            foreach (var card in cardsDef)
                if (card.Rank == Rank)
                    return true;
            return false;
        }
    }
}
