namespace CleanArchTemplate.Domain.UnitTests.Entities;

public class OrderTests
{
    private static int _customerId = 1;
    private static List<OrderItem> _items = new()
        {
            new OrderItem(1, "Juice", "Galon", 0.99m, 10),
            new OrderItem(2, "Bread", "Each", 1.99m, 10)
        };

    [Test]
    public void CreateOrderWhenPropertiesAreValidShouldCreateSuccessfully()
    {
        decimal expectedTotal = 29.80m;
        var order = new Order(_customerId, _items);
        order.CustomerId.Should().Be(_customerId);
        order.Items.Should().BeEquivalentTo(_items);
        order.Total.Should().Be(expectedTotal);
        order.Delivered.Should().BeFalse();
    }

    [Test]
    public void CreateOrderWhenPropertiesAreInvalidShouldThrowException([ValueSource(nameof(OrdersData))] object[] orderData)
    {
        Action createOrder = () =>
        {
            var customerId = (int)orderData[0];
            var items = (List<OrderItem>)orderData[1];
            new Order(customerId, items);
        };
        createOrder.Should().Throw<ArgumentException>();
    }

    [Test]
    public void DeliverOrderWhenOrderIsNotDeliveredShouldDeliveer()
    {
        var order = new Order(_customerId, _items);
        order.Deliver();
        order.Delivered.Should().BeTrue();
    }

    [Test]
    public void DeliverOrderWhenOrderIsDeliveredShouldThrowException()
    {
        Action deliverOrder = () =>
        {
            var order = new Order(_customerId, _items);
            order.Deliver();
            order.Deliver();

        };
        deliverOrder.Should().Throw<OrderAlreadyDeliveredException>();
    }


    [Test]
    public void UpdateOrderWhenOrderIsNotDeliveredShouldUpdate()
    {
        var expectedTotal = 9.90m;
        var order = new Order(_customerId, _items);
        var newItems = new List<OrderItem>()
        {
            _items[0]
        };
        order.Update(newItems);
        order.Items.Should().BeEquivalentTo(newItems);
        order.Total.Should().Be(expectedTotal);
    }

    [Test]
    public void UpdateOrderWhenOrderIsDeliveredShouldThrowException()
    {

        Action updateOrder = () =>
        {
            var order = new Order(_customerId, _items);
            order.Deliver();
            var newItems = new List<OrderItem>()
            {
                _items[0]
            };
            order.Update(newItems);
        };

        updateOrder.Should().Throw<OrderAlreadyDeliveredException>();
    }

    [Test]
    public void UpdateOrderWhenItemsAreNullOrEmptyShouldThrowException()
    {
        Action updateOrder = () =>
        {
            var order = new Order(_customerId, _items);
            order.Update(new List<OrderItem>());
        };
        updateOrder.Should().Throw<ArgumentException>();
    }

    public static readonly object[] OrdersData =
    {
        new object[] {0, _items},
        new object[] {-1, _items},
        new object[] {_customerId, null},
        new object[] {1, new List<OrderItem>()},
    };
}

