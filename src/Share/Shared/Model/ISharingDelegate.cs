
namespace Plugin.FacebookKit.Share;

/// <summary>
/// A delegate for types conforming to the <see cref="ISharing"/> interface.
/// The delegate is notified with the results of the sharer as long as the application has permissions to
/// receive the information.  For example, if the person is not signed into the containing app, the sharer may not be able
/// to distinguish between completion of a share and cancellation.
/// </summary>
public interface ISharingDelegate
{
    /// <summary>
    /// Event raised when <see cref="ISharingDialog"/> successfully completed display of the share dialog.
    /// </summary>
    event EventHandler<FacebookSharingCompletedEventArgs>? OnShareCompleted;

    /// <summary>
    /// Event raised when <see cref="ISharingDialog"/> failed to display the share dialog.
    /// </summary>
    event EventHandler<FacebookSharingFailedEventArgs>? OnShareFailed;

    /// <summary>
    /// Event raised when <see cref="ISharingDialog"/> cancels the share dialog display.
    /// </summary>
    event EventHandler? OnShareCancelled;
    
    /// <summary>
    /// Raises the Completed event in <see cref="ISharingDelegate"/> interface
    /// </summary>
    /// <param name="sender">The <see cref="ISharing"/> owner</param>
    /// <param name="e">The dictionary results</param>
    void RaiseCompleted(ISharing sender, FacebookSharingCompletedEventArgs e);

    /// <summary>
    /// Raises the Failed event in <see cref="ISharingDelegate"/> interface
    /// </summary>
    /// <param name="sender">The <see cref="ISharing"/> owner</param>
    /// <param name="e">The exception information</param>
    void RaiseFailed(ISharing sender, FacebookSharingFailedEventArgs e);

    /// <summary>
    /// Raises the Cancelled event in <see cref="ISharingDelegate"/> interface
    /// </summary>
    /// <param name="sender">The <see cref="ISharing"/> owner</param>
    void RaiseCancelled(ISharing sender);
}