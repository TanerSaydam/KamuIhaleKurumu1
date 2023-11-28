using SnowflakeIdGeneratorForCSharp;

namespace KIKWebApi.Models;

public abstract class Entity
{
    public Entity()
    {
        var idGenerator = new SnowflakeIdGenerator(1, 1);
        Id = idGenerator.CreateId().ToString();
    }

    public string Id { get; set; }
}