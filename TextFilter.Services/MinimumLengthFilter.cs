using TextFilter.Services.Interfaces;

namespace TextFilter.Services;

public class MinimumLengthFilter : IWordFilter
{
    private readonly int _minLength;

    public MinimumLengthFilter(int minLength)
    {
        _minLength = minLength;
    }

    public IEnumerable<string> Apply(IEnumerable<string> words)
    {
        return words.Where(word => word.Length >= _minLength);
    }
}
