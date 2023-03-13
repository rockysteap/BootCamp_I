public static class Sorting
{
    /// <summary>
    /// Сортировка подсчетом
    /// </summary>
    /// <param name ="collection">Исходный массив</param>
    /// <returns>Отсортированный массив</returns>
    public static void CountingSort(int[] collection)
    {
        int[] counters = new int[10]; // массив повторений (весь диапазон значений)

        for (int i = 0; i < collection.Length; i++)
        {
            // проходим по исходному массиву и считаем сколько цифр повторяется, количество повторений записываем в результирующий массив повторений
            counters[collection[i]]++;
            // или
            // int ourNumber = collection[i];
            // counters[ourNumber]++;
        }

        // обходим все цифры в массиве повторений и вставляем повторяющиеся цифры по порядку в результирующий массив
        int index = 0; // 
        for (int i = 0; i < counters.Length; i++)
        {
            // counters[i] - записанное в массив повторений кол-во повторений какой-то конкретной цифры
            for (int j = 0; j < counters[i]; j++)
            {
                collection[index] = i;
                index++;
            }
        }
    }

    /// <summary>
    /// Сортировка подсчетом расширенная
    /// </summary>
    /// <param name ="collection">Исходный массив</param>
    /// <returns>Отсортированный массив</returns>
    public static void CountingSortExtended(int[] collection)
    {
        // размерность массива повторений будет зависеть от разницы между максимальным и минимальным значениями в исходном массиве + 1 
        int max = collection.Max();
        int min = collection.Min();
      
        int offset = -min; // определяем сдвиг
        int[] counters = new int[max + offset + 1]; // массив повторений (весь диапазон значений)
      
        for (int i = 0; i < collection.Length; i++)
        {
            counters[collection[i] + offset]++;
        }

        int index = 0;
        for (int i = 0; i < counters.Length; i++)
        {
            for (int j = 0; j < counters[i]; j++)
            {
                collection[index] = i - offset;
                index++;
            }
        }
    }
}