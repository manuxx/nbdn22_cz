using System;

namespace TrainingPrep.collections
{
    public class CriteriaBuilder<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _selector;

        public CriteriaBuilder(Func<TItem, TProperty> selector)
        {
            _selector = selector;
        }
    }
}