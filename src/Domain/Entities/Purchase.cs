using CleanArchTemplate.Domain.Guards;

namespace CleanArchTemplate.Domain.Entities;

public class Purchase : BaseAuditableEntity<int>
{
    private readonly List<PurchaseItem> _items = new();

    public int SupplierId { get; private set; }
    public decimal Total { get; private set; }
    public virtual Supplier Supplier { get; private init; }
    public virtual IReadOnlyCollection<PurchaseItem> Items => _items.AsReadOnly();
    public bool Arrived { get; private set; }

    public void Update(List<PurchaseItem> items)
    {
        Guard.Against.NullOrEmpty(items, nameof(items));
        Guard.Against.ReceiveTwice(this);

        _items.Clear();
        _items.AddRange(items);
        UpdateTotal();
    }

    public void Receive()
    {
        Guard.Against.ReceiveTwice(this);
        Arrived = true;
    }

    private void UpdateTotal()
    {
        Total = _items.Sum(i => i.Total);
    }

    private Purchase()
    {
        SupplierId = 0;
        Total = 0;
        Supplier = default!;
        Arrived = false;
    }

    public Purchase(int supplierId, List<PurchaseItem> items) 
    {
        Guard.Against.NegativeOrZero(supplierId, nameof(supplierId));
        Guard.Against.NullOrEmpty(items, nameof(items));

        SupplierId = supplierId;
        Arrived = false;
        _items.AddRange(items);
        UpdateTotal();
        Supplier = default!;
    }
}
