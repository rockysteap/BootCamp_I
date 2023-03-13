using static Matrix;

const int N = 1000; // размер матрицы
const int THREADS_NUMBER = 8; // количество потоков

int[,] serialMultiplyResult = new int[N, N]; // результат умножения матриц в однопотоке

int[,] threadMultiplyResult = new int[N, N]; // результат параллельного умножения матриц (в мультипотоке)

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);

SerialMatrixMultiply(firstMatrix, secondMatrix);
PrepareParallelMatrixMultiply(firstMatrix, secondMatrix);
Console.WriteLine(MatrixEquality(serialMultiplyResult, threadMultiplyResult));
{

}

void SerialMatrixMultiply(int[,] a, int[,] b)
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножить такие матрицы");
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                threadMultiplyResult[i, j] += a[i, k] * b[j, k];
            }
        }
    }
}

void PrepareParallelMatrixMultiply(int[,] a, int[,] b)
{
    if (a.GetLength(1) != b.GetLength(0)) throw new System.Exception("Нельзя умножить такие матрицы");
    int eachThreadCount = N / THREADS_NUMBER;
    var threadsList = new List<Thread>();
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCount;
        int endPos = (i + 1) * eachThreadCount;
        // если последний поток
        if (i == THREADS_NUMBER - 1) endPos = N;
        threadsList.Add(new Thread(() => ParallelMatrixMultiply(a, b, startPos, endPos)));
        threadsList[i].Start();

    }
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        threadsList[i].Join();
    }

}

void ParallelMatrixMultiply(int[,] a, int[,] b, int startPos, int endPos)
{

    for (int i = startPos; i < endPos; i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMultiplyResult[i, j] += a[i, k] * b[j, k];
            }
        }
    }
}