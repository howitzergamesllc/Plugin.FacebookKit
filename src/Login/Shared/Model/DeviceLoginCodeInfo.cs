
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class DeviceLoginCodeInfo : IDeviceLoginCodeInfo
{
    /// <inheritdoc />
    public string Identifier { get; } = "";

    /// <inheritdoc />
    public string LoginCode { get; } = "";

    /// <inheritdoc />
    public Uri? VerificationUrl { get; }

    /// <inheritdoc />
    public DateTimeOffset ExpirationDate { get; }

    /// <inheritdoc />
    public TimeSpan PollingInterval { get; }

    /// <inheritdoc />
    public string DebugDescription() => $"Identifier={Identifier}, LoginCode={LoginCode}, VerificationUrl={VerificationUrl?.AbsolutePath} " +
        $"ExpirationDate={ExpirationDate}, PollingInterval={PollingInterval}";
}