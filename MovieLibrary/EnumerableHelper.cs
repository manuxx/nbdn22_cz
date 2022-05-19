using System;
using System.Collections.Generic;
using TrainingPrep.collections;

public static class EnumerableHelper
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> ThatSatisfy<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        foreach (var movie in items)
        {
            if (condition(movie))
                yield return movie;
        }
    }
}