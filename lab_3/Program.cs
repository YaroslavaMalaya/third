using lab_3;

var dictionary = new StringsDictionary();
dictionary.Add("Hello", "Hi");
dictionary.Add("Goodbye", "Bye");
Console.WriteLine(dictionary.Get("Hello"));
Console.WriteLine(dictionary.Get("Goodbye"));

// read all lines in the file and put all words and explanations in the dictionary;
// File.ReadAllLines(pathToFile);

while (true)
{
    Console.WriteLine("\nEnter a word:");
    var word = Console.ReadLine();
    string? explanation = default;

    // get explanation from the dictionary;
    
    Console.WriteLine($"Explanation: {explanation}");
}
