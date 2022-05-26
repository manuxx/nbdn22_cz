using System;
using TrainingPrep.collections;

public static class CriteriaBuilderExtensions
{
    public static Criteria<TItem> EqualTo<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty value)
    {
        return new AnonymousCriteria<TItem>(movie => criteriaBuilder._selector(movie).Equals(value));
    }

    public static Criteria<TItem> GreaterThan<TItem, TProperty>(this CriteriaBuilder<TItem, TProperty> criteriaBuilder, TProperty value) 
        where TProperty :  IComparable<TProperty>
    {
        return new AnonymousCriteria<TItem>(movie => criteriaBuilder._selector(movie).CompareTo(value) > 0);
    }
}