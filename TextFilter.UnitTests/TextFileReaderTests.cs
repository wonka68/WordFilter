using System.IO.Abstractions.TestingHelpers;
using Shouldly;
using TextFilter.Services;

namespace TextFilter.UnitTests;

public class TextFileReaderTests
{
    [Fact]
    public void TextFileReader_ReadWordsFromFile_ReadsAndSplitsFileCorrectly()
    {
        // Arrange
        var mockFileSystem = new MockFileSystem();
        var mockInputFile = new MockFileData("This is a test. Sentence with, punctuation!");
        var testFile = "testinput.txt";
        mockFileSystem.AddFile(testFile, mockInputFile);

        // Act
        var words = new TextFileReader(mockFileSystem).ReadWordsFromFile(testFile);

        // Assert
        words.Count().ShouldBe(7); // Check number of words
        words.ShouldBe(new string[] { "this", "is", "a", "test", "sentence", "with", "punctuation" });
    }

    [Fact]
    public void TextFileReader_ReadWordsFromFile_ReturnsEmptyArrayIfFileNotFound()
    {
        // Arrange
        var nonExistentFile = "nonexistent.txt";
        var mockFileSystem = new MockFileSystem();
        var mockInputFile = new MockFileData("test");
        var testFile = "testinput.txt";
        mockFileSystem.AddFile(testFile, mockInputFile);

        // Act
        var words = new TextFileReader(mockFileSystem).ReadWordsFromFile(nonExistentFile);

        // Assert
        words.Count().ShouldBe(0);
    }

    [Fact]
    public void TextFileReader_ReadWordsFromFile_HandlesEmptyFile()
    {
        // Arrange
        var emptyFile = "empty.txt";
        var mockFileSystem = new MockFileSystem();
        var mockInputFile = new MockFileData("");
        mockFileSystem.AddFile(emptyFile, mockInputFile);

        // Act
        var words = new TextFileReader(mockFileSystem).ReadWordsFromFile(emptyFile);

        // Assert
        words.Count().ShouldBe(0);
    }

    [Fact]
    public void TextFileReader_ReadWordsFromFile_HandlesWhitespace()
    {
        // Arrange
        var content = "   ";
        var whitespaceFile = "whitespace.txt";
        var mockFileSystem = new MockFileSystem();
        var mockInputFile = new MockFileData(content);
        mockFileSystem.AddFile(whitespaceFile, mockInputFile);

        // Act
        var words = new TextFileReader(mockFileSystem).ReadWordsFromFile(whitespaceFile);

        // Assert
        words.Any().ShouldBe(false);
    }
}
