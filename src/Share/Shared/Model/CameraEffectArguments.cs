
namespace Plugin.FacebookKit.Share;

/// <summary>
/// A container of arguments for a <see cref="ShareCameraEffectContent"/>
/// An argument is a <code>String</code> or <code>[String]</code> identified by a <code>String</code> key.
/// </summary>
public sealed partial class CameraEffectArguments
{
    private readonly Dictionary<string, object?> _values = new();

    /// <summary>
    /// Sets a string argument in the container.
    /// </summary>
    /// <param name="key">The key for the argument</param>
    /// <param name="value">The argument</param>
    public void SetString(string key, string? value) => _values[key] = value;

    /// <summary>
    /// Sets a string array argument in the container.
    /// </summary>
    /// <param name="key">The key for the argument</param>
    /// <param name="value">The argument</param>
    public void SetArray(string key, string[] value) => _values[key] = value;

    /// <summary>
    /// Gets a string argument from the container.
    /// </summary>
    /// <param name="key">The key for the argument</param>
    /// <returns>The string value or nil</returns>
    public string? GetString(string key) => _values.TryGetValue(key, out var value) ? value as string : null;

    /// <summary>
    /// Gets an array argument from the container.
    /// </summary>
    /// <param name="key">The key for the argument</param>
    /// <returns>The array argument</returns>
    public string[]? GetArray(string key) => _values.TryGetValue(key, out var value) ? value as string[] : null;

    /// <summary>
    /// Gets the container of arguments
    /// </summary>
    internal IReadOnlyDictionary<string, object?> Values => _values;
    
    /// <summary>
    /// Returns the string representation of the object.
    /// </summary>
    /// <returns></returns>
    public string DebugDescription() => $"CameraEffectArguments Values={string.Join(", ", Values.Select(p => $"{p.Key}={p.Value}"))}";
}