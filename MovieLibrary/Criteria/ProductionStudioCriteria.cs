using System.Collections.Generic;

namespace TrainingPrep.collections
{
    public class ProductionStudioCriteria : ICriteria<Movie>
    {
        private readonly ProductionStudio[] _studios;

        public ProductionStudioCriteria(ProductionStudio[] studios)
        {
            _studios = studios;
        }

        public bool IsSatisfiedBy(Movie movie)
        {
            return ((IList<ProductionStudio>)_studios).Contains(movie.production_studio);
        }
    }
}