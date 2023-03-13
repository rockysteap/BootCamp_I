using static Sorting;
using static Infrastructure;

// int[] array = CreateArray(10);
// Show(array);
// SortSelection(array);
// Show(array);

int size = 100;
var arr = size.CreateArray()
    .Show()
    .QuickSort(0, size - 1)
    .Show();