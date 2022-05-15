using System.Collections.Generic;
using NUnit.Framework;

namespace CourierKata.Tests;

public class Order_Tests
{

    private static Order LargeOrder()
    {
        var order = new Order();
        order.AddParcel(new Parcel(2, 4, 5, 1));
        order.AddParcel(new Parcel(1, 1, 1, 1));
        order.AddParcel(new Parcel(20, 20 , 20, 1));
        order.AddParcel(new Parcel(40, 40, 40, 1));
        return order;
    }

    [Test]
    public void TestSingleParcelSmall()
    {
        var order = new Order();
        order.AddParcel(new Parcel(1, 1, 1, 1));
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

    [Test]
    public void TestSingleParcelMediumHeavy()
    {
        var order = new Order();
        order.AddParcel(new Parcel(2, 4, 5, 5));
        Assert.That(order.CalculateCost(), Is.EqualTo(
            "Medium Parcel: $12. Total Cost: $12"));
    }

    [Test]
    public void TestMultipleParcelsAllSizesHeavy()
    {
        var order = new Order();
        order.AddParcel(new Parcel(2, 4, 5, 5));
        order.AddParcel(new Parcel(1, 1, 1, 2));
        order.AddParcel(new Parcel(20, 20 , 20, 10));
        order.AddParcel(new Parcel(40, 40, 40, 15));
        Assert.That(order.CalculateCost(), Is.EqualTo(
            "Medium Parcel: $12. Small Parcel: $5. Large Parcel: $23. XL Parcel: $35. Total Cost: $75"));
        
    }
}