using System.Collections.Generic;
using NUnit.Framework;

namespace CourierKata.Tests;

public class Order_Tests
{

    private static Order LargeOrder()
    {
        var order = new Order();
        order.AddParcel(new Parcel(2, 4, 5));
        order.AddParcel(new Parcel(1, 1, 1));
        order.AddParcel(new Parcel(20, 20 , 20));
        order.AddParcel(new Parcel(40, 40, 40));
        return order;
    }

    [Test]
    public void TestSingleParcelSmall()
    {
        var order = new Order();
        order.AddParcel(new Parcel(1f, 1f, 1f));
        Assert.That(order.CalculateCost(), Is.EqualTo("Small Parcel: $3. Total Cost: $3"));
    }

    [Test]
    public void TestMultipleParcelsAllSizes()
    {
        var order = LargeOrder();
        Assert.That(order.CalculateCost(), Is.EqualTo(
            "Medium Parcel: $8. Small Parcel: $3. Large Parcel: $15. XL Parcel: $25. Total Cost: $51"));
    }

    [Test]
    public void TestMultipleParcelsAllSizesWithSpeedyShipping()
    {
        var order = LargeOrder();
        order.SetSpeedyShipping(true);
        Assert.That(order.CalculateCost(), Is.EqualTo(
            "Medium Parcel: $8. Small Parcel: $3. Large Parcel: $15. XL Parcel: $25. Speedy Shipping: $51. Total Cost: $102"));
    }
}