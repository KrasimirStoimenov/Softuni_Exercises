using System;

namespace _01._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                AdvertisementMessage ad = new AdvertisementMessage();

                Console.WriteLine(ad);
            }
        }
    }
    //class AdvertisementMessage
    //{
    //    public string[] Phrases = new string[] {"Excellent product.",
    //        "Such a great product.", "I always use that product.",
    //        "Best product of its category.", "Exceptional product.",
    //        "I can’t live without this product."};

    //    public string[] Events = new string[] { "Now I feel good.",
    //        "I have succeeded with this product.", "Makes miracles. I am happy of the results!",
    //        "I cannot believe but now I feel awesome.",
    //        "Try it yourself, I am very satisfied.", "I feel great!" };

    //    public string[] Authors = new string[] { "Diana", "Petya", "Stella",
    //        "Elena", "Katya", "Iva", "Annie", "Eva" };

    //    public string[] Cities = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

    //    Random rand = new Random();

    //    public override string ToString()
    //    {
    //        int phraseIndex = rand.Next(0, Phrases.Length);
    //        int eventsIndex = rand.Next(0, Events.Length);
    //        int authorsIndex = rand.Next(0, Authors.Length);
    //        int citiesIndex = rand.Next(0, Cities.Length);
    //        //{phrase} {event} {author} – {city}
    //        return $"{Phrases[phraseIndex]} {Events[eventsIndex]} {Authors[authorsIndex]} - {Cities[citiesIndex]}";
    //    }
    //}
}
