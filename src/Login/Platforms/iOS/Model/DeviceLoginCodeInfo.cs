
namespace Plugin.FacebookKit.Login;

/// <inheritdoc />
internal sealed partial class DeviceLoginCodeInfo : IDeviceLoginCodeInfo
{
    internal DeviceLoginCodeInfo(string identifier, string loginCode, Uri? verificationUrl, DateTimeOffset expirationDate, TimeSpan pollingInterval)
    {
        Identifier = identifier;
        LoginCode = loginCode;
        VerificationUrl = verificationUrl;
        ExpirationDate = expirationDate;
        PollingInterval = pollingInterval;
    }
}