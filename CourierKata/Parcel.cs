using System.Diagnostics;

namespace CourierKata;

public struct Parcel
{
    private readonly float _length;
    private readonly float _width;
    private readonly float _breadth;

    private Size Size
    {
        get
        {
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

    public int Cost => (int) Size;

    public string CostLine => Size + " Parcel: $" + Cost + ".";
    
    public Parcel(float length, float width, float breadth)
    {
        _length = length;
        _width = width;
        _breadth = breadth;
    }
    
}