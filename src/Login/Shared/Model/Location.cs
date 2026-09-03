
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class Location : ILocation
{
    /// <inheritdoc />
    public string? Id { get; }

    /// <inheritdoc />
    public string? Name { get; }

    /// <inheritdoc />
    public string DebugDescription() => $"Id={Id}, Name={Name}";
}