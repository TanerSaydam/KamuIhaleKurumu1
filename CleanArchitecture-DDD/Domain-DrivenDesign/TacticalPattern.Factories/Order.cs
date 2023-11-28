using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticalPattern.Factories;

public class Order
{
    private Order(int id, string orderNumber)
    {
        Id = id;
        OrderNumber = orderNumber;
    }

    public int Id { get; private set; }
    public string OrderNumber { get; private set; }

    public Order Create(int id, string orderNumber)
    {
        if (orderNumber.Length < 16)
        {
            throw new ArgumentException("Sipariş numarası 16 karakterden küçük olamaz");
        }

        Order order = new(id, orderNumber);

        return order;
    }
}