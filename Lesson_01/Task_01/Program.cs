// Эффективность алгоритмов

// Дано число N. Нужно показать числа от -N до N

int GetValueByUser(string text)
{
    int value = 0;
    bool flag = false;
    do
    {
        Console.Write(text);
        string s = Console.ReadLine()!;
        flag = int.TryParse(s, out value) && value > 0;
    } while (!flag);
    return value;
}

void PrintNumbers1(int n)
{
    for (int i = -n; i <= n; i++)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine();
}

string PrintNumbers2(int n)
{
    string output = string.Empty;

    for (int i = -n; i <= n; i++)
    {
        output += $"{i} ";
    }
    return output;
}

string PrintNumbers3(int n)
{
    string output = "0";

    for (int i = 1; i <= n; i++)
    {
        output = $"{-i} " + output + $" {i}";
    }
    return output;
}

int n = GetValueByUser("Введите N: ");

PrintNumbers1(n);

Console.WriteLine(PrintNumbers2(n));
// File.WriteAllText("data.txt", PrintNumbers2(n));

Console.WriteLine(PrintNumbers3(n));
