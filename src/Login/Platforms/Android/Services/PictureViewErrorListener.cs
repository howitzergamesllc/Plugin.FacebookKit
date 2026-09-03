
using Plugin.FacebookKit.Core;
using Plugin.FacebookKit.Login.Controls;

namespace Plugin.FacebookKit.Login;

/// <summary>
/// A listener that executes a provided action when a Google Play Services <see cref="Task"/> fails.
/// </summary>
internal sealed class PictureViewErrorListener : Java.Lang.Object, Facebook.Login.Widget.ProfilePictureView.IOnErrorListener
{
    private readonly ProfilePictureViewHandler profilePictureViewHandler;

    internal PictureViewErrorListener(ProfilePictureViewHandler profilePictureViewHandler)
    {
        this.profilePictureViewHandler = profilePictureViewHandler;
    }

    /// <summary>
    /// Invokes the provided action with the exception.
    /// </summary>
    /// <param name="e">The exception that caused the task to fail.</param>
    public void OnError(Facebook.FacebookException e)
    {
        profilePictureViewHandler?.RaiseFailed(profilePictureViewHandler, new FacebookExceptionEventArgs(new FacebookException(e)));
    }
}