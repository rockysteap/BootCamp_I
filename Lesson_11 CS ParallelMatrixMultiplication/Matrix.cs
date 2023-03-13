class Matrix
{
    public static int[,] MatrixGenerator(int rows, int columns)
    {
        Random _rand = new Random();
        int[,] resultMatrix = new int[rows, columns];
        for (int i = 0; i < resultMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < resultMatrix.GetLength(1); j++)
            {
                resultMatrix[i, j] = _rand.Next(-100, 100);
            }
        }
        return resultMatrix;
    }

    public static bool MatrixEquality(int[,] fMatrix, int[,] sMatrix)
    {
        bool result = true;

        for (int i = 0; i < fMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < fMatrix.GetLength(1); j++)
            {
                result = result && (fMatrix[i, j] == sMatrix[i, j]);
            }
        }
        return result;
    }
}

