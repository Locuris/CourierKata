using System.Diagnostics;

namespace CourierKata;

public class Parcel
{
    private readonly float _length;
    private readonly float _width;
    private readonly float _breadth;
    private readonly float _weight;

    private int CostPerKiloOfWeightExcess => Size == Size.Heavy ? 1 : 2;

    public Size Size
    {
        get
        {
            if (_weight >= 50)
                return Size.Heavy;
            
            var totalDimensions = _length + _width + _breadth;
            return totalDimensions switch
            {
                < 10 => Size.Small,
                < 50 => Size.Medium,
                < 100 => Size.Large,
                _ => Size.XL
            };
        }
    }

    private int WeightLimit
    {
        get
        {
            return Size switch
            {
                Size.Small => 1,
                Size.Medium => 3,
                Size.Large => 6,
                Size.XL => 10,
                Size.Heavy => 50,
                _ => 0
            };
        }
    }

    private int SizeCost => (int) Size;

    private int WeightCost
    {
        get
        {
            var weightExcess = _weight - WeightLimit;
            if (weightExcess <= 0)
                return 0;
            return (int) Math.Ceiling(weightExcess) * CostPerKiloOfWeightExcess;
        }
    }
    
    public int Cost => SizeCost + WeightCost;
    
    public string CostLine => Size + " Parcel: $" + Cost + ".";

    public Parcel(float length, float width, float breadth, float weight)
    {
        _length = length;
        _width = width;
        _breadth = breadth;
        _weight = weight;
    }
    
}