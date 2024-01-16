bool Symbol(char[,] a, int beg, int end, int row)
{
    for(int i = row - 1; i <= row + 1; i++)
    {
        for (int j = beg - 1; j <= end + 1; j++)
        {
            if ((i > -1 && j > -1) && (i < a.GetLength(0) && j < a.GetLength(1)))
            {
                if (!char.IsDigit(a[i, j]) && a[i, j] != '.') return true;
            }
        }
    }

    return false;
}

(int, int, bool) Symbol1 (char[,] a, int beg, int end, int row)
{
    for(int i = row - 1; i <= row + 1; i++)
    {
        for (int j = beg - 1; j <= end + 1; j++)
        {
            if ((i > -1 && j > -1) && (i < a.GetLength(0) && j < a.GetLength(1)))
            {
                if (!char.IsDigit(a[i, j]) && a[i, j] == '*' && a[i, j] != '.')
                {
                    return (i, j, true);
                }
            }
        }
    }

    return (0, 0, false);
}


List<KeyValuePair<int, int[]>> gears = new List<KeyValuePair<int, int[]>>();
char[,] a = new char[,] { };
int rows = 0;
bool firstRow = true;
int res = 0, res1 = 0;

while (true)
{
    string input = Console.ReadLine();
    if (input == "")
        break;
    char[,] b = new char[rows + 1, input.Length];
    if (!firstRow)
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < input.Length; j++)
            {
                b[i, j] = a[i, j];
            }
        }

        for (int i = 0; i < input.Length; i++)
        {
            b[rows, i] = input[i];
        }

        rows++;
    }
    else
    {
        for (int i = 0; i < input.Length; i++)
        {
            b[rows, i] = input[i];
        }

        rows++;
        firstRow = false;
    }
    a = b;
}

for (int i = 0; i < a.GetLength(0); i++)
{
    for (int j = 0; j < a.GetLength(1); j++)
    {
        if (char.IsDigit(a[i, j]))
        {
            int[] steps = new int[] { };
            string number = a[i, j].ToString();
            for (int z = j + 1; z <= a.GetLength(1); z++)
            {
                if (z >= a.GetLength(1))
                {
                    steps = new int[] { j, z - 1 };
                    break;
                }
                if (char.IsDigit(a[i, z])) number += a[i, z];
                else
                {
                    steps = new int[] { j, z - 1 };
                    j = z;
                    break;
                }
            }

            if (Symbol(a, steps[0], steps[1], i))
            {
                res += Convert.ToInt16(number);
            }

            var b = Symbol1(a, steps[0], steps[1], i);
            if (b.Item3)
            {
                gears.Add(new KeyValuePair<int, int[]>(Convert.ToInt16(number), new int[2]{b.Item1, b.Item2}));
            }
        }
    }
}

foreach (var lyze in gears)
{
    List<KeyValuePair<int, int[]>> gears1 = new List<KeyValuePair<int, int[]>>(gears);
    gears1.Remove(lyze);
    foreach (var husky in gears1)
    {
        var i = husky.Value;
        var b = lyze.Value;
        if (b[0] == i[0] && b[1] == i[1])
        {
            res1 += husky.Key * lyze.Key;
        }
    }
}

Console.WriteLine(res);
Console.WriteLine(res1 / 2);

/*for (int i = 0; i < a.GetLength(0); i++)
{
    for (int j = 0; j < a.GetLength(1); j++)
    {
        Console.Write(a[i, j]);
    }
    Console.Write("\n");
}*/