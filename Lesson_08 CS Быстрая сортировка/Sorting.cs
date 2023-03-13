public static class Sorting
{
    /// <summary>
    /// Быстрая сортировка
    /// </summary>
    /// <param name ="collection">Исходный массив</param>
    /// <param name ="left">Левый указатель</param>
    /// <param name ="right">Правый указатель</param>
    /// <returns>Отсортированный массив</returns>
    public static int[] QuickSort(this int[] collection, int left, int right)
    {
        int i = left;
        int j = right;

        int pivot = collection[Random.Shared.Next(left, right)];
        while (i <= j)
        {
            while (collection[i] < pivot) i++;
            while (collection[j] > pivot) j--;

            if (i <= j)
            {
                int t = collection[i];
                collection[i] = collection[j];
                collection[j] = t;
                i++;
                j--;
            }
        }
        if (i < right) QuickSort(collection, i, right);
        if (left < j) QuickSort(collection, left, j);
        return collection;
    }
}