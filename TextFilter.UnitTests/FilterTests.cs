using Shouldly;
using TextFilter.Services;

namespace TextFilter.UnitTests;

public class FilterTests
{
    [Fact]
    public void MiddleVowelFilter_Apply_HandlesSingleWord()
    {
        // Arrange
        var testword = "abominations";
        var filter = new MiddleVowelFilter();
        var words = new List<string> { testword };

        // Act
        var filteredWords = filter.Apply(words).ToList();

        // Assert
        filteredWords.ShouldNotContain(testword);
        filteredWords.Count.ShouldBe(0);
    }

    [Fact]
    public void MiddleVowelFilter_Apply_FiltersOutWordsWithMiddleVowel()
    {
        // Arrange
        var filter = new MiddleVowelFilter();
        var words = new List<string> { "clean", "what", "currently", "the", "rather", "apple" };

        // Act
        var filteredWords = filter.Apply(words).ToList();

        // Assert
        filteredWords.ShouldNotContain("clean");     // 'e' is a vowel
        filteredWords.ShouldNotContain("what");      // 'ha' is a vowel
        filteredWords.ShouldNotContain("currently"); // 'e' is a vowel
        filteredWords.ShouldContain("the");          // No middle vowel
        filteredWords.ShouldContain("rather");       // 'th' is not a vowel
        filteredWords.ShouldContain("apple");        // 'p' is not a vowel
        filteredWords.Count.ShouldBe(3);             // Only "the" and "rather" should remain
    }

    [Fact]
    public void MiddleVowelFilter_Apply_HandlesShortWords()
    {
        // Arrange
        var filter = new MiddleVowelFilter();
        var words = new List<string> { "a", "to", "in" };

        // Act
        var filteredWords = filter.Apply(words).ToList();

        // Assert
        filteredWords.ShouldBe(words);   // Short words should not be filtered
        filteredWords.Count.ShouldBe(3); // All words should remain
    }

    [Fact]
    public void MinimumLengthFilter_Apply_FiltersWordsShorterThanMinLength()
    {
        // Arrange
        var filter = new MinimumLengthFilter(4);
        var words = new List<string> { "one", "two", "three", "four" };

        // Act
        var filteredWords = filter.Apply(words).ToList();

        // Assert
        filteredWords.ShouldNotContain("one"); // Filtered out
        filteredWords.ShouldNotContain("two"); // Filtered out
        filteredWords.ShouldContain("three");  // Not filtered
        filteredWords.ShouldContain("four");   // Not filtered
        filteredWords.Count.ShouldBe(2);       // Only "three" and "four" should remain
    }

    [Fact]
    public void MinimumLengthFilter_Apply_HandlesEmptyList()
    {
        // Arrange
        var filter = new MinimumLengthFilter(3);
        var words = new List<string>();

        // Act
        var filteredWords = filter.Apply(words).ToList();

        // Assert
        filteredWords.Count.ShouldBe(0); // No words to filter
    }

    [Fact]
    public void ContainsCharacterFilter_Apply_FiltersWordsContainingCharacter()
    {
        // Arrange
        var filter = new ContainsCharacterFilter('a');
        var words = new List<string> { "apple", "banana", "orange", "kiwi" };

        // Act
        var filteredWords = filter.Apply(words).ToList();

        // Assert
        filteredWords.ShouldNotContain("apple");  // Filtered out
        filteredWords.ShouldNotContain("banana"); // Filtered out
        filteredWords.ShouldNotContain("orange"); // Filtered out
        filteredWords.ShouldContain("kiwi");      // Not filtered
        filteredWords.Count.ShouldBe(1);          // Only "kiwi" should remain
    }

    [Fact]
    public void ContainsCharacterFilter_Apply_CaseSensitive()
    {
        // Arrange
        var filter = new ContainsCharacterFilter('A');
        var words = new List<string> { "apple", "Apple" };

        // Act
        var filteredWords = filter.Apply(words).ToList();

        // Assert
        filteredWords.ShouldContain("apple");    // Filtered out
        filteredWords.ShouldNotContain("Apple"); // Not filtered
        filteredWords.Count.ShouldBe(1);         // Only "apple" should remain
    }
}
