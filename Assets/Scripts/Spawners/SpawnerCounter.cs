using System;

class BoxSpawnerTest
{
  static void Main(string[] args)
  {
    // Counters for each rarity
    int commonCount = 0;
    int uncommonCount = 0;
    int rareCount = 0;
    int epicCount = 0;
    int legendaryCount = 0;
    int mythicCount = 0;
    int transcendentCount = 0;

    // Number of test runs
    int totalRuns = 100000;
    Random random = new Random();

    for (int i = 0; i < totalRuns; i++)
    {
      // Generate a random number between 1 and 1000000
      int randomNumber = random.Next(1, 1000001);

      // Determine rarity based on the random number
      if (randomNumber <= 700000)  // 70% chance for Common
      {
        commonCount++;
      }
      else if (randomNumber <= 890000)  // 19% chance for Uncommon
      {
        uncommonCount++;
      }
      else if (randomNumber <= 960000)  // 7% chance for Rare
      {
        rareCount++;
      }
      else if (randomNumber <= 989890)  // 2.989% chance for Epic
      {
        epicCount++;
      }
      else if (randomNumber <= 999890)  // 1% chance for Legendary
      {
        legendaryCount++;
      }
      else if (randomNumber <= 999998)  // 0.2055% chance for Mythic
      {
        mythicCount++;
      }
      else  // 0.001% chance for Transcendent
      {
        transcendentCount++;
      }
    }

    // Output the results
    Console.WriteLine("Results after 100,000 runs:");
    Console.WriteLine($"Common: {commonCount}");
    Console.WriteLine($"Uncommon: {uncommonCount}");
    Console.WriteLine($"Rare: {rareCount}");
    Console.WriteLine($"Epic: {epicCount}");
    Console.WriteLine($"Legendary: {legendaryCount}");
    Console.WriteLine($"Mythic: {mythicCount}");
    Console.WriteLine($"Transcendent: {transcendentCount}");
  }
}
