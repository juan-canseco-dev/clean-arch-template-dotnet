namespace CleanArchTemplate.Domain.UnitTests.Entities;

public class PurchaseTests
{

    private static int _supplierId = 1;
    private static List<PurchaseItem> _items = new()
        {
            new PurchaseItem(1, "Juice", "Galon", 0.99m, 10),
            new PurchaseItem(2, "Bread", "Each", 1.99m, 10)
        };

    [Test]
    public void CreatePurchaseWhenPropertiesAreValidShouldCreateSuccessfully()
    {
        decimal expectedTotal = 29.80m;
        var purchase = new Purchase(_supplierId, _items);
        purchase.SupplierId.Should().Be(_supplierId);
        purchase.Items.Should().BeEquivalentTo(_items);
        purchase.Total.Should().Be(expectedTotal);
        purchase.Arrived.Should().BeFalse();
    }

    [Test]
    public void CreatePurchaseWhenPropertiesAreInvalidShouldThrowException([ValueSource(nameof(PurchaseData))] object[] purchaseData)
    {
        Action createPurchase = () =>
        {
            var supplierId = (int)purchaseData[0];
            var items = (List<PurchaseItem>)purchaseData[1];
            new Purchase(supplierId, items);
        };
        createPurchase.Should().Throw<ArgumentException>();
    }

    [Test]
    public void ReceivePurchaseWhenPurchaseIsNotArrivedShouldReceive()
    {
        var purchase = new Purchase(_supplierId, _items);
        purchase.Receive();
        purchase.Arrived.Should().BeTrue();
    }

    [Test]
    public void ReceivePurchaseWhenPurchaseIsArrivedShouldThrowException()
    {
        Action receivePurchase = () =>
        {
            var purchase = new Purchase(_supplierId, _items);
            purchase.Receive();
            purchase.Receive();

        };
        receivePurchase.Should().Throw<PurchaseAlreadyReceivedException>();
    }


    [Test]
    public void UpdatePurchaseWhenPurchaseIsNotReceivedShouldUpdate()
    {
        var expectedTotal = 9.90m;
        var purchase = new Purchase(_supplierId, _items);
        var newItems = new List<PurchaseItem> ()
        {
            _items[0]
        };
        purchase.Update(newItems);
        purchase.Items.Should().BeEquivalentTo(newItems);
        purchase.Total.Should().Be(expectedTotal);
    }

    [Test]
    public void UpdatePurchaseWhenPurchaseIsReceivedShouldThrowException()
    {

        Action updatePurchase = () =>
        {
            var purchase = new Purchase(_supplierId, _items);
            purchase.Receive();
            var newItems = new List<PurchaseItem>()
            {
                _items[0]
            };
            purchase.Update(newItems);
        };
      
        updatePurchase.Should().Throw<PurchaseAlreadyReceivedException>();
    }

    [Test]
    public void UpdatePurchaseWhenItemsAreNullOrEmptyShouldThrowException()
    {
        Action updatePurchase = () =>
        {
            var purchase = new Purchase(_supplierId, _items);
            purchase.Update(new List<PurchaseItem>());
        };
        updatePurchase.Should().Throw<ArgumentException>();
    }

    public static readonly object[] PurchaseData =
    {
        new object[] {0, _items},
        new object[] {-1, _items},
        new object[] {_supplierId, null},
        new object[] {1, new List<PurchaseItem>()},
    };
}
