using TextFilter.Services;

namespace TextFilter.ConsoleApp;

public class TextFilterApp
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter the path of the text file, or [ENTER] to use default test file:");
        var filePath = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(filePath))
        {
            filePath = "TestFile.txt";
        }
        
        IEnumerable<string> words = TextFileReader.ReadWordsFromFile(filePath);
        
        if (words.Any())
        {
            WordProcessor processor = new WordProcessor();

            // Apply the filters  
            processor.AddFilter(new MiddleVowelFilter());
            processor.AddFilter(new MinimumLengthFilter(3));
            processor.AddFilter(new ContainsCharacterFilter('t'));

            // Execute the filters
            IEnumerable<string> filteredWords = processor.Process(words);

            Console.WriteLine("Filtered Text:");
            Console.WriteLine(string.Join(" ", filteredWords));
            Console.WriteLine();
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
