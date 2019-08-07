using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card, ICard
    {
        private const int InitialDamagePoint = 5;
        private const int InitialHealthPoints = 80;

        //Has 5 damage points and 80 health points.
        public MagicCard(string name)
            : base(name, InitialDamagePoint, InitialHealthPoints)
        {

        }
    }
}
