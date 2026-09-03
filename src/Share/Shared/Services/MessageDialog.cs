
namespace Plugin.FacebookKit.Share;

/// <inheritdoc />
public sealed partial class MessageDialog : IMessageDialog
{
    /// <inheritdoc />
    public event EventHandler<FacebookSharingCompletedEventArgs>? OnShareCompleted;

    /// <inheritdoc />
    public event EventHandler<FacebookSharingFailedEventArgs>? OnShareFailed;

    /// <inheritdoc />
    public event EventHandler? OnShareCancelled;

    /// <inheritdoc />
    public void RaiseCompleted(ISharing sharer, FacebookSharingCompletedEventArgs e) => OnShareCompleted?.Invoke(sharer, e);

    /// <inheritdoc />
    public void RaiseFailed(ISharing sharer, FacebookSharingFailedEventArgs e) => OnShareFailed?.Invoke(sharer, e);

    /// <inheritdoc />
    public void RaiseCancelled(ISharing sharer) => OnShareCancelled?.Invoke(sharer, EventArgs.Empty);
}