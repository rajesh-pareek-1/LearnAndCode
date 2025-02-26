Assignment-2 Functions Clean Code

Issues in the Original Code:
Lack of Meaningful Function Names

The original code used unclear names like sumarr, making it hard to understand its purpose.
No clear distinction between reading input, processing data, and handling queries.
Lack of SRP (Single Responsibility Principle)

The Main method was doing too much:
Reading input
Computing prefix sum
Processing queries
It should be divided into smaller, focused functions.
Code Duplication & Readability Issues

The same logic of reading input (Array.ConvertAll(...)) was used in multiple places.
It makes debugging and modifications difficult and cause Ambiguous Logic

sumarr[0] = 0; was directly assigned without explaining why.
(long)((long)(sumarr[RL[1]] - sumarr[RL[0] - 1]) / (RL[1] - RL[0] + 1))
Nested casts (long) make it harder to read.
A dedicated function should handle calculations.

After Refactoring Code it aligns with Clean Code Principles:
Improved Readability & Function Naming

Introduced meaningful function names:
ReadArraySizeAndQueryCount()
ComputePrefixSum()
ProcessQueries()
This makes the code self-explaining.
Applied SRP (Single Responsibility Principle)

Each function has a single responsibility:
ReadArraySizeAndQueryCount() → Reads array size and query count.
ReadArray() → Reads the array.
ComputePrefixSum() → Computes prefix sum.
ProcessQueries() → Handles user queries.
Avoided Code Duplication (DRY Principle)

Extracted input parsing logic into reusable functions:
ReadArraySizeAndQueryCount()
ReadQuery()
This removes redundant Array.ConvertAll(Console.ReadLine().Split(), int.Parse) calls.
Encapsulation of Computation Logic

ComputePrefixSum() cleanly separates prefix sum logic.
ProcessQueries() ensures the main function remains clean.
Better Maintainability & Extensibility

If the input format changes, we only modify input-related functions, not the whole code.