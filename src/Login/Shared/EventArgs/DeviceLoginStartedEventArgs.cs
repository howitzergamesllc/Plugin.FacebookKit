
namespace Plugin.FacebookKit.Login;

/// <summary>
/// (Apple only) Indicates the device login flow has started. You should parse <code>codeInfo</code> to present the code to the user to enter.
/// </summary>
public sealed class DeviceLoginStartedEventArgs : EventArgs
{
    /// <summary>
    /// (Apple only) Initializes a new instance of the <see cref="DeviceLoginStartedEventArgs"/> class.
    /// </summary>
    /// <param name="codeInfo">
    /// The code info data.
    /// </param>
    public DeviceLoginStartedEventArgs(IDeviceLoginCodeInfo codeInfo)
    {
        CodeInfo = codeInfo;
    }

    /// <summary>
    /// (Apple only) The code info data.
    /// </summary>
    public IDeviceLoginCodeInfo CodeInfo { get; }
}
