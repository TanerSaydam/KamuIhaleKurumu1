namespace eCommerceWebApi.Models;

public sealed class Category
{
    public Category()
    {
        Id = Ulid.NewUlid().ToString();
    }
    public string Id { get; private set; }
    public string Name { get; set; }
}
