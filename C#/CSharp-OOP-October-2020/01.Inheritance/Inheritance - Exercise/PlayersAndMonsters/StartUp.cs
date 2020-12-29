using PlayersAndMonsters.Hero.Wizard;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SoulMaster sm = new SoulMaster("S", 300);

            System.Console.WriteLine(sm);
        }
    }
}