using DAL.Model;

namespace SaftOgKraft.WebApi.Controllers.DTOs.Converters;

public static class DTOConverter
{
    #region Product conversion
    public static ProductDTO ToDto(this Product productToConvert)
    {
        var productDto = new ProductDTO();
        productToConvert.CopyPropertiesTo(productDto);
        return productDto;
    }

    public static Product FromDto(this ProductDTO productDtoToConvert)
    {
        Product product = new Product();
        productDtoToConvert.CopyPropertiesTo(product);
        return product;
    }

    public static IEnumerable<ProductDTO> ToDtos(this IEnumerable<Product> productsToConvert)
    {
        foreach (var product in productsToConvert)
        {
            yield return product.ToDto();
        }
    }

    public static IEnumerable<Product> FromDtos(this IEnumerable<ProductDTO> productDtosToConvert)
    {
        foreach (var productDto in productDtosToConvert)
        {
            yield return productDto.FromDto();
        }
    }
    #endregion

    #region Order Conversion
    public static OrderDTO ToDto(this Order orderToConvert)
    {
        OrderDTO orderDto = new OrderDTO();
        orderToConvert.CopyPropertiesTo(orderDto);

        // Explicitly map OrderLines
        orderDto.OrderLines = orderToConvert.OrderLines?.Select(ol => ol.ToDto()).ToList();

        return orderDto;
    }


    public static Order FromDto(this OrderDTO orderDtoToConvert)
    {
        Order order = new Order();
        orderDtoToConvert.CopyPropertiesTo(order);

        // Explicitly map OrderLines
        order.OrderLines = orderDtoToConvert.OrderLines?.Select(olDto => olDto.FromDto()).ToList();

        return order;
    }

    public static IEnumerable<OrderDTO> ToDtos(this IEnumerable<Order> ordersToConvert)
    {
        foreach (var order in ordersToConvert)
        {
            yield return order.ToDto();
        }
    }

    public static IEnumerable<Order> FromDtos(this IEnumerable<OrderDTO> orderDtosToConvert)
    {
        foreach (var orderDto in orderDtosToConvert)
        {
            yield return orderDto.FromDto();
        }
    }




    #endregion

    #region OrderLine Conversion
    public static OrderLineDTO ToDto(this OrderLine orderLineToConvert)
    {
        var orderLineDto = new OrderLineDTO();
        orderLineToConvert.CopyPropertiesTo(orderLineDto);
        return orderLineDto;
    }

    public static OrderLine FromDto(this OrderLineDTO dto)
    {
        return new OrderLine
        {
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            UnitPrice = dto.UnitPrice
        };
    }

    public static IEnumerable<OrderLineDTO> ToDtos(this IEnumerable<OrderLine> orderLinesToConvert)
    {
        foreach (var orderLine in orderLinesToConvert)
        {
            yield return orderLine.ToDto();
        }
    }

    public static IEnumerable<OrderLine> FromDtos(this IEnumerable<OrderLineDTO> orderLineDtosToConvert)
    {
        foreach (var orderLineDto in orderLineDtosToConvert)
        {
            yield return orderLineDto.FromDto();
        }
    }
    #endregion
}


#region Generics attempt graveyard
//public static TTarget ConvertTo<TSource, TTarget>(this TSource dtoToConvert) where TTarget : new()
//{
//    if (dtoToConvert ==  null)
//    {
//        throw new ArgumentNullException(nameof(dtoToConvert));
//    }

//    TTarget target = new TTarget();
//    dtoToConvert.CopyPropertiesTo(target);
//    return target;
//}

#endregion
