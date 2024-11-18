using DAL.Model;

namespace SaftOgKraft.WebApi.Controllers.DTOs.Converters;

public static class DTOConverter
{
    public static productDTO ToDto(this Product productToConvert)
    {
        var productDto = new productDTO();
        productToConvert.CopyPropertiesTo(productDto);
        return productDto;
    }

    public static Product FromDto(this productDTO productDtoToConvert)
    {
        var product = new Product();
        productDtoToConvert.CopyPropertiesTo(product);
        return product;
    }

    public static IEnumerable<productDTO> ToDtos(this IEnumerable<Product> productsToConvert)
    {
        foreach (var product in productsToConvert)
        {
            yield return product.ToDto();
        }
    }

    public static IEnumerable<Product> FromDtos(this IEnumerable<productDTO> productDtosToConvert)
    {
        foreach (var productDto in productDtosToConvert)
        {
            yield return productDto.FromDto();
        }
    }
}
