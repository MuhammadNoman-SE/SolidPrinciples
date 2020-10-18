using System;

namespace ArdalisRating
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ardalis Insurance Rating System Starting...");
            ILogger logger = new Logger();
            var engine = new RatingEngine(new PolicyDeserializer (),
            new RaterFactory( logger),
            logger,
            new PolicyReader());
            engine.Rate();

            if (engine.Rating > 0)
            {
                Console.WriteLine($"Rating: {engine.Rating}");
            }
            else
            {
                Console.WriteLine("No rating produced.");
            }

        }
    }
}
