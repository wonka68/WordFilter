using TextFilter.Services.Interfaces;

namespace TextFilter.Services;

public class ContainsCharacterFilter : IWordFilter
{
    private readonly char _character;

    public ContainsCharacterFilter(char character)
    {
        _character = character;
    }

    public IEnumerable<string> Apply(IEnumerable<string> words)
    {
        return words.Where(word => !word.Contains(_character));
    }
}
