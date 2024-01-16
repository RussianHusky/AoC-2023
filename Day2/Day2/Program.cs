using System.Text.RegularExpressions;

int res = 0;
int res1 = 0;

Dictionary<string, int> cubes = new Dictionary<string, int>
{
    {"red", 12},
    {"green", 13},
    {"blue", 14}
};

while (true)
{
    Dictionary<string, int> bag = new Dictionary<string, int>
    {
        {"red", 0},
        {"green", 0},
        {"blue", 0}
    };
    Dictionary<string, int> maxCubes = new Dictionary<string, int>
    {
        {"red", 0},
        {"green", 0},
        {"blue", 0}
    };
    bool possible = true;
    string input = Console.ReadLine();
    if (input == "")
    {
        break;
    }
    int game = Convert.ToInt16(input.Split(" ")[1].Remove(input.Split(" ")[1].Length - 1, 1));
    var cubesInBag = Regex.Matches(input, @"((\d) (green|blue|red),)*(\d+ (green|blue|red));*");
    foreach (Match i in cubesInBag)
    {
        var color = i.Value.Split(" ");
        if (i.Value[^1] == ';')
        {
            string c = color[1].Remove(color[1].Length - 1, 1);
            if (Convert.ToInt16(color[0]) > maxCubes[c])
                maxCubes[c] = Convert.ToInt16(color[0]);
            if (Convert.ToInt16(color[0]) + bag[c] > cubes[c])
            {
                possible = false;
            }
            else
            {
                foreach (var j in bag)
                {   
                    bag[j.Key] = 0;
                }

                continue;
            }
        }
        else
        {
            if (Convert.ToInt16(color[0]) > maxCubes[color[1]])
                maxCubes[color[1]] = Convert.ToInt16(color[0]);
            if (Convert.ToInt16(color[0]) + bag[color[1]] > cubes[color[1]])
            {
                possible = false;
            }
            else
            {
                bag[color[1]] += Convert.ToInt16(color[0]);
            }
        }

    }

    res1 += maxCubes["green"] * maxCubes["blue"] * maxCubes["red"];
    
    if (possible)
        res += game;
}

Console.WriteLine(res);
Console.WriteLine(res1);