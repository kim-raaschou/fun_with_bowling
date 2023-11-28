namespace fun_with_bowling;

public static class ListExtensions
{
    public static List<T> AddOrUpdate<T>(this List<T> source, Func<T, bool> match, Func<T> add, Func<T, T> update)
    {
        var existingItem = source.FirstOrDefault(match);
        
        if (existingItem is null)
        {
            source.Add(add());
        }
        else
        {
            source.Remove(existingItem);
            source.Add(update(existingItem));
        }

        return source;
    }
}