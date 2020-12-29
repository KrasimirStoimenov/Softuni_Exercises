using Zoo.Mammal;

namespace Zoo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Bear bear = new Bear("teddy");

            System.Console.WriteLine(bear.Name);
        }
    }
}