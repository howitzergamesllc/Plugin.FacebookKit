
namespace Plugin.FacebookKit.Share;

/// <summary>
/// Represents a dialog capable of presenting share content.
/// </summary>
public interface IShareDialog : ISharingDialog
{
    /// <summary>
    /// The gets and sets the mode to display the dialog.
    /// </summary>
    ShareDialogMode Mode { get; set; }
}