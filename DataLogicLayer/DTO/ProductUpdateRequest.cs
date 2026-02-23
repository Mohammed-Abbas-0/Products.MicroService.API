namespace DataLogicLayer.DTO;
public record ProductUpdateRequest(Guid ProductId, string ProductName, CategoryOptions CategoryOptions, double? UnitPrice, int? Quantity)
{
    public ProductUpdateRequest() : this(default, default!, default, default, default)
    {

    }
}
