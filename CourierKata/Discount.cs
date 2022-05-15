namespace CourierKata;

public class Discount
{
    private readonly List<Parcel> _includedParcels;
    
    public DiscountType DiscountType
    {
        get;
    }

    public int DiscountValue
    {
        get;
    }

    public List<Parcel> IncludedParcels => new (_includedParcels);

    public Discount(DiscountType discountType, int discountValue, List<Parcel> includedParcels)
    {
        DiscountType = discountType;
        DiscountValue = discountValue;
        _includedParcels = includedParcels;
    }
    
    
}