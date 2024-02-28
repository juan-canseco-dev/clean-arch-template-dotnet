
using CleanArchTemplate.Domain.Guards;

namespace CleanArchTemplate.Domain.Entities;

public class Order : BaseAuditableEntity<int>
{
    private readonly List<OrderItem> _items = new();
    public int CustomerId { get; private set; }
    public decimal Total { get; private set; }
    public bool Delivered { get; private set; }
    public IReadOnlyCollection<OrderItem> Items => _items.AsReadOnly();

    public void Update(List<OrderItem> items)
    {
        Guard.Against.NullOrEmpty(items, nameof(items));
        Guard.Against.DeliverTwice(this);
        _items.Clear();
        _items.AddRange(items);
        UpdateTotals();
    }

    public void Deliver()
    {
        Guard.Against.DeliverTwice(this);
        Delivered = true;
    }

    private void UpdateTotals()
    {
        Total = _items.Sum(m => m.Total);
    }

    private Order()
    {
        CustomerId = 0;
        Total = 0;
        _items = new List<OrderItem>();
        Delivered = false;
    }

    public Order(int customerId, List<OrderItem> items)
    {
        Guard.Against.NegativeOrZero(customerId);
        Guard.Against.NullOrEmpty(items, nameof(items));
        Delivered = false;
        CustomerId = customerId;
        _items = new List<OrderItem>();
        _items.AddRange(items);
        UpdateTotals();

    }
}
