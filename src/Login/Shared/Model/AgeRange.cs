
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class AgeRange : IAgeRange
{
    /// <inheritdoc />
    public int? Min { get; }
    
    /// <inheritdoc />
    public int? Max { get; }

    /// <inheritdoc />
    public string DebugDescription() => $"Min={Min}, Max={Max}";
}