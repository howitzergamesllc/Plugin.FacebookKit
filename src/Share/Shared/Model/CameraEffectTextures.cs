
namespace Plugin.FacebookKit.Share;

/// <summary>
/// The gets and sets images based on dictionary keys. Passed into <see cref="ShareCameraEffectContent"/>.
/// </summary>
public sealed class CameraEffectTextures
{
    private readonly Dictionary<string, byte[]> _images = new();


    /// <summary>
    /// Sets the <code>Image</code> for the texture in memory byte[]
    /// </summary>
    /// <param name="key"> The key for the texture</param>
    /// <returns>The texture <code>Image</code> or null</returns>
    public byte[]? this[string key]
    {
        get => _images.TryGetValue(key, out var image) ? image : null;
        set
        {
            if (value is null)
                _images.Remove(key);
            else
                _images[key] = value;
        }
    }

    /// <summary>
    /// Gets the container of arguments
    /// </summary>
    internal IReadOnlyDictionary<string, byte[]> Images => _images;
    
    /// <summary>
    /// Returns the string representation of the object.
    /// </summary>
    /// <returns></returns>
    public string DebugDescription() => $"CameraEffectArguments Values={string.Join(", ", Images.Select(p => $"{p.Key}={p.Value.Length}"))}";
}