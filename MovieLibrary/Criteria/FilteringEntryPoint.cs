using System;

namespace TrainingPrep.collections
{
    public class FilteringEntryPoint<TItem, TProperty> 
    {
        public readonly Func<TItem, TProperty> _selector;
        public bool _negation;

        public FilteringEntryPoint(Func<TItem, TProperty> selector)
        {
            _selector = selector;
            _negation = false;
        }

        public FilteringEntryPoint<TItem,TProperty> Not()
        {
            _negation = true;
            return this;
        }
    }
}