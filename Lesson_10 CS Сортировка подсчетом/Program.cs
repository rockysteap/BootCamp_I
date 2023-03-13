
using static Infrastructure;
using static Sorting;

// int[] array = { 0, 2, 3, 2, 1, 5, 9, 1, 1, 2, 1, 3, 4, 6, 3, 1, 4, 8, 5, 2 }; // для CountingSort();
// int[] array = {0, 2, 4, 10, 20, 5, 6, 1, 2};
// int[] array = {-10, -5, -9, 0, 2, 5, 1, 3, 1, 0, 1};
int[] array = {10020, 10030, 100};

Show(array);
CountingSortExtended(array);
Show(array);

// int[] sortedArray = CountingSortExtended(array);
// Console.WriteLine(string.Join(", ", sortedArray));

