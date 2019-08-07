using System;
using System.Collections.Generic;
using System.Linq;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private IDictionary<string, ICard> cardsByName;

        public CardRepository()
        {
            cardsByName = new Dictionary<string, ICard>();
        }
        public int Count => this.cardsByName.Count;

        public IReadOnlyCollection<ICard> Cards => this.cardsByName.Values.ToList();

        public void Add(ICard card)
        {
            ThrowIfCardIsNull(card, "Card cannot be null!");

            if (this.cardsByName.ContainsKey(card.Name))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }

            this.cardsByName.Add(card.Name, card);

        }


        public ICard Find(string name)
        {
            ICard card = null;
            if (this.cardsByName.ContainsKey(name))
            {
                card = this.cardsByName[name];
            }
            return card;
        }

        public bool Remove(ICard card)
        {
            ThrowIfCardIsNull(card, "Card cannot be null!");

            bool hasRemove = this.cardsByName.Remove(card.Name);

            return hasRemove;
        }


        private static void ThrowIfCardIsNull(ICard card, string message)
        {
            if (card == null)
            {
                throw new ArgumentException(message);
            }
        }
    }
}
