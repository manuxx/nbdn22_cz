using System;
using TrainingPrep.collections;

public static class FilteringEntryPointExtensions
{
    public static Criteria<TItem> EqualTo<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty value)
    {
        return new AnonymousCriteria<TItem>(movie =>
        {
            if (filteringEntryPoint._negation)
                return ! filteringEntryPoint._selector(movie).Equals(value);
            else
                return filteringEntryPoint._selector(movie).Equals(value);
        });
    }

    public static Criteria<TItem> GreaterThan<TItem, TProperty>(this FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty value) 
        where TProperty :  IComparable<TProperty>
    {
        return new AnonymousCriteria<TItem>(movie => filteringEntryPoint._selector(movie).CompareTo(value) > 0);
    }

    public static Criteria<TItem> IsBetween<TItem, TProperty>(FilteringEntryPoint<TItem, TProperty> filteringEntryPoint, TProperty vFrom, TProperty vTo)
        where TProperty : IComparable<TProperty>
    {
        return new AnonymousCriteria<TItem>(movie => (filteringEntryPoint._selector(movie).CompareTo(vFrom) >= 0) &&
                                                     (filteringEntryPoint._selector(movie).CompareTo(vTo) <= 0));
    }
}