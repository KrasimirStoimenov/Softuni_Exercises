namespace BattleCards.Data.Models
{
    public class UserCard
    {
        public string UserId { get; init; }

        public User User { get; init; }

        public string CardId { get; init; }

        public Card Card { get; init; }
    }
}
//•	Has UserId – a string
//•	Has User – a User object
//•	Has CardId – an int
//•	Has Card – a Card object
