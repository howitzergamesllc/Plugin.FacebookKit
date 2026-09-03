
namespace Plugin.FacebookKit.Core;

/// <summary>
/// Global call back manager implementation for Facebook Sharing and Login SDKs.
/// </summary>
/// <remarks>
/// Use this by overriding OnActivityResult in the MainActivity of the Android Platform.
/// </remarks>
public sealed class FacebookMainActivity
{
    private static readonly Lazy<Facebook.ICallbackManager> callbackManager = new(() => Facebook.ICallbackManager.Factory.Create());

    /// <summary>
    /// The callback manager to register in MainActivity.OnActivityResult override.
    /// </summary>
    public static Facebook.ICallbackManager CallbackManager => callbackManager.Value;
}