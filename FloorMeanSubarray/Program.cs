using System;

class FloorMeanSubarray
{
    static void Main()
    {
        var (arraySize, queryCount) = ReadArraySizeAndQueryCount();
        var numbers = ReadArray();
        var prefixSum = ComputePrefixSum(numbers);

        ProcessQueries(queryCount, prefixSum);
    }

    static (int, int) ReadArraySizeAndQueryCount()
    {
        var input = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        return (input[0], input[1]);
    }

    static int[] ReadArray()
    {
        return Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    }

    static long[] ComputePrefixSum(int[] numbers)
    {
        int arraySize = numbers.Length;
        long[] prefixSum = new long[arraySize + 1];

        for (int i = 1; i <= arraySize; i++)
        {
            prefixSum[i] = prefixSum[i - 1] + numbers[i - 1];
        }

        return prefixSum;
    }

    static void ProcessQueries(int queryCount, long[] prefixSum)
    {
        for (int i = 0; i < queryCount; i++)
        {
            var (leftIndex, rightIndex) = ReadQuery();
            long subarraySum = prefixSum[rightIndex] - prefixSum[leftIndex - 1];
            Console.WriteLine(subarraySum / (rightIndex - leftIndex + 1));
        }
    }

    static (int, int) ReadQuery()
    {
        var range = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
        return (range[0], range[1]);
    }
}
