using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Generowanie wektora z milionem losowych liczb całkowitych
        Random rand = new Random();
        int[] array = new int[10_000_000];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next();
        }

        // Mierzenie czasu sortowania
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        Array.Sort(array);

        stopwatch.Stop();
        Console.WriteLine($"Czas sortowania: {stopwatch.ElapsedMilliseconds} ms");
    }
}
