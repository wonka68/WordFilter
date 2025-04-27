using System.IO.Abstractions;

namespace TextFilter.Services;

public class TextFileReader
{
    private readonly IFileSystem _fileSystem;

    public TextFileReader() : this(new FileSystem()) { }

    public TextFileReader(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public IEnumerable<string> ReadWordsFromFile(string filePath)
    {
        try
        {
            return _fileSystem.File.ReadAllText(filePath)
                                   .Split(new char[] { ' ', '.', ',', ';', ':', '!', '?', '(', ')', '\'', '\n', '\r', '\t' },
                                          StringSplitOptions.RemoveEmptyEntries)
                                   .Select(word => word.ToLower());
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"File Error: The file '{filePath}' was not found. {ex.Message}");
            return Array.Empty<string>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while reading file: {ex.Message}");
            return Array.Empty<string>();
        }
    }
}
