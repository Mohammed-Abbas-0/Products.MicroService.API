namespace DataLogicLayer.DTO;
public record ProductResponse(Guid ProductId, string ProductName,CategoryOptions Category,double UnitPrice,int Quantity)
{
    public ProductResponse() : this(default, default!, default, default, default)
    {
    }
}
