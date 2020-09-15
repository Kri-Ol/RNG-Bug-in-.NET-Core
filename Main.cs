// https://stackoverflow.com/questions/63276505/why-is-the-pseudo-random-number-generator-less-likely-to-generate-54-big-numbers
// https://github.com/dotnet/runtime/issues/40490
// https://github.com/dotnet/runtime/issues/23198

using System;

namespace Random54
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong C = 1024;

            var hist = new ulong [C]; // histogram

            ulong N = 200000000L;
            double p = 1.0 / 40.0; // 1/32 has problem as well

            Random rand = new Random(1); // or 11

            for (ulong k = 0; k != N; ++k)
            {
                ulong count = 0UL; // this is a bit naive way to sample geometric distribution,
                                   // https://en.wikipedia.org/wiki/Geometric_distribution
                while (!(rand.NextDouble() < p))
                    ++count;

                hist[Math.Clamp(count, 0UL, C - 1)] += 1; // collecting tallies
            }

            for (ulong i = 0; i != C; ++i)
            {
                Console.WriteLine($"{i} {hist[i]}");
            }
        }
    }
}
