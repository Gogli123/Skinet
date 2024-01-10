using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersForCountSpec : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpec(ProductSpecParams productParams) : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) && // If search is null or empty, return all products, otherwise return products that contain the search string in their name
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId)
            )
        {

        }
    }
}