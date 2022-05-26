using System;

namespace TrainingPrep.collections
{
    public class CriteriaBuilder<TItem, TProperty> 
    {
        protected Func<TItem, TProperty> _selector;

        public CriteriaBuilder(Func<TItem, TProperty> selector)
        {
            _selector = selector;
        }

        public Criteria<TItem> EqualTo(TProperty value)
        {
            return new AnonymousCriteria<TItem>(movie => _selector(movie).Equals(value));
        }
        public Criteria<TItem> GreaterThan<IComparableProperty>(IComparableProperty value) 
                                                where IComparableProperty :  IComparable<TProperty>
        {
            return new AnonymousCriteria<TItem>(movie => value.CompareTo(_selector(movie)) < 0);
        }
    }
}