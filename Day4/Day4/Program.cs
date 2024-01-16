using System.Text.RegularExpressions;

int res = 0, res1 = 0;

Dictionary<int, int> cards = new Dictionary<int, int>();

while (true)
{
    int pass = 0, score = 0;
    string input = Console.ReadLine();
    if (input == "") break;
    var parseInput = input.Split('|');
    string[] firstSet = Regex.Match(parseInput[0], @":\s*(\d+(?:\s+\d+)*)").Groups[1].ToString().Split(' ');
    int card = Convert.ToInt16(Regex.Match(parseInput[0], @"(\d+):").Groups[1].Value);
    var secondSet = Regex.Matches(parseInput[1], @"\d+");
    if (cards.ContainsKey(card)) cards[card]++;
    else cards.Add(card, 1);
    foreach (Match bum in secondSet)
    {
        if (firstSet.Contains(bum.Value))
        {
            if (score == 0) score = 1;
            else score *= 2;
            pass++;
        }
    }

    for (int j = 0; j < cards[card]; j++)
    {
        for (int i = card + 1; i <= card + pass; i++)
        {
            if (cards.ContainsKey(i)) cards[i]++;
            else cards.Add(i, 1);
        }
    }

    res += score;
}

foreach (var VARIABLE in cards) res1 += VARIABLE.Value;

Console.WriteLine(res);
Console.WriteLine(res1);