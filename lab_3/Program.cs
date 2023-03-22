using lab_3;

var dictionary = new StringsDictionary();

// перевірити як працює хешування, потім видалемо 
dictionary.Add("Hello", "Hi");
dictionary.Add("Goodbye", "Bye");
Console.WriteLine(dictionary.Get("Hello"));
Console.WriteLine(dictionary.Get("Goodbye"));

var lines = File.ReadAllLines("dictionary.txt");
foreach (var line in lines)
{
    string[] elements = line.Split("; ");
    var key = elements[0];
    var value = String.Join("; ", elements[1..]);
}

while (true)
{
    Console.WriteLine("\nEnter a word:");
    var word = Console.ReadLine();
    string? explanation = default;

    // get explanation from the dictionary;
    
    Console.WriteLine($"Explanation: {explanation}");
}
