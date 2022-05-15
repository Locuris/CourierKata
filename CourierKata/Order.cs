namespace CourierKata;

public class Order
{
    private readonly List<Parcel> _parcels;

    public Order()
    {
        _parcels = new List<Parcel>();
    }

    public Order(List<Parcel> parcels)
    {
        _parcels = parcels;
    }

    public void AddParcel(Parcel parcel)
    {
        _parcels.Add(parcel);
    }

    public string CalculateCost()
    {
        var output = "";
        var totalCost = 0;
        foreach (var parcel in _parcels)
        {
            output += parcel.CostLine + " ";
            totalCost += parcel.Cost;
        }

        output += "Total Cost: $" + totalCost;
        return output;
    }

}