using Shouldly;
using TextFilter.Services;

namespace TextFilter.UnitTests;

public class WordProcessorTests
{
    [Fact]
    public void WordProcessor_Process_AppliesMultipleFiltersInOrder()
    {
        // Arrange
        var processor = new WordProcessor();
        processor.AddFilter(new MinimumLengthFilter(3));
        processor.AddFilter(new ContainsCharacterFilter('a'));
        var words = new List<string> { "at", "bat", "car", "dog" };

        // Act
        var filteredWords = processor.Process(words);

        // Assert
        filteredWords.ShouldNotContain("at");  // Filtered by length
        filteredWords.ShouldNotContain("bat"); // Filtered by containing 'a'
        filteredWords.ShouldNotContain("car"); // Filtered by containing 'a'
        filteredWords.ShouldContain("dog");
        filteredWords.Count().ShouldBe(1);
    }

    [Fact]
    public void WordProcessor_Process_HandlesNoFilters()
    {
        // Arrange
        var processor = new WordProcessor();
        var words = new List<string> { "test", "words" };

        // Act
        var filteredWords = processor.Process(words);

        // Assert
        filteredWords.ShouldBe(words); // No filters applied
        filteredWords.Count().ShouldBe(2);
    }
}
