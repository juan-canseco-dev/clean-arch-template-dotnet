
namespace CleanArchTemplate.Domain.UnitTests.Entities;

 public class OrderItemTests
{
    private static int _productId = 1;
    private static string _productName = "Milk";
    private static string _productUnit = "Box";
    private static decimal _productPrice = 10.99m;
    private static int _quantity = 10;


    [Test]
    public void CreateOrderItemWhenPropertiesAreValidShouldCreateSuccessfully()
    {
        decimal expectedTotal = 109.90m;
        var item = new OrderItem(_productId, _productName, _productUnit, _productPrice, _quantity);
        item.ProductId.Should().Be(_productId);
        item.ProductName.Should().Be(_productName);
        item.ProductUnit.Should().Be(_productUnit);
        item.ProductPrice.Should().Be(_productPrice);
        item.Quantity.Should().Be(_quantity);
        item.Total.Should().Be(expectedTotal);
    }

    [Test]
    public void CreateOrderWhenPropertiesAreInvalidShouldThrowException([ValueSource(nameof(OrderItemsData))] object[] orderItemData)
    {
        Action createOrderItem = () =>
        {
            var productId = (int)orderItemData[0];
            var productName = (string)orderItemData[1];
            var productUnit = (string)orderItemData[2];
            var productPrice = (decimal)orderItemData[3];
            var quantity = (int)orderItemData[4];
            new OrderItem(productId, productName, productUnit, productPrice, quantity);
        };
        createOrderItem.Should().Throw<ArgumentException>();
    }

    public static readonly object[] OrderItemsData =
    {
        new object[] {0, _productName, _productUnit, _productPrice, _quantity},
        new object[] {-1, _productName, _productUnit, _productPrice, _quantity},
        new object[] {_productId, "", _productUnit, _productPrice, _quantity},
        new object[] {_productId, null, _productUnit, _productPrice, _quantity},
        new object[] {_productId, _productName, "", _productPrice, _quantity},
        new object[] {_productId, _productName, null, _productPrice, _quantity},
        new object[] {_productId, _productName, _productUnit, 0.00m, _quantity},
        new object[] {_productId, _productName, _productUnit, -1.00m, _quantity},
        new object[] {_productId, _productName, _productUnit, _productPrice, 0},
        new object[] {_productId, _productName, _productUnit, _productPrice, -1}
    };
}
