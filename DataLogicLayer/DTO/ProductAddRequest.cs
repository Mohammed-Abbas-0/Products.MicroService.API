namespace DataLogicLayer.DTO;
public record ProductAddRequest(string ProductName,CategoryOptions CategoryOptions,double? UnitPrice,int? Quantity)
{
    public ProductAddRequest():this(default!,default,default,default)
    {
        
    }
}
