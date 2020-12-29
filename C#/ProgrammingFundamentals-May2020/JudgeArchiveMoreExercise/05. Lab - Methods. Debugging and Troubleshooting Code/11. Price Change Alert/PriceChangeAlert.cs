using System;

class PriceChangeAlert
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        double significance = double.Parse(Console.ReadLine());
        double lastPrice = double.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            double currentPrice = double.Parse(Console.ReadLine());
            double percentDifference = GetPercent(lastPrice, currentPrice);
            bool isSignificantDifference = HasDifference(percentDifference, significance);

            string message = GetResult(currentPrice, lastPrice, percentDifference, isSignificantDifference);
            Console.WriteLine(message);

            lastPrice = currentPrice;
        }
    }

    static string GetResult(double currentPrice, double lastPrice, double percentDifference, bool isSignificantDifference)
    {
        string result = string.Empty;
        if (percentDifference == 0)
        {
            result = string.Format("NO CHANGE: {0}", lastPrice);
        }
        else if (!isSignificantDifference)
        {
            result = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, percentDifference);
        }
        else if (isSignificantDifference && (percentDifference > 0))
        {
            result = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, percentDifference);
        }
        else if (isSignificantDifference && (percentDifference < 0))
        {
            result = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", lastPrice, currentPrice, percentDifference);
        }

        return result;
    }
    static bool HasDifference(double percentDifference, double significance)
    {
        if (Math.Abs(percentDifference/100) >= significance)
        {
            return true;
        }
        return false;
    }

    static double GetPercent(double last, double current)
    {
        double percentage = ((current - last) / last) * 100;
        return percentage;
    }
}
