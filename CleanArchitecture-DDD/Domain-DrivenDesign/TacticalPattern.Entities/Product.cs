using TacticalPattern.Entities.Abstractions;

namespace TacticalPattern.Entities;

public sealed class Product : Entity //entity
{
    public Product(Guid id, string name) : base(id)
    {
        Name = name;
    }

    public string Name { get; private set; }

    public void ChangeName(string name)
    {
        Name = name;
    }
}