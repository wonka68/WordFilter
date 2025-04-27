using TextFilter.Services.Interfaces;

namespace TextFilter.Services;

public class MiddleVowelFilter : IWordFilter
{
    private readonly string _vowels = "aeiou";
    
    private bool HasMiddleVowel(string word)
    {
        if (word.Length < 3)
        {
            return false;
        }
        
        int middleIndex1 = (word.Length - 1) / 2;
        int middleIndex2 = word.Length / 2;
        
        char middleChar1 = word[middleIndex1];
        char middleChar2 = word[middleIndex2];
        
        return _vowels.Contains(middleChar1) || (word.Length % 2 == 0 && _vowels.Contains(middleChar2));
    }
    
    public IEnumerable<string> Apply(IEnumerable<string> words)
    {
        return words.Where(word => !HasMiddleVowel(word));
    }
}
