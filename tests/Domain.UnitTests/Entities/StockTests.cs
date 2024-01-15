
using CleanArchTemplate.Domain.Exceptions;

namespace CleanArchTemplate.Domain.UnitTests.Entities;

public class StockTests
{
    [Test]
    public void AddStockWhenQuantityIsPositiveQuantityShouldBeUpdated()
    {
        var expectedQuantity = 9;
        var stock = new Stock(1, 5);
        stock.AddStock(4);
        stock.Quantity.Should().Be(expectedQuantity);
    }

    [Test]
    public void AddStockWhenQuantityIsNegaitiveShouldThrowException()
    {
        var addStock = () =>
        {
            var stock = new Stock(1, 5);
            stock.AddStock(-1);
        };
        addStock.Should().Throw<ArgumentException>();
    }

    [Test]
    public void RemoveStockWhenQuantityIsPositiveShouldBeUpdated()
    {
        var expectedQuantity = 1;
        var stock = new Stock(1, 5);
        stock.RemoveStock(4);
        stock.Quantity.Should().Be(expectedQuantity);
    }

    [Test]
    public void RemoveStockWhenQuantityIsNegativeShouldThrowException()
    {
        var removeStock = () =>
        {
            var stock = new Stock(1, 5);
            stock.RemoveStock(-1);
        };
        removeStock.Should().Throw<ArgumentException>();
    }

    [Test]
    public void RemoveStockWhenRemoveQuantityIsGreaterThanCurrentStockQuantityShouldThrowException()
    {
        var removeStock = () =>
        {
            var stock = new Stock(1, 5);
            stock.RemoveStock(6);
        };
        removeStock.Should().Throw<InvalidStockOperationException>();
    }
}
