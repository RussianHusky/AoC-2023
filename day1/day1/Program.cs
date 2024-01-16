using System.Text.RegularExpressions;

long res = 0;

Dictionary<string, int> numbers = new Dictionary<string, int>
{
    {"one", 1},
    {"two", 2},
    {"three", 3},
    {"four", 4},
    {"five", 5},
    {"six", 6},
    {"seven", 7},
    {"eight", 8},
    {"nine", 9}
};

while (true)
{
    string input = Console.ReadLine();
    if (input == "")
        break;

    var bbbbbbb = Regex.Match(input, @"\d|(one|two|three|four|five|six|seven|eight|nine)");
    var aaaaaaa = Regex.Matches(input, @"/*(?=(one|two|three|four|five|six|seven|eight|nine)|(\d))");

    string ccccc = "";
    foreach (Group jopa in aaaaaaa[^1].Groups)
    {
        if (jopa.Value.ToString() != "")
            ccccc = jopa.Value.ToString();
    }

    int a = (int.TryParse(bbbbbbb.ToString(), out _)
                ? Convert.ToInt16(bbbbbbb.Value) * 10
                : numbers[bbbbbbb.ToString()] * 10)
            + (int.TryParse(ccccc, out _)
                ? Convert.ToInt32(ccccc)
                : numbers[ccccc]);
    res += Convert.ToInt64(a);
    Console.WriteLine(a);
}

Console.WriteLine(res);
