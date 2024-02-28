namespace CleanArchTemplate.Domain.UnitTests.Entities;

public class PurchaseItemTests
{
    private static int _productId = 1;
    private static string _productName = "Milk";
    private static string _productUnit = "Box";
    private static decimal _productPrice = 10.99m;
    private static int _quantity = 10;


    [Test]
    public void CreatePurchaseItemWhenPropertiesAreValidShouldCreateSuccessfully()
    {
        decimal expectedTotal = 109.90m;
        var item = new PurchaseItem(_productId, _productName, _productUnit, _productPrice, _quantity);
        item.ProductId.Should().Be(_productId);
        item.ProductName.Should().Be(_productName);
        item.ProductUnit.Should().Be(_productUnit);
        item.ProductPrice.Should().Be(_productPrice);
        item.Quantity.Should().Be(_quantity);
        item.Total.Should().Be(expectedTotal);
    }

    [Test]
    public void CreatePurchaseWhenPropertiesAreInvalidShouldThrowException([ValueSource(nameof(PurchaseItemsData))] object[] purchaseItemData)
    {
        Action createPurchaseItem = () =>
        {
            var productId = (int)purchaseItemData[0];
            var productName = (string)purchaseItemData[1];
            var productUnit = (string)purchaseItemData[2];
            var productPrice = (decimal)purchaseItemData[3];
            var quantity = (int)purchaseItemData[4];
            new PurchaseItem(productId, productName, productUnit, productPrice, quantity);
        };
        createPurchaseItem.Should().Throw<ArgumentException>();
    }

    public static readonly object[] PurchaseItemsData =
    {
        // Invalid ProductId
        new object[] {0, _productName, _productUnit, _productPrice, _quantity},
        new object[] {-1, _productName, _productUnit, _productPrice, _quantity},
        // Invalid ProductName
        new object[] {_productId, "", _productUnit, _productPrice, _quantity},
        new object[] {_productId, null, _productUnit, _productPrice, _quantity},
        // Invalid ProductUnit
        new object[] {_productId, _productName, "", _productPrice, _quantity},
        new object[] {_productId, _productName, null, _productPrice, _quantity},
        // Invalid Purchase Price 
        new object[] {_productId, _productName, _productUnit, 0.00m, _quantity},
        new object[] {_productId, _productName, _productUnit, -1.00m, _quantity},
        // Invalid Quantity 
        new object[] {_productId, _productName, _productUnit, _productPrice, 0},
        new object[] {_productId, _productName, _productUnit, _productPrice, -1}
    };
}
