using System.Collections.Generic;
using NUnit.Framework;

namespace CourierKata.Tests;

public class CostCalculator_Tests
{
    private Order _order;
    
    [SetUp]
    public void Setup()
    {
        _order = new Order();
    }

    [Test]
    public void Test1()
    {
        _order.AddParcel(new Parcel(1f, 1f, 1f));
        Assert.That(_order.CalculateCost(), Is.EqualTo("Small Parcel: $3. Total Cost: $3"));
    }
}