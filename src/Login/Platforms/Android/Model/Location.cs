
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class Location : ILocation
{
    internal Location(string? id, string? name)
    {
        Id = id;
        Name = name;
    }
    
    internal static Location? FromDictionary(IReadOnlyDictionary<string, string>? dictionary)
    {
        if (dictionary == null)
            return null;

        if (!dictionary.TryGetValue("id", out var id) ||
            !dictionary.TryGetValue("name", out var name))
        {
            return null;
        }

        return new Location(id, name);
    }
}