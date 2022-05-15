namespace CourierKata;

public class Order
{
    private readonly List<Parcel> _parcels;

    private readonly List<Discount> _discounts;
    
    private bool _isSpeedyShipping;
    
    
    public Order()
    {
        _parcels = new List<Parcel>();
        _discounts = new List<Discount>();
    }

    public void SetSpeedyShipping(bool isSpeedyShipping)
    {
        _isSpeedyShipping = isSpeedyShipping;
    }

    public void AddParcel(Parcel parcel)
    {
        _parcels.Add(parcel);
    }

    public string CalculateCost()
    {
        var output = "";
        var totalCost = 0;
        
        CalculateDiscounts();
        
        foreach (var parcel in _parcels)
        {
            output += parcel.CostLine + " ";
            totalCost += parcel.Cost;
        }

        foreach (var discount in _discounts)
        {
            output += discount.DiscountType + " Parcel Mania! -" + discount.DiscountValue + "$. ";
            totalCost -= discount.DiscountValue;
        }

        if (_isSpeedyShipping)
        {
            output += "Speedy Shipping: $" + totalCost + ". ";
            totalCost += totalCost;
        }

        output += "Total Cost: $" + totalCost;
        
        return output;
    }

    private void CalculateDiscounts()
    {
        var totalSmall = 0;
        var smallDiscountValue = 0;
        var smallParcelsInDiscount = new List<Parcel>();
        var totalMedium = 0;
        var mediumDiscountValue = 0;
        var mediumParcelsInDiscount = new List<Parcel>();
        var totalMixed = 0;
        var mixedDiscountValue = 0;
        var mixedParcelsInDiscount = new List<Parcel>();

        var allDiscounts = new List<Discount>();
        
        foreach (var parcel in _parcels.OrderByDescending(p => p.Cost))
        {
            if (parcel.Size == Size.Small)
            {
                totalSmall++;
                smallParcelsInDiscount.Add(parcel);
                if (smallDiscountValue == 0 || parcel.Cost < smallDiscountValue)
                    smallDiscountValue = parcel.Cost;
            }

            if (parcel.Size == Size.Medium)
            {
                totalMedium++;
                mediumParcelsInDiscount.Add(parcel);
                if (mediumDiscountValue == 0 || parcel.Cost < mediumDiscountValue)
                    mediumDiscountValue = parcel.Cost;
            }

            totalMixed++;
            if (mixedDiscountValue == 0 || parcel.Cost < mixedDiscountValue)
                mixedDiscountValue = parcel.Cost;
            mixedParcelsInDiscount.Add(parcel);
            
            if (totalSmall == 4)
            {
                allDiscounts.Add(new Discount(DiscountType.Small, smallDiscountValue, smallParcelsInDiscount));
                totalSmall = 0;
                smallDiscountValue = 0;
                smallParcelsInDiscount = new List<Parcel>();
            }

            if (totalMedium == 3)
            {
                allDiscounts.Add(new Discount(DiscountType.Medium, mediumDiscountValue, mediumParcelsInDiscount));
                totalMedium = 0;
                mediumDiscountValue = 0;
                mediumParcelsInDiscount = new List<Parcel>();
            }

            if (totalMixed == 5)
            {
                allDiscounts.Add(new Discount(DiscountType.Mixed, mixedDiscountValue, mixedParcelsInDiscount));
                totalMixed = 0;
                mixedDiscountValue = 0;
                mixedParcelsInDiscount = new List<Parcel>();
            }
        }

        var discountedParcels = new List<Parcel>();

        foreach (var discount in allDiscounts)
        {
            
        }
    }

}