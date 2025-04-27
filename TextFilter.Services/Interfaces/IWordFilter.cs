namespace TextFilter.Services.Interfaces;

public interface IWordFilter
{
    IEnumerable<string> Apply(IEnumerable<string> words);
}
