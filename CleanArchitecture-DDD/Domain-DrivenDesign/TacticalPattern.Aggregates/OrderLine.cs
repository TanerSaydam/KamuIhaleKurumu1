namespace TacticalPattern.Aggregates;

public sealed class OrderLine
{
    public OrderLine(string productName, int quantity)
    {
        ProductName = productName;
        Quantity = quantity;
    }

    public string ProductName { get; private set; }
    public int Quantity { get; private set; }
}

public sealed class Order
{
    public int Id { get; private set; }
    public List<OrderLine> OrderLines { get; private set; }

    public Order()
    {
        OrderLines = new();
    }

    public void AddOrderLine(string productName, int quantity)
    {
        if (quantity <= 0)
        {
            throw new ArgumentException("Adet 0 dan küçük olamaz");
        }

        OrderLines.Add(new OrderLine(productName, quantity));
    }
}