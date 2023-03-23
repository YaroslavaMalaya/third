using lab_3;

var dictionary = new StringsDictionary();

foreach (var line in File.ReadAllLines("dictionary.txt"))
{
    string[] elements = line.Split("; ");
    var key = elements[0];
    var value = String.Join("; ", elements[1..]);
    dictionary.Add(key, value);
}

while (true)
{
    Console.WriteLine("\nEnter a word:");
    var word = Console.ReadLine();
    string? explanation = default;
    
    explanation = dictionary.Get(word);
    Console.WriteLine($"\nExplanation:\n{explanation}");
}