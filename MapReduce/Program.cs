
// Paths to map files
var mapPath1 = @"map1.txt";
var mapPath2 = @"map2.txt";

var combinedOutput = File.ReadAllLines(mapPath1).ToList();
combinedOutput.AddRange(File.ReadAllLines(mapPath2));

// Grouping data by keys
var grouped = combinedOutput
    .Select(line => line.Split(','))
    .GroupBy(parts => parts[0], parts => parts[1])
    .ToDictionary(group => group.Key, group => group.ToList());

// Print grouped data
foreach (var key in grouped.Keys)
{
    Console.WriteLine($"Key: {key}");
    foreach (var value in grouped[key])
    {
        Console.WriteLine($"  Value: {value}");
    }
}

// Save grouped data to file
using var file = new StreamWriter(@"output.txt");

foreach (var key in grouped.Keys)
{
    file.Write($"{key}:");
    foreach (var value in grouped[key])
    {
        file.Write($" {value}");
    }

    file.WriteLine();
}
