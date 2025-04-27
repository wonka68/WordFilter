using TextFilter.Services.Interfaces;

namespace TextFilter.Services;

public class WordProcessor
{
    private readonly List<IWordFilter> _filters = new List<IWordFilter>();

    public void AddFilter(IWordFilter filter)
    {
        _filters.Add(filter);
    }

    public IEnumerable<string> Process(IEnumerable<string> words)
    {
        IEnumerable<string> filteredWords = words;
        foreach (var filter in _filters)
        {
            filteredWords = filter.Apply(filteredWords);
        }
        return filteredWords;
    }
}