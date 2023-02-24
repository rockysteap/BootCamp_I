// Эффективность алгоритмов

// Подсчитать сумму чисел, попавших в выборку
// Всего -> 500 000 элементов - размерность массива
// Подмассив -> 10 000 элементов - необходимая выборка

// На примере:
// array = 50 - размерность массива
// m = 3 - размер выборки

// Посчитаем количество групп на примере выборки 3 из 10
//               _____
// 0 1 2 3 4 5 6 7 8 9  <- 8 групп по 3 или по формуле n - m + 1, где n- размерность, m- длина выборки

int[] GetRangeSum(int[] array, int m)
{
    int n = array.Length;
    int[] t = new int[n - m + 1];

    int index = 0;
    //           0 -> ((15-5)+1)=11
    for (int i = 0; i < n - m + 1; i++)
    {
        //           0 -> (< (0+)+5)
        for (int j = i; j < i + m; j++)
        {
            t[index] += array[j];
        }
        index++;
    }
    return t;
}

int[] GetRangeSum2(int[] array, int m)
{
    int n = array.Length;
    int[] t = new int[n - m + 1];
    int sum = 0;
    int index = 0;
    //           0 < 2          
    for (int i = 0; i < m; i++) t[index] += array[i];

    // 1 2 3 4 5
    // ___ всего 4 пары
    //
    //           1 ->   (5-2)=3
    for (int i = 1; i <= n - m; i++)
    {
        index++;
    //  при n=5 m=2
    //  i=1: t[1] - array[0]     + array[3]
    //  i=3: t[3] - array[2]     + array[4]
        t[index] = t[index - 1] - array[i - 1] + array[i + m - 1];
    }
    return t;
}

int[] CreateArray(int size) => new int[size];

string Print(int[] array) => $"[{String.Join(", ", array)}]";

void Fill(ref int[] array) => array = array.Select(e => Random.Shared.Next(10)).ToArray();

int[] numbers = CreateArray(5_0);
Fill(ref numbers);
Console.WriteLine(Print(numbers));

int count = 1_0;
int[] sumGroupNumbers = GetRangeSum2(numbers, count);
Console.WriteLine(Print(sumGroupNumbers));

Console.WriteLine("------------");
Console.WriteLine(">>> DONE <<<");
Console.WriteLine("------------");