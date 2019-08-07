using PlayersAndMonsters.Core.Factories.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace PlayersAndMonsters.Core.Factories
{
    public class CardFactory : ICardFactory
    {
        public ICard CreateCard(string type, string name)
        {
            Type cardType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.StartsWith(type));

            ICard card = (ICard)Activator.CreateInstance(cardType, name);

                return card;
        }
    }
}
