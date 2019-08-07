using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card, ICard
    {
        private const int InitialDamagePoint = 120;
        private const int InitialHealthPoints = 5;

        public TrapCard(string name)
            : base(name, InitialDamagePoint, InitialHealthPoints)
        {

        }
    }
}
